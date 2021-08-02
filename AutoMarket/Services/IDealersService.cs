using AutoMarket.Models.Offers;
using System.Collections.Generic;


namespace AutoMarket.Services
{
    public interface IDealersService
    {
        int GetOffersCount(string dealerName);
        ICollection<string> GetAllDealers();
        ICollection<MyOffersViewModel> GetDealersOffersByName(string dealerName, int id, int itemsPerPage);
    }
}
