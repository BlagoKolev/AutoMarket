using System.Collections.Generic;
using AutoMarket.Models.Parts;


namespace AutoMarket.Services
{
    public interface IPartsService
    {
        DetailsPartsViewModel GetDetails(string offerId);
        void CreatePartOffer(CreatePartViewModel formModel, string imagePath, string userId);
        ICollection<PartsAllViewModel> GelAllPartOffers(int id, int itemsPerPage);
        int GetAllPartsOffersCount();
    }
}
