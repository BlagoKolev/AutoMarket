using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using AutoMarket.Data;
using AutoMarket.Data.Models;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Vehicles;

namespace AutoMarket.Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly ApplicationDbContext db;
        private readonly string[] AllowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

        public VehiclesService(ApplicationDbContext db)
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
                .OrderByDescending(x => x.CreatedOn)
                .Skip((id - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new VehicleOffersAllViewModel
                {
                    Id = x.Id,
                    Make = x.Vehicle.Make,
                    Model = x.Vehicle.Model,
                    Color = x.Vehicle.Color,
                    Price = x.Price,
                    Image = "/images/vehicles/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                })
            .ToList();
            return vehicleOffers;
        }

        public DetailsOfferViewModel GetVehicleOfferById(string offerId)
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

        public int GetItemsCount()
        {
            var itemsCount = this.db.VehicleOffers
                .Where(x => x.IsDeleted == false)
                .Count();
            return itemsCount;
        }

       




    }
}
