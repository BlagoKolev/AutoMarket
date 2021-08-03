using System.Collections.Generic;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Dealers;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IDealersService
    {
        Task<bool> MakeUserDealer(string userId, string dealerName);
        bool IsDealerExist(string dealerName);
        BecomeDealerViewModel GetUserInfo(string userId);
        int GetOffersCount(string dealerName);
        ICollection<string> GetAllDealers();
        ICollection<MyOffersViewModel> GetDealersOffersByName(string dealerName, int id, int itemsPerPage);
    }
}
