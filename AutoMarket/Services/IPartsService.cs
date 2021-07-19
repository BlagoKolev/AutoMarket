using AutoMarket.Models.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IPartsService
    {
        ICollection<PartsAllViewModel> GelAllPartOffers(int id, int itemsPerPage);
        int GetAllPartsOffersCount();
    }
}
