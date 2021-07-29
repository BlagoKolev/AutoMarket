using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMarket.Models.Parts;


namespace AutoMarket.Services
{
    public interface IPartsService
    {
        DetailsPartsViewModel GetDetails(string offerId);
        Task CreatePartOffer(CreatePartViewModel formModel, string imagePath, string userId);
        ICollection<PartsAllViewModel> GelAllPartOffers(int id, int itemsPerPage);
        int GetAllPartsOffersCount();
    }
}
