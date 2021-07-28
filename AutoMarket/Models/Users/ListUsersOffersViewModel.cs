using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Users
{
    public class ListUsersOffersViewModel : PagingViewModel
    {
       public ICollection<UsersOffersViewModel> Offers { get; set; }
    }
}
