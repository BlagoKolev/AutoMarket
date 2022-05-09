using System.Collections.Generic;

namespace AutoMarket.Areas.Admin.Controllers
{
    public class ListUsersAllViewModel 
    {
        public ICollection<UsersAllViewModel> Users { get; set; }
    }
}
