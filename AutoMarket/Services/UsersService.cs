using System.Linq;
using System.Collections.Generic;
using AutoMarket.Data;
using AutoMarket.Models.Users;


namespace AutoMarket.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        public UsersService(ApplicationDbContext db)
        {
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
                    Username = x.UserName,
                    Email = x.Email,
                    AccessFailedCount = x.AccessFailedCount,
                    LockoutEnabled = x.LockoutEnabled.ToString(),
                    LockoutEnd = x.LockoutEnd,
                    TwoFactorEnabled = x.TwoFactorEnabled.ToString(),
                    RegistrationDate = x.RegistrationDate.ToString(),
                    VehicleOffers = x.VehicleOffers.Count,
                    PartOffers = x.PartOffers.Count,
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
    }
}
