using AutoMarket.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models
{
    public class PartOffer
    {
        public PartOffer()
        {
            this.Id ="Part" + Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.Pictures = new List<Image>();
        }

        [Key]
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(0,int.MaxValue)]
        public int Price { get; set; }

        [MaxLength(30)]
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public VehicleCategory VehicleType { get; set; }
        public int PartId { get; set; }
        public virtual Part Part { get; set; }
        public ICollection<Image> Pictures { get; set; }
    }
}
