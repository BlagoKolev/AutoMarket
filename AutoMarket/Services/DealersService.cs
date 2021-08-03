using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using AutoMarket.Data;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Dealers;
using AutoMarket.Data.Models;

namespace AutoMarket.Services
{
    public class DealersService : IDealersService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        public DealersService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<bool> MakeUserDealer(string userId, string dealerName)
        {
            var user = this.db.ApplicationUsers
                 .Where(x => x.Id == userId)
                 .FirstOrDefault();

            user.IsDealer = true;

            var newDealer = new Dealer
            {
                Name = dealerName,
                UserId = userId
            };

            await this.db.Dealers.AddAsync(newDealer);
            var firstSave = await this.db.SaveChangesAsync();

            user.DealerId = newDealer.Id;

            await userManager.AddToRoleAsync(user, "Dealer");


            var secondSave = await this.db.SaveChangesAsync();

            var isValid = firstSave + secondSave > 0;
            return isValid;
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
            var vehicleOffers = new List<MyOffersViewModel>();
            var partOffers = new List<MyOffersViewModel>();

            if (dealerName == null)
            {
                vehicleOffers = this.db.VehicleOffers
                    .Where(x => x.ApplicationUser.IsDealer && x.IsDeleted == false)
                    .OrderByDescending(x => x.CreatedOn)
                    .Select(x => new MyOffersViewModel
                    {
                        Id = x.Id,
                        Make = x.Vehicle.Make,
                        Model = x.Vehicle.Model,
                        Color = x.Vehicle.Color,
                        Price = x.Price,
                        Image = GlobalConstants.VehicleImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                        OwnerId = x.ApplicationUserId
                    })
                    .ToList();

                partOffers = this.db.PartOffers
                   .Where(x => x.ApplicationUser.IsDealer && x.IsDeleted == false)
                   .OrderByDescending(x => x.CreatedOn)
                   .Select(x => new MyOffersViewModel
                   {
                       Id = x.Id,
                       Name = x.Part.Name,
                       Status = x.Part.Status,
                       Price = x.Price,
                       Image = GlobalConstants.PartImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                       OwnerId = x.ApplicationUserId
                   })
                   .ToList();
            }
            else
            {
                var dealerId = GetDealerId(dealerName);

                 vehicleOffers = this.db.VehicleOffers
                    .Where(x => x.ApplicationUser.DealerId == dealerId && x.IsDeleted == false)
                    .OrderByDescending(x => x.CreatedOn)
                    .Select(x => new MyOffersViewModel
                    {
                        Id = x.Id,
                        Make = x.Vehicle.Make,
                        Model = x.Vehicle.Model,
                        Color = x.Vehicle.Color,
                        Price = x.Price,
                        Image = GlobalConstants.VehicleImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                        OwnerId = x.ApplicationUserId
                    })
                    .ToList();

                 partOffers = this.db.PartOffers
                    .Where(x => x.ApplicationUser.DealerId == dealerId && x.IsDeleted == false)
                    .OrderByDescending(x => x.CreatedOn)
                    .Select(x => new MyOffersViewModel
                    {
                        Id = x.Id,
                        Name = x.Part.Name,
                        Status = x.Part.Status,
                        Price = x.Price,
                        Image = GlobalConstants.PartImagePath + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension,
                        OwnerId = x.ApplicationUserId
                    })
                    .ToList();
            }
           

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
        public BecomeDealerViewModel GetUserInfo(string userId)
        {
            var user = this.db.ApplicationUsers
                .Where(x => x.Id == userId && x.IsDealer == false)
                .Select(x => new BecomeDealerViewModel
                {
                    UserId = x.Id,
                    UserEmail = x.Email
                }).FirstOrDefault();
            return user;
        }

        public bool IsDealerExist(string dealerName)
        {
            var dealer = this.db.Dealers
                .Where(x => x.Name == dealerName)
                .FirstOrDefault();

            return dealer != null;
        }
    }
}
