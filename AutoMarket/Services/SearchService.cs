using System;
using System.Linq;
using System.Collections.Generic;
using AutoMarket.Data;
using AutoMarket.Data.Models.Enum;
using AutoMarket.Models.Parts;
using AutoMarket.Models.Vehicles;

namespace AutoMarket.Services
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext db;
        public SearchService(ApplicationDbContext db)
        {
            this.db = db;
        }
               
        public ICollection<PartsAllViewModel> GetPartOffers(string keyword, string status)
        {
            PartStatus partStatus;
            var partOffers = new List<PartsAllViewModel>();
            var isStatusValid = Enum.TryParse<PartStatus>(status, out partStatus);

            if (!isStatusValid)
            {
                if (keyword != null)
                {
                    partOffers = this.db.PartOffers
                   .Where(x => x.IsDeleted == false
                   && x.Title.ToLower().Contains(keyword.ToLower())
                   || x.Description.ToLower().Contains(keyword.ToLower())
                   || x.Part.Name.ToLower().Contains(keyword.ToLower()))
                   .Select(x => new PartsAllViewModel
                   {
                       Id = x.Id,
                       Title = x.Title,
                       Category = x.Part.PartCategory,
                       Status = x.Part.Status,
                       Price = x.Price,
                       Image = "/images/parts/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                   })
                   .ToList();
                }
                else
                {
                    partOffers = this.db.PartOffers
                   .Where(x => x.IsDeleted == false)
                   .Select(x => new PartsAllViewModel
                   {
                       Id = x.Id,
                       Title = x.Title,
                       Category = x.Part.PartCategory,
                       Status = x.Part.Status,
                       Price = x.Price,
                       Image = "/images/parts/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                   })
                   .ToList();
                }
            }
            else
            {
                if (keyword != null)
                {
                    partOffers = this.db.PartOffers
                  .Where(x => x.IsDeleted == false
                  && x.Part.Status == partStatus
                  && x.Title.ToLower().Contains(keyword.ToLower())
                  || x.Description.ToLower().Contains(keyword.ToLower())
                  || x.Part.Name.ToLower().Contains(keyword.ToLower()))
                  .Select(x => new PartsAllViewModel
                  {
                      Id = x.Id,
                      Title = x.Title,
                      Category = x.Part.PartCategory,
                      Status = x.Part.Status,
                      Price = x.Price,
                      Image = "/images/parts/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                  })
                  .ToList();
                }
                else
                {
                    partOffers = this.db.PartOffers
                  .Where(x => x.IsDeleted == false
                  && x.Part.Status == partStatus)
                  .Select(x => new PartsAllViewModel
                  {
                      Id = x.Id,
                      Title = x.Title,
                      Category = x.Part.PartCategory,
                      Status = x.Part.Status,
                      Price = x.Price,
                      Image = "/images/parts/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                  })
                  .ToList();
                }
            }
            return partOffers;
        }

        public ICollection<VehicleOffersAllViewModel> GetVehicleOffers(string make, string vehicleModel)
        {
            var vehicleOffers = new List<VehicleOffersAllViewModel>();

            if (string.IsNullOrWhiteSpace(make) && string.IsNullOrWhiteSpace(vehicleModel))
            {
                vehicleOffers = this.db.VehicleOffers
              .OrderByDescending(x => x.CreatedOn)
              .Where(x => x.IsDeleted == false)
              .Select(x => new VehicleOffersAllViewModel
              {
                  Id = x.Id,
                  Make = x.Vehicle.Make,
                  Model = x.Vehicle.Model,
                  Color = x.Vehicle.Color,
                  Image = "/images/vehicles/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                  Price = x.Price
              })
              .ToList();
            }
            else if (string.IsNullOrWhiteSpace(vehicleModel))
            {
                vehicleOffers = this.db.VehicleOffers
              .OrderByDescending(x => x.CreatedOn)
              .Where(x => x.IsDeleted == false && x.Vehicle.Make == make)
              .Select(x => new VehicleOffersAllViewModel
              {
                  Id = x.Id,
                  Make = x.Vehicle.Make,
                  Model = x.Vehicle.Model,
                  Color = x.Vehicle.Color,
                  Image = "/images/vehicles/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                  Price = x.Price
              })
              .ToList();
            }
            else if (string.IsNullOrWhiteSpace(make))
            {
                vehicleOffers = this.db.VehicleOffers
              .OrderByDescending(x => x.CreatedOn)
              .Where(x => x.IsDeleted == false
              && x.Vehicle.Model.ToLower().Contains(vehicleModel.ToLower()))
              .Select(x => new VehicleOffersAllViewModel
              {
                  Id = x.Id,
                  Make = x.Vehicle.Make,
                  Model = x.Vehicle.Model,
                  Color = x.Vehicle.Color,
                  Image = "/images/vehicles/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                  Price = x.Price
              })
              .ToList();
            }
            else
            {
                vehicleOffers = this.db.VehicleOffers
               .OrderByDescending(x => x.CreatedOn)
               .Where(x => x.IsDeleted == false
               && x.Vehicle.Make == make
               && x.Vehicle.Model.ToLower().Contains(vehicleModel.ToLower()))
               .Select(x => new VehicleOffersAllViewModel
               {
                   Id = x.Id,
                   Make = x.Vehicle.Make,
                   Model = x.Vehicle.Model,
                   Color = x.Vehicle.Color,
                   Image = "/images/vehicles/" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                   Price = x.Price
               })
               .ToList();
            }

            return vehicleOffers;
        }

        public ICollection<string> GetVehiclesMakes()
        {
            var allVehiclesMakes = this.db.VehicleOffers
                 .Where(x => x.IsDeleted == false)
                 .OrderBy(x => x.Vehicle.Make)
                 .Select(x => x.Vehicle.Make)
                 .Distinct()
                 .ToList();
            return allVehiclesMakes;
        }
    }
}
