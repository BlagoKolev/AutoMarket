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
        public int GetAllOffersCount()
        {
            var partOffers = db.PartOffers.Count();
            var vehicleOffers = db.VehicleOffers.Count();
            var offersCount = partOffers + vehicleOffers;
            return offersCount;
        }
    }
}
