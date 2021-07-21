using AutoMarket.Models.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IPartsService
    {
        DetailsPartsViewModel GetDetails(string offerId);
        int getUsersPartOffersCount(string userId);
        ICollection<MyPartsViewModel> GetUsersParts(string userId, int id, int itemsPerPage);
        void CreatePartOffer(CreatePartViewModel formModel,string imagePath, string userId);
        ICollection<PartsAllViewModel> GelAllPartOffers(int id, int itemsPerPage);
        int GetAllPartsOffersCount();
    }
}
