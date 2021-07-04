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
            this.Pictures = new List<PartPicture>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        public string Email { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public VehicleCategory VehicleType { get; set; }
        public int PartId { get; set; }
        public virtual Part Part { get; set; }
        public ICollection<PartPicture> Pictures { get; set; }
    }
}
