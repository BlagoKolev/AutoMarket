using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Models.Parts;
using System.Threading.Tasks;
using AutoMarket.ExtensionMethods;

namespace AutoMarket.Services
{
    public class PartsService : IPartsService
    {
        private readonly ApplicationDbContext db;
        private readonly string[] AllowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };
        public PartsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task CreatePartOffer(CreatePartViewModel formModel, string imagePath, string userId)
        {
            var newPart = new Part
            {
                Name = formModel.Name,
                PartCategory = formModel.PartCategory,
                Status = formModel.Status
            };

            var newPartOffer = new PartOffer
            {
                Title = formModel.Title,
                Description = formModel.Description,
                Phone = formModel.Phone,
                Location = formModel.Location,
                Email = formModel.Email,
                VehicleType = formModel.VehicleType,
                PartId = formModel.PartId,
                Part = newPart,
                Price = formModel.Price,
                ApplicationUserId = userId,
            };

            Directory.CreateDirectory($"{ imagePath }/parts/");

            if (formModel.Images != null)
            {
                foreach (var image in formModel.Images)
                {
                    var extension = Path.GetExtension(image.FileName).TrimStart('.');

                    if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
                    {
                        throw new Exception($"Invalid image extension {extension}");
                    }

                    var newImage = new Image
                    {
                        PartOffer = newPartOffer,
                        PartOfferId = newPartOffer.Id,
                        Extension = extension
                    };

                    newPartOffer.Pictures.Add(newImage);

                    var physicalPath = $"{imagePath}/parts/{newImage.Id}.{extension}";
                    using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.db.Parts.AddAsync(newPart);
            await this.db.PartOffers.AddAsync(newPartOffer);
            await this.db.SaveChangesAsync();
        }

        public ICollection<PartsAllViewModel> GelAllPartOffers(int id, int itemsPerPage)
        {
            var allPartOffers = this.db.PartOffers
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((id - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new PartsAllViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.Part.PartCategory,
                    Status = x.Part.Status,
                    Price = x.Price,
                    Image = GlobalConstants.PartImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                })
                .ToList();
            return allPartOffers;
        }

        public int GetAllPartsOffersCount()
        {
            var partOffersCount = this.db.PartOffers
                .Where(x => x.IsDeleted == false)
                .Count();
            return partOffersCount;
        }

        public DetailsPartsViewModel GetDetails(string offerId)
        {
            var imagesCollection = this.db.Images
            .Where(x => x.PartOfferId == offerId)
            .ToList();

            var imagesPath = new List<string>();

            foreach (var img in imagesCollection)
            {
                imagesPath.Add(GlobalConstants.PartImagePath + img.Id + '.' + img.Extension);
            }

            var currentPartOffer = this.db.PartOffers
                  .Where(x => x.Id == offerId && x.IsDeleted == false)
                  .Select(x => new DetailsPartsViewModel
                  {
                      Id = x.Id,
                      Title = x.Title,
                      Description = x.Description,
                      Email = x.Email,
                      Location = x.Location,
                      Phone = x.Phone,
                      PartId = x.PartId,
                      Name = x.Part.Name,
                      PartCategory = x.Part.PartCategory.GetDescription(),
                      Status = x.Part.Status,
                      VehicleType = x.VehicleType.GetDescription(),
                      Price = x.Price,
                      Images = imagesPath
                  })
                  .FirstOrDefault();
            return currentPartOffer;
        }
    }
}
