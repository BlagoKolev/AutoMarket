using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoMarket.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.PartOffers = new HashSet<PartOffer>();
            this.VehicleOffers = new HashSet<VehicleOffer>();
            this.RegistrationDate = DateTime.UtcNow;
        }

        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<PartOffer> PartOffers { get; set; }
        public virtual ICollection<VehicleOffer> VehicleOffers { get; set; }
    }
}
