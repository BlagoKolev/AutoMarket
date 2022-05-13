using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.ExtensionMethods;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Parts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public class OffersService : IOffersService
    {
        private readonly ApplicationDbContext db;
        public OffersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<MyOffersViewModel> GetAllUsersOffers(int id, string userId, int itemsPerPage)
        {
            var allOffers = new List<MyOffersViewModel>();

            var vehicleOffers = this.db.VehicleOffers
                .Where(x => x.ApplicationUserId == userId && x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new MyOffersViewModel
                {
                    Id = x.Id,
                    Make = x.Vehicle.Make,
                    Model = x.Vehicle.Model,
                    Color = x.Vehicle.Color,
                    Price = x.Price,
                    CreatedOn = x.CreatedOn.ToLocalTime(),
                    EngineType = x.Vehicle.EngineType,
                    ManufactoringYear = x.Vehicle.ManufacturingYear,
                    Image = GlobalConstants.VehicleImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                    OwnerId = x.ApplicationUserId
                })
                .ToList();

            var partsOffers = this.db.PartOffers
                .Where(x => x.ApplicationUserId == userId && x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new MyOffersViewModel
                {
                    Id = x.Id,
                    Name = x.Part.Name,
                    Status = x.Part.Status,
                    Price = x.Price,
                    Title = x.Title,
                    CreatedOn = x.CreatedOn.ToLocalTime(),
                    Image = GlobalConstants.PartImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                    OwnerId = x.ApplicationUserId
                })
                .ToList();

            allOffers.AddRange(vehicleOffers);
            allOffers.AddRange(partsOffers);

            return allOffers
                 .Skip((id - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .ToList();
        }

        public int GetAllUsersOffersCount(string userId)
        {
            var vehiclesCount = this.db.VehicleOffers
                .Where(x => x.ApplicationUserId == userId)
                .Count();
            var partsCount = this.db.PartOffers
                .Where(x => x.ApplicationUserId == userId)
                .Count();
            return vehiclesCount + partsCount;
        }

        public ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId, int id, int itemsPerPage)
        {
            var imagesInOffer = new List<string>();

            var userVehicleOffers = this.db.VehicleOffers
           .Where(x => x.ApplicationUserId == userId && x.IsDeleted == false)
           .OrderByDescending(x => x.CreatedOn)
           .Skip((id - 1) * itemsPerPage)
           .Take(itemsPerPage)
           .Select(x => new MyVehicleOffersViewModel
           {
               Id = x.Id,
               Make = x.Vehicle.Make,
               Model = x.Vehicle.Model,
               Color = x.Vehicle.Color,
               Price = x.Price,
               Image = GlobalConstants.VehicleImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
           })
           .ToList();
            return userVehicleOffers;
        }

        public EditVehicleOfferViewModel GetVehicleToEdit(string offerId, string userId, bool isUserAdmin)
        {
            var imagesPath = this.db.Images
                .Where(x => x.VehicleOfferId == offerId)
                .Select(x => GlobalConstants.VehicleImagePath + x.Id + '.' + x.Extension)
                .ToList();


            var vehicleToEdit = this.db.VehicleOffers
                 .Where(x => x.Id == offerId && (x.ApplicationUserId == userId || isUserAdmin == true))
                 .Select(x => new EditVehicleOfferViewModel
                 {
                     Id = x.Id,
                     Make = x.Vehicle.Make,
                     Model = x.Vehicle.Model,
                     BodyType = x.Vehicle.BodyType,
                     EngineCapacity = x.Vehicle.EngineCapacity,
                     EngineType = x.Vehicle.EngineType,
                     HorsePower = x.Vehicle.HorsePower,
                     ManufacturingYear = x.Vehicle.ManufacturingYear,
                     Transmission = x.Vehicle.Transmission,
                     Мileage = x.Vehicle.Мileage,
                     EuroStandart = x.Vehicle.EuroStandart,
                     Color = x.Vehicle.Color,
                     Images = imagesPath,
                     Description = x.Description,
                     Email = x.Email,
                     Phone = x.Phone,
                     Location = x.Location,
                     Price = x.Price
                 })
                 .FirstOrDefault();

            return vehicleToEdit;
        }

        public async Task UpdateVehicleOffer(EditVehicleOfferViewModel editedModel, string offerId, string userId, bool isUserAdmin)
        {
            var images = this.db.Images
                 .Where(x => x.VehicleOfferId == offerId)
                                  .ToList();

            var currentOffer = this.db.VehicleOffers
                .Where(x => x.Id == offerId && (x.ApplicationUserId == userId || isUserAdmin == true))
                .FirstOrDefault();

            var currentVehicle = this.db.Vehicles
                .Where(x => x.Id == currentOffer.VehicleId)
                .FirstOrDefault();

            currentOffer.Vehicle = currentVehicle;

            UpdateVehicleEntity(editedModel, currentOffer, images);
            this.db.Update(currentOffer);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteOffer(string offerId, string userId, bool isUserAdmin)
        {
            if (offerId.StartsWith("Part"))
            {
                var offerToDelete = this.db.PartOffers
               .Where(x => x.Id == offerId && (x.ApplicationUserId == userId || isUserAdmin))
               .FirstOrDefault();
                offerToDelete.IsDeleted = true;
            }
            else
            {
                var offerToDelete = this.db.VehicleOffers
               .Where(x => x.Id == offerId && (x.ApplicationUserId == userId || isUserAdmin))
               .FirstOrDefault();
                offerToDelete.IsDeleted = true;
            }
            await this.db.SaveChangesAsync();
        }

        public DetailsVehicleOfferViewModel GetVehicleOfferById(string offerId)
        {
            var imagesCollection = this.db.Images
             .Where(x => x.VehicleOfferId == offerId)
             .ToList();

            var imagesPath = new List<string>();

            foreach (var img in imagesCollection)
            {
                imagesPath.Add(GlobalConstants.VehicleImagePath + img.Id + '.' + img.Extension);
            }

            var currentOffer = this.db.VehicleOffers
                .Where(x => x.Id == offerId)
                .Select(x => new DetailsVehicleOfferViewModel
                {
                    Id = x.Id,
                    Make = x.Vehicle.Make,
                    Model = x.Vehicle.Model,
                    Color = x.Vehicle.Color.GetDescription(),
                    BodyType = x.Vehicle.BodyType.GetDescription(),
                    EngineCapacity = x.Vehicle.EngineCapacity,
                    HorsePower = x.Vehicle.HorsePower,
                    ManufacturingYear = x.Vehicle.ManufacturingYear,
                    Transmission = x.Vehicle.Transmission.GetDescription(),
                    Мileage = x.Vehicle.Мileage,
                    EngineType = x.Vehicle.EngineType,
                    EuroStandart = x.Vehicle.EuroStandart.GetDescription(),
                    Description = x.Description,
                    Email = x.Email,
                    Location = x.Location,
                    Phone = x.Phone,
                    Price = x.Price,
                    OwnerId = x.ApplicationUserId,
                    Images = imagesPath
                })
                .FirstOrDefault();

            return currentOffer;
        }

        public int GetItemsCount()
        {
            var itemsCount = this.db.VehicleOffers
                .Where(x => x.IsDeleted == false)
                .Count();
            return itemsCount;
        }

        private static void UpdateVehicleEntity(EditVehicleOfferViewModel editedModel, VehicleOffer entityToEdit, ICollection<Image> images)
        {
            entityToEdit.Vehicle.Make = editedModel.Make;
            entityToEdit.Vehicle.Model = editedModel.Model;
            entityToEdit.Vehicle.Color = editedModel.Color;
            entityToEdit.Vehicle.BodyType = editedModel.BodyType;
            entityToEdit.Vehicle.EngineCapacity = editedModel.EngineCapacity;
            entityToEdit.Vehicle.EngineType = editedModel.EngineType;
            entityToEdit.Vehicle.EuroStandart = editedModel.EuroStandart;
            entityToEdit.Vehicle.HorsePower = editedModel.HorsePower;
            entityToEdit.Vehicle.ManufacturingYear = editedModel.ManufacturingYear;
            entityToEdit.Vehicle.Мileage = editedModel.Мileage;
            entityToEdit.Vehicle.Transmission = editedModel.Transmission;
            entityToEdit.Description = editedModel.Description;
            entityToEdit.Email = editedModel.Email;
            entityToEdit.Phone = editedModel.Phone;
            entityToEdit.Location = editedModel.Location;
            entityToEdit.Price = editedModel.Price;
            entityToEdit.Pictures = images;
        }

        public PartDetailsViewModel GetPartDetails(string offerId)
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
                  .Select(x => new PartDetailsViewModel
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
                      OwnerId = x.ApplicationUserId,
                      Images = imagesPath
                  })
                  .FirstOrDefault();
            return currentPartOffer;
        }

        public EditPartOfferViewModel GetPartToEdit(string offerId, string userId, bool isUserAdmin)
        {
            var partImages = this.db.Images
                .Where(x => x.PartOfferId == offerId)
                .Select(x => GlobalConstants.PartImagePath + x.Id + '.' + x.Extension)
                .ToList();

            var curretnPartOffer = this.db.PartOffers
                .Where(x => x.Id == offerId
                && x.IsDeleted == false
                && (x.ApplicationUserId == userId || isUserAdmin == true))
                .Select(x => new EditPartOfferViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Email = x.Email,
                    Location = x.Location,
                    Phone = x.Phone,
                    Price = x.Price,
                    Name = x.Part.Name,
                    PartCategory = x.Part.PartCategory,
                    PartId = x.PartId,
                    Status = x.Part.Status,
                    VehicleType = x.VehicleType,
                    Images = partImages
                })
                .FirstOrDefault();
            return curretnPartOffer;
        }

        public async Task UpdatePartOffer(EditPartOfferViewModel editedModel, string offerId, string userId, bool isUserAdmin)
        {
            var images = this.db.Images
                 .Where(x => x.VehicleOfferId == offerId && !x.IsDeleted)
                 .ToList();

            var currentOffer = this.db.PartOffers
                .Where(x => x.Id == offerId && (x.ApplicationUserId == userId || isUserAdmin == true))
                .FirstOrDefault();

            var currentPart = this.db.Parts
                .Where(x => x.Id == currentOffer.PartId)
                .FirstOrDefault();

            currentOffer.Part = currentPart;

            UpdatePartEntity(editedModel, currentOffer, images);
            this.db.Update(currentOffer);
            await this.db.SaveChangesAsync();
        }

        private static void UpdatePartEntity(EditPartOfferViewModel editedModel, PartOffer entityToEdit, ICollection<Image> images)
        {
            entityToEdit.Title = editedModel.Title;
            entityToEdit.Description = editedModel.Description;
            entityToEdit.Email = editedModel.Email;
            entityToEdit.Location = editedModel.Location;
            entityToEdit.Phone = editedModel.Phone;
            entityToEdit.Price = editedModel.Price;
            entityToEdit.VehicleType = editedModel.VehicleType;
            entityToEdit.Part.Name = editedModel.Name;
            entityToEdit.Part.PartCategory = editedModel.PartCategory;
            entityToEdit.Part.Status = editedModel.Status;
            entityToEdit.Pictures = images;
        }

        public async Task<string> DeleteImageById(string imageId)
        {
            var image = this.db.Images.Where(x => x.Id == imageId).FirstOrDefault();
            var offerId = image.VehicleOfferId;

            this.db.Images.Remove(image);
            await  this.db.SaveChangesAsync();

            return offerId;
        }
    }
}
