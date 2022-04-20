namespace AutoMarket.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMarket.Data;
    using AutoMarket.Data.Models;
    using AutoMarket.Data.Models.Enum;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;



    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            //  MigrateDatabase(services);

            SeedAdministrator(services);
            CreateDealerRole(services);

            SeedDbVehicleOffers(services);
            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Admin"))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = "Admin" };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@automarket.com";
                    const string adminPassword = "admin";

                    var user = new ApplicationUser
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
        public static void CreateDealerRole(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Dealer"))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = "Dealer" };

                    await roleManager.CreateAsync(role);
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedDbVehicleOffers(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var admin = userManager.GetUsersInRoleAsync("Admin").GetAwaiter().GetResult()[0];

            if (data.Vehicles.Any())
            {
                return;
            }

            var bmwE90 = new Vehicle
            {
                Make = "BMW",
                Model = "E90",
                Color = Color.Black,
                BodyType = BodyType.Sedan,
                EngineType = EngineType.Diesel,
                EuroStandart = EuroStandart.Euro_5,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Automatic,
                ManufacturingYear = 2015,
                EngineCapacity = 3,
                HorsePower = 200,
                Мileage = 100000,
            };

            var bmwE90Arctic = new Vehicle
            {
                Make = "BMW",
                Model = "E90",
                Color = Color.Metallic,
                BodyType = BodyType.Sedan,
                EngineType = EngineType.Diesel,
                EuroStandart = EuroStandart.Euro_5,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Automatic,
                ManufacturingYear = 2005,
                EngineCapacity = 2,
                HorsePower = 163,
                Мileage = 220000
            };

            var MercedesCls500 = new Vehicle
            {
                Make = "Mercedes",
                Model = "Cls",
                Color = Color.Black,
                BodyType = BodyType.Sedan,
                EngineType = EngineType.Diesel,
                EuroStandart = EuroStandart.Euro_5,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Automatic,
                ManufacturingYear = 2015,
                EngineCapacity = 5,
                HorsePower = 350,
                Мileage = 200000
            };

            var AudiA6 = new Vehicle
            {
                Make = "Audi",
                Model = "A6",
                Color = Color.White,
                BodyType = BodyType.Wagon,
                EngineType = EngineType.Gasoline,
                EuroStandart = EuroStandart.Euro_6,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Automatic,
                ManufacturingYear = 2015,
                EngineCapacity = 3,
                HorsePower = 270,
                Мileage = 210000
            };

            var Hammer = new Vehicle
            {
                Make = "Hammer",
                Model = "H1",
                Color = Color.Yellow,
                BodyType = BodyType.SUV,
                EngineType = EngineType.Gasoline,
                EuroStandart = EuroStandart.Euro_3,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Manual,
                ManufacturingYear = 2010,
                EngineCapacity = 4,
                HorsePower = 270,
                Мileage = 110000
            };

            var RangeRover = new Vehicle
            {
                Make = "RangeRover",
                Model = "Range",
                Color = Color.White,
                BodyType = BodyType.SUV,
                EngineType = EngineType.Gasoline,
                EuroStandart = EuroStandart.Euro_4,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Manual,
                ManufacturingYear = 2018,
                EngineCapacity = 4,
                HorsePower = 250,
                Мileage = 130000
            };


            var Lada = new Vehicle
            {
                Make = "Lada",
                Model = "2103",
                Color = Color.Red,
                BodyType = BodyType.Sedan,
                EngineType = EngineType.Gasoline,
                EuroStandart = EuroStandart.Euro_1,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Manual,
                ManufacturingYear = 1986,
                EngineCapacity = 2,
                HorsePower = 75,
                Мileage = 230000
            };

            var Ferrari = new Vehicle
            {
                Make = "Ferrari",
                Model = "SF90",
                Color = Color.Red,
                BodyType = BodyType.Coupe,
                EngineType = EngineType.Gasoline,
                EuroStandart = EuroStandart.Euro_6,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Automatic,
                ManufacturingYear = 2019,
                EngineCapacity = 8,
                HorsePower = 1000,
                Мileage = 15000
            };

            var Porsche = new Vehicle
            {
                Make = "Porsche",
                Model = "Panamera",
                Color = Color.White,
                BodyType = BodyType.Coupe,
                EngineType = EngineType.Gasoline,
                EuroStandart = EuroStandart.Euro_6,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Automatic,
                ManufacturingYear = 2019,
                EngineCapacity = 8,
                HorsePower = 650,
                Мileage = 17000
            };

            var Honda = new Vehicle
            {
                Make = "Honda",
                Model = "Accord",
                Color = Color.Red,
                BodyType = BodyType.Sedan,
                EngineType = EngineType.Gasoline,
                EuroStandart = EuroStandart.Euro_6,
                VehicleCategory = VehicleCategory.Automobile,
                Transmission = TransmissionType.Automatic,
                ManufacturingYear = 2018,
                EngineCapacity = 3,
                HorsePower = 180,
                Мileage = 90000
            };
            //var vehicles = new Vehicle[] { bmwE90 };


            var bmwE90Offer = new VehicleOffer
            {
                Vehicle = bmwE90,
                VehicleId = bmwE90.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.Sofia,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 20000,
                ApplicationUser = admin,
            };

            var bmwE90ArcticOffer = new VehicleOffer
            {
                Vehicle = bmwE90Arctic,
                VehicleId = bmwE90Arctic.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.Sofia,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 8000,
                ApplicationUser = admin,
            };

            var MercedesCls500Offer = new VehicleOffer
            {
                Vehicle = MercedesCls500,
                VehicleId = MercedesCls500.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.Burgas,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 28000,
                ApplicationUser = admin,
            };

            var AudiA6Offer = new VehicleOffer
            {
                Vehicle = AudiA6,
                VehicleId = AudiA6.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.Varna,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 18000,
                ApplicationUser = admin,
            };

            var HammerOffer = new VehicleOffer
            {
                Vehicle = Hammer,
                VehicleId = Hammer.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.Rouse,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 10000,
                ApplicationUser = admin,
            };

            var RangeRoverOffer = new VehicleOffer
            {
                Vehicle = RangeRover,
                VehicleId = RangeRover.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.StaraZagora,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 10000,
                ApplicationUser = admin,
            };

            var LadaOffer = new VehicleOffer
            {
                Vehicle = Lada,
                VehicleId = Lada.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.StaraZagora,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 500,
                ApplicationUser = admin,
            };

            var FerrariOffer = new VehicleOffer
            {
                Vehicle = Ferrari,
                VehicleId = Ferrari.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.StaraZagora,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 100000,
                ApplicationUser = admin,
            };

            var PorscheOffer = new VehicleOffer
            {
                Vehicle = Porsche,
                VehicleId = Porsche.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.Sofia,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 100000,
                ApplicationUser = admin,
            };
            var HondaOffer = new VehicleOffer
            {
                Vehicle = Honda,
                VehicleId = Honda.Id,
                CreatedOn = DateTime.UtcNow,
                Email = GlobalConstants.Seed.TestEmail,
                Description = GlobalConstants.Seed.VehicleDescription,
                Location = GlobalConstants.Seed.City.Plovdiv,
                Phone = GlobalConstants.Seed.TestPhone,
                IsDeleted = false,
                Price = 10000,
                ApplicationUser = admin,
            };

            var seededOffers = new VehicleOffer[] { bmwE90Offer, bmwE90ArcticOffer, MercedesCls500Offer, AudiA6Offer, HammerOffer, RangeRoverOffer, LadaOffer, FerrariOffer, PorscheOffer, HondaOffer };

            //Add all seeded Offers to Database
            data.VehicleOffers.AddRange(seededOffers);

            var seedImages = new Image[]
            {
                new Image
                {
                    Id = "bmwBlack1",
                    Extension = "jpg",
                    VehicleOfferId = bmwE90Offer.Id,
                },
                 new Image
                {
                    Id = "bmwBlack2",
                    Extension = "jpg",
                    VehicleOfferId = bmwE90Offer.Id,
                },
                 new Image
                {
                    Id = "bmwBlack3",
                    Extension = "jpg",
                    VehicleOfferId = bmwE90Offer.Id,
                },
                new Image
                {
                    Id = "bmwArctic1",
                    Extension = "jpg",
                    VehicleOfferId = bmwE90ArcticOffer.Id,
                },
                new Image
                {
                    Id = "bmwArctic2",
                    Extension = "jpg",
                    VehicleOfferId = bmwE90ArcticOffer.Id,
                },
                new Image
                    {
                    Id = "MercedesCls5001",
                    Extension = "jpg",
                    VehicleOfferId = MercedesCls500Offer.Id,
                },
                new Image
                    {
                    Id = "MercedesCls5002",
                    Extension = "jpg",
                    VehicleOfferId = MercedesCls500Offer.Id,
                },
                new Image
                    {
                    Id = "AudiA61",
                    Extension = "jpg",
                    VehicleOfferId = AudiA6Offer.Id,
                },
                new Image
                    {
                    Id = "AudiA62",
                    Extension = "jpg",
                    VehicleOfferId = AudiA6Offer.Id,
                },
                new Image
                    {
                    Id = "AudiA63",
                    Extension = "jpg",
                    VehicleOfferId = AudiA6Offer.Id,
                },
                new Image
                    {
                    Id = "Hammer1",
                    Extension = "jpg",
                    VehicleOfferId = HammerOffer.Id,
                },
                new Image
                    {
                    Id = "Hammer2",
                    Extension = "jpg",
                    VehicleOfferId = HammerOffer.Id,
                },
                new Image
                    {
                    Id = "Hammer3",
                    Extension = "jpg",
                    VehicleOfferId = HammerOffer.Id,
                },
                new Image
                    {
                    Id = "RangeRover1",
                    Extension = "jpg",
                    VehicleOfferId = RangeRoverOffer.Id,
                },
                new Image
                    {
                    Id = "RangeRover2",
                    Extension = "jpg",
                    VehicleOfferId = RangeRoverOffer.Id,
                },
                new Image
                    {
                    Id = "RangeRover3",
                    Extension = "jpg",
                    VehicleOfferId = RangeRoverOffer.Id,
                },
                new Image
                    {
                    Id = "Lada1",
                    Extension = "jpg",
                    VehicleOfferId = LadaOffer.Id,
                },
                new Image
                    {
                    Id = "Ferrari1",
                    Extension = "jpg",
                    VehicleOfferId = FerrariOffer.Id,
                },
                new Image
                    {
                    Id = "Ferrari2",
                    Extension = "jpg",
                    VehicleOfferId = FerrariOffer.Id,
                },
                new Image
                    {
                    Id = "Ferrari3",
                    Extension = "jpg",
                    VehicleOfferId = FerrariOffer.Id,
                },
                new Image
                    {
                    Id = "Ferrari4",
                    Extension = "jpg",
                    VehicleOfferId = FerrariOffer.Id,
                },
                new Image
                    {
                    Id = "Ferrari5",
                    Extension = "jpg",
                    VehicleOfferId = FerrariOffer.Id,
                },
                new Image
                    {
                    Id = "Porsche1",
                    Extension = "jpg",
                    VehicleOfferId = PorscheOffer.Id,
                },
                new Image
                    {
                    Id = "Porsche2",
                    Extension = "jpg",
                    VehicleOfferId = PorscheOffer.Id,
                },
                new Image
                    {
                    Id = "Honda1",
                    Extension = "jpg",
                    VehicleOfferId = HondaOffer.Id,
                },
                new Image
                    {
                    Id = "Honda2",
                    Extension = "jpg",
                    VehicleOfferId = HondaOffer.Id,
                },
                new Image
                    {
                    Id = "Honda3",
                    Extension = "jpg",
                    VehicleOfferId = HondaOffer.Id,
                },
                new Image
                    {
                    Id = "Honda4",
                    Extension = "jpg",
                    VehicleOfferId = HondaOffer.Id,
                },
            };

            //Add all seeded Images to Database
            data.Images.AddRange(seedImages);

            data.SaveChanges();
        }
    }
}