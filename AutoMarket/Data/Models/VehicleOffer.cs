using AutoMarket.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models
{
    public class VehicleOffer 
    {
        public VehicleOffer()
        {
            this.Pictures = new List<VehiclePicture>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }
        public string Email { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int Price { get; set; }
        [MaxLength(30)]
        public string Location { get; set; }
        public bool IsDeleted { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public ICollection<VehiclePicture> Pictures { get; set; }

    }
}
