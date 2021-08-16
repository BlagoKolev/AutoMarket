using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using AutoMarket.Data;
using AutoMarket.Models.Users;
using AutoMarket.Data.Models;

namespace AutoMarket.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task DeleteAccountById(string userId)
        {
            var vehiclesOffers = this.db.VehicleOffers
                .Where(x => x.ApplicationUserId == userId)
                .ToList();

            foreach (var offer in vehiclesOffers)
            {
                offer.IsDeleted = true;
            }

            var partOffers = this.db.PartOffers
                .Where(x => x.ApplicationUserId == userId)
                .ToList();

            foreach (var offer in partOffers)
            {
                offer.IsDeleted = true;
            }

            var dealer = this.db.Dealers
                .Where(x => x.UserId == userId)
                .FirstOrDefault();

            if (dealer != null)
            {
                this.db.Dealers.Remove(dealer);
            }

            var user = this.db.ApplicationUsers
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            this.db.ApplicationUsers.Remove(user);
            await this.db.SaveChangesAsync();
        }

        public int GetUserAcountsCount()
        {
            return this.db.ApplicationUsers.Count();
        }
        public UserDetailsViewModel GetAccountByUserId(string userId)
        {
            var user = this.db.ApplicationUsers
                .Where(x => x.Id == userId)
                .Select(x => new UserDetailsViewModel
                     {
                       Id = x.Id,
                       Username = x.UserName,
                       Email = x.Email,
                       AccessFailedCount = x.AccessFailedCount,
                       LockoutEnabled = x.LockoutEnabled,
                       LockoutEnd = x.LockoutEnd,
                       TwoFactorEnabled = x.TwoFactorEnabled,
                       RegistrationDate = x.RegistrationDate.ToLocalTime().ToString("dd/MM/yyyy H:mm:ss"),
                       VehicleOffers = x.VehicleOffers.Where(x => x.IsDeleted == false).Count(),
                       PartOffers = x.PartOffers.Where(x => x.IsDeleted == false).Count(),
                     })
                    .FirstOrDefault();
            return user;
        }
        public ICollection<UsersAllViewModel> GetUsersAcounts(string userId, int page, int itemsPerPage)
        {
            var usersAcounts = this.db.ApplicationUsers
                .Where(x => x.Id != userId)
                .OrderByDescending(x => x.RegistrationDate)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new UsersAllViewModel
                {
                    Id = x.Id,
                    Username = x.UserName,
                    Email = x.Email
                })
                .ToList();
            return usersAcounts;
        }

        public async Task EditUserInfo(string userId, UserDetailsViewModel editedModel)
        {
            var user = this.db.ApplicationUsers
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            user.UserName = editedModel.Username;
            user.Email = editedModel.Email;
            user.AccessFailedCount = editedModel.AccessFailedCount;
            user.LockoutEnabled = editedModel.LockoutEnabled;
            user.LockoutEnd = editedModel.LockoutEnd;
            user.TwoFactorEnabled = editedModel.TwoFactorEnabled;

            await this.db.SaveChangesAsync();
        }
    }
}
