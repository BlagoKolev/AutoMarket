using AutoMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .Where(x=>x.IsDeleted == false)
                .Count();
            var vehicleOffers = db.VehicleOffers
                .Where(x=>x.IsDeleted == false)
                .Count();
            var offersCount = new List<int>();
            offersCount.Add(vehicleOffers);
            offersCount.Add(partOffers);
            return offersCount;
        }
    }
}
