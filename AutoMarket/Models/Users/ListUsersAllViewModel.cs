using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models.Users
{
    public class ListUsersAllViewModel : PagingViewModel
    {
        public ICollection<UsersAllViewModel> Users { get; set; }
    }
}
