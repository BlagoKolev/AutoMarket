﻿using AutoMarket.Data.Models.Enum;
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
            this.Pictures = new List<Image>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(500)]
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
