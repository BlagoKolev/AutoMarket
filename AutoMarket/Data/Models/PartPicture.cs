using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models
{
    public class PartPicture
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int PartOfferId { get; set; }
        public virtual PartOffer PartOffer { get; set; }
    }
}
