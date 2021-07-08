using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models
{
    public class PartPicture
    {
        public PartPicture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }
        //public string Name { get; set; }
        public byte[] Image { get; set; }
        public int PartOfferId { get; set; }
        public virtual PartOffer PartOffer { get; set; }
        //public string Extension { get; set; }
       // public DateTime CreatedOn { get; set; }
    }
}
