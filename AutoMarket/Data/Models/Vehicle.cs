using AutoMarket.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoMarket.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Make { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        public VehicleCategory VehicleCategory { get; set; }
        [Required]
        public BodyType BodyType { get; set; }
        [Required]
        public int ManufacturingYear { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal EngineCapacity { get; set; }
        public int HorsePower { get; set; }
        [Required]
        public EngineType EngineType { get; set; }
        [Required]
        public TransmissionType Transmission { get; set; }
        public int Мileage { get; set; }
        [Required]
        public Color Color { get; set; }
        [Required]
        public EuroStandart EuroStandart { get; set; }
    }
}
