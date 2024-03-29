﻿using System;
using AutoMarket.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        [Range(1900,2021)]
        public int ManufacturingYear { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal EngineCapacity { get; set; }

        [Range(0,int.MaxValue)]
        public int HorsePower { get; set; }

        [Required]
        public EngineType EngineType { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        [Range(0, 1500000)]
        public int Мileage { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        public EuroStandart EuroStandart { get; set; }
    }
}
