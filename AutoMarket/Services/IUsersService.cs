using AutoMarket.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IUsersService
    {
        // UsersOffersViewModel GetUsersVehicles();
        bool IsDealerExist(string dealerName);
        Task<bool> MakeUserDealer(string userId, string dealerName);
        BecomeDealerViewModel GetUserInfo(string userId);
        ICollection<UsersAllViewModel> GetUsersAcounts(string userId, int page, int itemsPerPage);
        UserDetailsViewModel GetUserById(string userId);
        int GetUserAcountsCount();
    }
}
