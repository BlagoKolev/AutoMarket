using System.Linq;
using System.Collections.Generic;
using AutoMarket.Data;


namespace AutoMarket.Services
{
    public class DealersService : IDealersService
    {
        private readonly ApplicationDbContext db;
        public DealersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ICollection<string> GetAllDealers()
        {
            var dealers = this.db.ApplicationUsers
                .Where(x => x.IsDealer)
                .Select(x => x.Dealer.Name)
                .ToList();
            return dealers;
        }
    }
}
