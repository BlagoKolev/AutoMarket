using System.Linq;
using System.Collections.Generic;
using AutoMarket.Data;
using AutoMarket.Models.Users;
using System.Threading.Tasks;
using AutoMarket.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AutoMarket.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        public UsersService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public int GetUserAcountsCount()
        {
            return this.db.ApplicationUsers.Count();
        }

        public UserDetailsViewModel GetUserById(string userId)
        {
            var user = this.db.ApplicationUsers
                .Where(x => x.Id == userId)
                .Select(x => new UserDetailsViewModel
                {
                    Id = x.Id,
                    Username = x.UserName,
                    Email = x.Email,
                    AccessFailedCount = x.AccessFailedCount,
                    LockoutEnabled = x.LockoutEnabled.ToString(),
                    LockoutEnd = x.LockoutEnd,
                    TwoFactorEnabled = x.TwoFactorEnabled.ToString(),
                    RegistrationDate = x.RegistrationDate.ToString("dd/MM/yy H:mm:ss"),
                    VehicleOffers = x.VehicleOffers.Count,
                    PartOffers = x.PartOffers.Count,
                })
                .FirstOrDefault();
            return user;
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

        public bool IsDealerExist(string dealerName)
        {
            var dealer = this.db.Dealers
                .Where(x => x.Name == dealerName)
                .FirstOrDefault();

            return dealer != null;
        }

        public  async Task<bool> MakeUserDealer(string userId, string dealerName)
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

            await userManager.AddToRoleAsync(user,"Dealer");

           
            var secondSave = await this.db.SaveChangesAsync();

            var isValid = firstSave + secondSave > 0;
            return isValid;
        }
    }
}
