using System;
using System.Collections.Generic;
using AutoMarket.Data.Models;
using AutoMarket.Data.Models.Enum;
using AutoMarket.Models.Parts;
using AutoMarket.Models.Vehicles;
using AutoMarket.Models.Search;
using AutoMarket.Models.Offers;

namespace AutoMarket.Test.Moq
{
    public class GlobalMocking
    {
        public static ApplicationUser GetFakeUser()
        {
            return new ApplicationUser
            {
                Id = "TestId"
            };
        }

        public static VehicleOffer GetFakeVehicleOffer()
        {
            return new VehicleOffer
            {
                Id = "someFakeId",
                Location = "Sofia",
                Phone = "0896556633",
                Price = 10000,
                Vehicle = new Vehicle
                {
                    Make = "BMW",
                    Model = "e90",
                    BodyType = Enum.Parse<BodyType>("Sedan"),
                    HorsePower = 163,
                    Color = Enum.Parse<Color>("Red"),
                    EngineCapacity = 3,
                    EuroStandart = Enum.Parse<EuroStandart>("Euro_1"),
                    EngineType = Enum.Parse<EngineType>("Gasoline"),
                    Transmission = Enum.Parse<TransmissionType>("Manual"),
                    ManufacturingYear = 2005,
                    Мileage = 226000,
                }
            };
        }

        public static PartOffer GetFakePartOffer()
        {
            return new PartOffer
            {
                Id = "someFakeId",
                Location = "Sofia",
                Phone = "0896556633",
                Price = 10000,
                Title = "fakeTitle",
                VehicleType = Enum.Parse<VehicleCategory>("Automobile"),
                Description = "fakeDescription",
                Email = "fakeEmail@mail.bg",
                Part = new Part
                {
                    Name = "Clutch",
                    PartCategory = Enum.Parse<PartCategory>("Engine"),
                    Status = Enum.Parse<PartStatus>("New")
                }
            };
        }

        //// public static ListPartsAllViewModel GetFakePartsList()
        //  {
        //      var offers = new List<PartsAllViewModel>()
        //          {
        //              new PartsAllViewModel()
        //              {
        //                  Id = "fakeId1",
        //                  Title = "fakeTitle1",
        //                  Status = Enum.Parse<PartStatus>("New"),
        //                  Category = Enum.Parse<PartCategory>("Engine"),
        //                  Price = 100
        //              },
        //              new PartsAllViewModel()
        //              {
        //                  Id = "fakeId2",
        //                  Title = "fakeTitle2",
        //                  Status = Enum.Parse<PartStatus>("Used"),
        //                  Category = Enum.Parse<PartCategory>("Engine"),
        //                  Price = 100
        //              }
        //          };

        //return new ListPartsAllViewModel
        //{
        //    ItemsCount = 2,
        //    ItemsPerPage = 9,
        //    PageNumber = 1,
        //    Offers = offers
        //};
        //}

        public static CreatePartViewModel GetFakeModelToCreatePart()
        {
            return new CreatePartViewModel
            {
                Id = "someFakeId",
                Name = "fakeName",
                Phone = "08965544555",
                Title = "fakeTitle",
                VehicleType = Enum.Parse<VehicleCategory>("Automobile"),
                ApplicationUser = GetFakeUser(),
                Part = new Part
                {
                    Id = 1,
                    Name = "fakeNAme",
                    PartCategory = Enum.Parse<PartCategory>("Engine"),
                    Status = Enum.Parse<PartStatus>("New")
                }
            };
        }

        public static CreateVehicleOfferViewModel GetFakeModelToCreateVehicle()
        {
            return new CreateVehicleOfferViewModel
            {
                Id = "someFakeId",
                Location = "Sofia",
                Phone = "0896556633",
                Price = 10000,
                Make = "BMW",
                Model = "e90",
                BodyType = Enum.Parse<BodyType>("Sedan"),
                HorsePower = 163,
                Color = Enum.Parse<Color>("Red"),
                EngineCapacity = 3,
                EuroStandart = Enum.Parse<EuroStandart>("Euro_1"),
                EngineType = Enum.Parse<EngineType>("Gasoline"),
                Transmission = Enum.Parse<TransmissionType>("Manual"),
                ManufacturingYear = 2005,
                Мileage = 226000,
            };
        }

        public static PartOffer GetFakeModelToEditPart()
        {
            return new PartOffer
            {
                Id = "someFakeId",
                Location = "Sofia",
                Phone = "0896556633",
                Price = 10000,
                Title = "fakeTitle",
                VehicleType = Enum.Parse<VehicleCategory>("Truck"),
                Description = "fakeDescription",
                Email = "fakeEmail@mail.bg",
                Part = new Part
                {
                    Id = 1,
                    Name = "Clutch",
                    PartCategory = Enum.Parse<PartCategory>("Transmission"),
                    Status = Enum.Parse<PartStatus>("Used")
                },
                ApplicationUser = new ApplicationUser
                {
                    Id = "TestId"
                },
                ApplicationUserId = "TestId",
                PartId = 1
            };
        }
    }
}

