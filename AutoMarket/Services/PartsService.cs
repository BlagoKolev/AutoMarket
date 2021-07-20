using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Models.Parts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public void CreatePartOffer(CreatePartViewModel formModel, string imagePath, string userId)
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
                        PartOfferId = newPartOffer.Id
                    };

                    newPartOffer.Pictures.Add(newImage);

                    var physicalPath = $"{imagePath}/parts/{newImage.Id}.{extension}";
                    using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                    image.CopyTo(fileStream);
                }
            }

            this.db.Parts.Add(newPart);
            this.db.PartOffers.Add(newPartOffer);
            this.db.SaveChanges();
        }

        public ICollection<PartsAllViewModel> GelAllPartOffers(int id, int itemsPerPage)
        {
            var allPartOffers = this.db.PartOffers
                .Where(x => x.IsDeleted == false)
                .Select(x => new PartsAllViewModel
                {
                    Id = x.Id,
                    Name = x.Part.Name,
                    Category = x.Part.PartCategory,
                    Status = x.Part.Status,
                    Price = x.Price,
                    Image = "/images/parts" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
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

        public int getUsersPartOffersCount(string userId)
        {
            var partOffersCount = this.db.PartOffers
                .Where(x => x.ApplicationUserId == userId && x.IsDeleted == false)
                .Count();
            return partOffersCount;
        }

        public ICollection<MyPartsViewModel> GetUsersParts(string userId, int id, int itemsPerPage)
        {
            var usersParts = this.db.PartOffers
                .Where(x => x.ApplicationUserId == userId && x.IsDeleted == false)
                .OrderByDescending(x=>x.Id)
                .Skip((id-1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new MyPartsViewModel
                {
                    Id = x.Id,
                    Name = x.Part.Name,
                    Status = x.Part.Status,
                    Price = x.Price,
                    Image = "/images/parts/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                })
                .ToList();
            return usersParts;
        }
    }
}
