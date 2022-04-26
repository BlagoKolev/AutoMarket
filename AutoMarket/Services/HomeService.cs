using System.Linq;
using System.Collections.Generic;
using AutoMarket.Data;
using AutoMarket.Models.Home;

namespace AutoMarket.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext db;
        public HomeService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<int> GetAllOffersCount()
        {
            var partOffers = db.PartOffers
                .Where(x => x.IsDeleted == false)
                .Count();
            var vehicleOffers = db.VehicleOffers
                .Where(x => x.IsDeleted == false)
                .Count();
            var offersCount = new List<int>
            {
                vehicleOffers,
                partOffers
            };

            return offersCount;
        }

        public ICollection<FeaturedVehiclesViewModel> GetFirstSixVehicleOffers()
        {
            var firstSixOffers = this.db.VehicleOffers
                 .Where(x => x.IsDeleted == false)
                 .OrderByDescending(x => x.CreatedOn)
                 .Take(6)
                 .Select(x => new FeaturedVehiclesViewModel
                 {
                     Id = x.Id,
                     Make = x.Vehicle.Make,
                     Model = x.Vehicle.Model,
                     Color = x.Vehicle.Color,
                     EngineType = x.Vehicle.EngineType,
                     ManufactoringYear = x.Vehicle.ManufacturingYear,
                     Price = x.Price,
                     Image = GlobalConstants.VehicleImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                 })
                 .ToList();

            return firstSixOffers;
        }
    }
}
