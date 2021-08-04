using AutoMarket.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IUsersService
    {
        // UsersOffersViewModel GetUsersVehicles();
        Task DeleteAccountById(string id);
        ICollection<UsersAllViewModel> GetUsersAcounts(string userId, int page, int itemsPerPage);
        UserDetailsViewModel GetUserById(string userId);
        int GetUserAcountsCount();
    }
}
