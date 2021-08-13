using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Data.Models
{
    public class VehicleOffer 
    {
        public VehicleOffer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.Pictures = new List<Image>();
        }
        [Key]
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int Price { get; set; }

        [MaxLength(30)]
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public ICollection<Image> Pictures { get; set; }

    }
}
