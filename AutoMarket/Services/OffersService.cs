using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Models.Offers;
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
                    CreatedOn = x.CreatedOn,
                    Image = "/images/vehicles/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
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
                    CreatedOn = x.CreatedOn,
                    Image = "/images/parts/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
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
               Image = "/images/vehicles/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
           })
           .ToList();
            return userVehicleOffers;
        }

        public EditVehicleOfferViewModel GetVehicleToEdit(string carId, string userId)
        {
            var offerId = this.db.VehicleOffers
                .Where(x => x.Id == carId)
                .Select(x => x.Id)
                .FirstOrDefault();

            var imagesPath = this.db.Images
                .Where(x => x.VehicleOfferId == offerId)
                .Select(x => "/images/vehicles/" + x.Id + '.' + x.Extension)
                .ToList();


            var vehicleToEdit = this.db.VehicleOffers
                 .Where(x => x.Id == carId && x.ApplicationUserId == userId)
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

        public void UpdateVehicleOffer(EditVehicleOfferViewModel editedModel, string offerId)
        {
            var images = this.db.Images
                 .Where(x => x.VehicleOfferId == offerId)
                                  .ToList();

            var currentOffer = this.db.VehicleOffers
                .Where(x => x.Id == offerId)
                .FirstOrDefault();

            var currentVehicle = this.db.Vehicles
                .Where(x => x.Id == currentOffer.VehicleId)
                .FirstOrDefault();

            currentOffer.Vehicle = currentVehicle;

            UpdateEntity(editedModel, currentOffer, images);
            this.db.Update(currentOffer);
            this.db.SaveChanges();
        }

        public void DeleteOffer(string offerId, string userId)
        {
            var offerToDelete = this.db.VehicleOffers
                .Where(x => x.Id == offerId && x.ApplicationUserId == userId)
                .FirstOrDefault();
            offerToDelete.IsDeleted = true;

            this.db.SaveChanges();
        }

        public DetailsVehicleOfferViewModel GetVehicleOfferById(string offerId)
        {
            var imagesCollection = this.db.Images
             .Where(x => x.VehicleOfferId == offerId)
             .ToList();

            var imagesPath = new List<string>();

            foreach (var img in imagesCollection)
            {
                imagesPath.Add("/images/vehicles/" + img.Id + '.' + img.Extension);
            }


            var currentOffer = this.db.VehicleOffers
                .Where(x => x.Id == offerId)
                .Select(x => new DetailsVehicleOfferViewModel
                {
                    Id = x.Id,
                    Make = x.Vehicle.Make,
                    Model = x.Vehicle.Model,
                    Color = x.Vehicle.Color,
                    BodyType = x.Vehicle.BodyType,
                    EngineCapacity = x.Vehicle.EngineCapacity,
                    HorsePower = x.Vehicle.HorsePower,
                    ManufacturingYear = x.Vehicle.ManufacturingYear,
                    Transmission = x.Vehicle.Transmission,
                    Мileage = x.Vehicle.Мileage,
                    EngineType = x.Vehicle.EngineType,
                    EuroStandart = x.Vehicle.EuroStandart,
                    Description = x.Description,
                    Email = x.Email,
                    Location = x.Location,
                    Phone = x.Phone,
                    Price = x.Price,
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

        private static VehicleOffer UpdateEntity(EditVehicleOfferViewModel editedModel, VehicleOffer entityToEdit, ICollection<Image> images)
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
            return entityToEdit;
        }
    }
}
