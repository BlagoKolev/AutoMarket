using AutoMarket.Data;
using AutoMarket.Models.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public class PartsService : IPartsService
    {
        private readonly ApplicationDbContext db;
        public PartsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ICollection<PartsAllViewModel> GelAllPartOffers(int id, int itemsPerPage)
        {
            var allPartOffers = this.db.PartOffers
                .Where(x => x.IsDeleted == false)
                .Select(x => new PartsAllViewModel
                {
                    Id = x.Id,
                    Name = x.Part.Name,
                    Category = x.Part.PartCategory,
                    Status = x.Part.Status,
                    Price = x.Price,
                    Image = "/images/parts" + x.Pictures.FirstOrDefault().Id + '.' + x.Pictures.FirstOrDefault().Extension
                })
                .ToList();
            return allPartOffers;
        }

        public int GetAllPartsOffersCount()
        {
            var partOffersCount = this.db.PartOffers
                .Where(x => x.IsDeleted == false)
                .Count();
            return partOffersCount;
        }
    }
}
