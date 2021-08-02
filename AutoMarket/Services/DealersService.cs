using System.Linq;
using System.Collections.Generic;
using AutoMarket.Data;
using AutoMarket.Models.Offers;

namespace AutoMarket.Services
{
    public class DealersService : IDealersService
    {
        private readonly ApplicationDbContext db;
        public DealersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ICollection<string> GetAllDealers()
        {
            var dealers = this.db.ApplicationUsers
                .Where(x => x.IsDealer)
                .Select(x => x.Dealer.Name)
                .ToList();
            return dealers;
        }

        public ICollection<MyOffersViewModel> GetDealersOffersByName(string dealerName, int id, int itemsPerPage)
        {
            var dealerId = GetDealerId(dealerName);

            var vehicleOffers = this.db.VehicleOffers
                .Where(x => x.ApplicationUser.DealerId == dealerId && x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new MyOffersViewModel
                {
                    Id = x.Id,
                    Make = x.Vehicle.Make,
                    Model = x.Vehicle.Model,
                    Color = x.Vehicle.Color,
                    Price = x.Price,
                    Image = GlobalConstants.VehicleImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                })
                .ToList();

            var partOffers = this.db.PartOffers
                .Where(x => x.ApplicationUser.DealerId == dealerId && x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new MyOffersViewModel
                {
                    Id = x.Id,
                    Name = x.Part.Name,
                    Status = x.Part.Status,
                    Price = x.Price,
                    Image = GlobalConstants.PartImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                })
                .ToList();

            var dealerOffers = new List<MyOffersViewModel>();
            dealerOffers.AddRange(vehicleOffers);
            dealerOffers.AddRange(partOffers);

            dealerOffers = dealerOffers
                .Skip((id - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            return dealerOffers;
        }

        public int GetOffersCount(string dealerName)
        {
            var dealerId = GetDealerId(dealerName);

            var vehicleOffers = this.db.VehicleOffers
                .Where(x => x.ApplicationUser.DealerId == dealerId && x.IsDeleted == false)
                .Count();
            var partOffers = this.db.PartOffers
               .Where(x => x.ApplicationUser.DealerId == dealerId && x.IsDeleted == false)
               .Count();
            return vehicleOffers + partOffers;
        }

        private int GetDealerId(string dealerName)
        {
           return this.db.Dealers
                .Where(x => x.Name == dealerName)
                .Select(x => x.Id)
                .FirstOrDefault();
        }
    }
}
