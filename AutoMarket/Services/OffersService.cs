using System;
using AutoMarket.Data;
using AutoMarket.Data.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMarket.Models.Offers;
using AutoMarket.Data.Models.Enum;
using System.IO;

namespace AutoMarket.Services
{
    public class OffersService : IOffersService
    {
        private readonly ApplicationDbContext db;
        private readonly string[] AllowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

        public OffersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateVehicle(CreateVehicleOfferViewModel offer, string userId, string imagePath)
        {
            var newVehicle = new Vehicle
            {
                Make = offer.Make,
                Model = offer.Model,
                BodyType = offer.BodyType,
                ManufacturingYear = offer.ManufacturingYear,
                EngineCapacity = offer.EngineCapacity,
                EngineType = offer.EngineType,
                HorsePower = offer.HorsePower,
                Transmission = offer.Transmission,
                Color = offer.Color,
                EuroStandart = offer.EuroStandart,
                Мileage = offer.Мileage,
            };

            this.db.Vehicles.Add(newVehicle);

            var newOffer = new VehicleOffer
            {
                ApplicationUserId = userId,
                Vehicle = newVehicle,
                Phone = offer.Phone,
                Email = offer.Email,
                Location = offer.Location,
                Price = offer.Price,
                Description = offer.Description,
            };

            this.db.VehicleOffers.Add(newOffer);

            Directory.CreateDirectory($"{imagePath}/vehicles/");

            if (offer.Images != null)
            {
                foreach (var image in offer.Images)
                {
                    var extension = Path.GetExtension(image.FileName).TrimStart('.');
                    if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
                    {
                        throw new Exception($"Invalid image extension {extension}");
                    }

                    var newImage = new Image
                    {
                        VehicleOffer = newOffer,
                        Extension = extension,
                    };

                    newOffer.Pictures.Add(newImage);

                    var physicalPath = $"{imagePath}/vehicles/{newImage.Id}.{extension}";
                    using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                    image.CopyTo(fileStream);
                }
            }

            this.db.SaveChanges();
        }

        public ICollection<VehicleOffersAllViewModel> GetAllVehiclesOffers(int id, int itemsPerPage)
        {

            var vehicleOffers = this.db.VehicleOffers
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .Skip((id - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new VehicleOffersAllViewModel
                {
                    Id = x.Id,
                    Make = x.Vehicle.Make,
                    Model = x.Vehicle.Model,
                    Color = x.Vehicle.Color.ToString(),
                    Price = x.Price,
                    Image = "/images/vehicles/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                })
            .ToList();
            return vehicleOffers;
        }

        public int GetItemsCount()
        {
            var itemsCount = this.db.VehicleOffers
                .Where(x => x.IsDeleted == false)
                .Count();
            return itemsCount;
        }

        public EditVehicleOfferViewModel GetVehicleToEdit(int carId, string userId)
        {
            var offerId = this.db.VehicleOffers
                .Where(x => x.VehicleId == carId)
                .Select(x => x.Id)
                .FirstOrDefault();

            var imagesPath = this.db.Images
                .Where(x => x.VehicleOfferId == offerId)
                .Select(x => "/images/vehicles/" + x.Id + '.' + x.Extension)
                .ToList();


            var vehicleToEdit = this.db.VehicleOffers
                 .Where(x => x.VehicleId == carId && x.ApplicationUserId == userId)
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

        public ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId, int id, int itemsPerPage)
        {
            var imagesInOffer = new List<string>();

            var userVehicleOffers = this.db.VehicleOffers
           .Where(x => x.ApplicationUserId == userId && x.IsDeleted == false)
           .OrderByDescending(x => x.Id)
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

        public DetailsOfferViewModel GetVehicleOfferById(int offerId)
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
                .Where(x => x.Vehicle.Id == offerId)
                .Select(x => new DetailsOfferViewModel
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

        public void UpdateVehicleOffer(EditVehicleOfferViewModel editedModel, int offerId)
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

        public void DeleteOffer(int offerId, string userId)
        {
            var offerToDelete = this.db.VehicleOffers
                .Where(x => x.Id == offerId && x.ApplicationUserId == userId)
                .FirstOrDefault();
            offerToDelete.IsDeleted = true;

            this.db.SaveChanges();
        }
    }
}
