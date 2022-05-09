using AutoMarket.Models;
using System.Collections.Generic;

namespace AutoMarket.Areas.Admin.Controllers
{
    public class ListUsersOffersViewModel : PagingViewModel
    {
       public ICollection<UsersOffersViewModel> Offers { get; set; }
    }
}
