using AutoMarket.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IUsersService
    {
        Task EditUserInfo(string userId, UserDetailsViewModel editedModel);
        Task DeleteAccountById(string id);
        ICollection<UsersAllViewModel> GetUsersAcounts(string userId, int page, int itemsPerPage);
        UserDetailsViewModel GetAccountByUserId(string userId);
        int GetUserAcountsCount();
    }
}
