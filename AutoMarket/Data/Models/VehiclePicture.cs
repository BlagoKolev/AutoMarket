using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Data.Models
{
    public class VehiclePicture
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int VehicleOfferId { get; set; }
        public virtual VehicleOffer VehicleOffer { get; set; }
    }
}
