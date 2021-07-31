using System.Collections.Generic;


namespace AutoMarket.Services
{
    public interface IDealersService
    {
        ICollection<string> GetAllDealers();
    }
}
