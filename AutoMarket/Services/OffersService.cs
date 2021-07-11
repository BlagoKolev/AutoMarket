using System;
using AutoMarket.Data;
using AutoMarket.Data.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMarket.Models.Offers;
using AutoMarket.Data.Models.Enum;

namespace AutoMarket.Services
{
    public class OffersService : IOffersService
    {
        private readonly ApplicationDbContext db;

        public OffersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateVehicle(CreateVehicleOfferViewModel offer,string userId)
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
            this.db.SaveChanges();

            var newOffer = new VehicleOffer
            {
               ApplicationUserId = userId,
                VehicleId = newVehicle.Id,
                Phone = offer.Phone,
                Email = offer.Email,
                Location = offer.Location,
                Price = offer.Price,
                Description = offer.Description,
            };

            this.db.VehicleOffers.Add(newOffer);

            this.db.SaveChanges();
        }

        public ICollection<VehicleOffersAllViewModel> GetAllVehiclesOffers()
        {
            var vehicleOffers = this.db.VehicleOffers
                 .Select(x => new VehicleOffersAllViewModel
                 {
                     Id = x.Id,
                     Make = x.Vehicle.Make,
                     Model = x.Vehicle.Model,
                     Color = x.Vehicle.Color.ToString(),
                     Price = x.Price
                 })
                 .ToList();
            return vehicleOffers;
        }

        public ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId)
        {
            var userVehicleOffers = this.db.VehicleOffers
                .Where(x => x.ApplicationUserId == userId)
                .Select(x=> new MyVehicleOffersViewModel
                {
                    Id= x.Id,
                    Make = x.Vehicle.Make,
                    Model = x.Vehicle.Model,
                    Color= x.Vehicle.Color,
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
                })
                .ToList();
            return userVehicleOffers;
        }

        public DetailsOfferViewModel GetVehicleOfferById(int carId)
        {
            var currentOffer = this.db.VehicleOffers
                .Where(x => x.Vehicle.Id == carId)
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
                })
                .FirstOrDefault();

            return currentOffer;
        }
    }
}
