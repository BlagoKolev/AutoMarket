using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


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

        public int? DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public bool IsDealer { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<PartOffer> PartOffers { get; set; }
        public virtual ICollection<VehicleOffer> VehicleOffers { get; set; }
    }
}
