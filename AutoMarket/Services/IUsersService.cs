using AutoMarket.Models.Users;
using System.Collections.Generic;

namespace AutoMarket.Services
{
    public interface IUsersService
    {
        // UsersOffersViewModel GetUsersVehicles();
        ICollection<UsersAllViewModel> GetUsersAcounts(string userId, int page, int itemsPerPage);
        UserDetailsViewModel GetUserById(string userId);
        int GetUserAcountsCount();
    }
}
