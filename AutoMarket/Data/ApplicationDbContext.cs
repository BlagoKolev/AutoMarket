using AutoMarket.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartOffer> PartOffers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleOffer> VehicleOffers { get; set; }
        public DbSet<PartPicture> PartPictures { get; set; }
        public DbSet<VehiclePicture> VehiclePictures { get; set; }
    }
}
