using System.Collections.Generic;

namespace AutoMarket.Models.Users
{
    public class ListUsersOffersViewModel : PagingViewModel
    {
       public ICollection<UsersOffersViewModel> Offers { get; set; }
    }
}
