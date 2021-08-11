﻿using System;
using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Models.Offers;
using AutoMarket.Data.Models.Enum;
using AutoMarket.Data.Models;
using AutoMarket.Models.Parts;
using System.Linq;

namespace AutoMarket.Test.Controllers
{
    public class OffersControllerTest
    {
        [Theory]
        [InlineData(1)]
        public void AllShouldReturnViewWithCorrectModelAndHasAuthorizeAttribute(int id)
        {
            MyMvc
                .Controller<OffersController>()
                .Calling(c => c.All(id))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<ListMyOffersViewModel>());
        }

        [Theory]
        [InlineData("someFakeId")]
        public void VehicleDetailsShouldReturnViewWithCorrectModelAndHasAuthorizeAttribute(string offerId)
        {
            MyController<OffersController>
            .Instance(c => c.WithData(GetFakeVehicleOffer()))
            .Calling(c => c.VehicleDetails(offerId))
            .ShouldHave()
            .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(view => view.WithModelOfType<DetailsVehicleOfferViewModel>());
        }

        [Theory]
        [InlineData("someFakeId")]
        public void EditVehicleGetShouldReturnViewWithCorrectModelAndShouldHaveAuthorizeAttribute(string offerId)
        {
            MyController<OffersController>
            .Instance(c => c.WithData(GetFakeVehicleOffer()))
            .Calling(c => c.EditVehicle(offerId))
            .ShouldHave()
            .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(view => view.WithModelOfType<EditVehicleOfferViewModel>());
        }

        [Theory]
        [InlineData("someFakeId")]
        public void EditVehicleGetShouldReturnRedirectIfModelStateIsNotValid(string offerId)
        {
            MyController<OffersController>
                .Instance()
                .WithSetup(controller => controller.ModelState.AddModelError("TestError", "TestErrorMsg"))
                .Calling(x => x.EditVehicle(offerId))
                .ShouldReturn()
                .RedirectToAction("Edit");
        }

        [Theory]
        [InlineData("someFakeId")]
        public void EditVehiclePostShouldReturnRedirectAndShouldHaveAuthorizeAndPostAttribute(string offerId)
        {

            MyController<OffersController>
            .Instance(c => c.WithData(GetFakeVehicleOffer()))
            .Calling(c => c.EditVehicle(offerId, With.Default<EditVehicleOfferViewModel>()))
            .ShouldHave()
            .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests().RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("VehicleDetails");
        }

        [Theory]
        [InlineData("someFakeId")]
        public void EditVehiclePostShouldReturnViewIfModelStateIsNotValid(string offerId)
        {
            MyController<OffersController>
              .Instance()
              .WithSetup(controller => controller.ModelState.AddModelError("TestError", "TestErrorMsg"))
              .Calling(c => c.EditVehicle(offerId, With.Default<EditVehicleOfferViewModel>()))
              .ShouldReturn()
              .View(view => view.WithModelOfType<EditVehicleOfferViewModel>());
        }

        [Theory]
        [InlineData("someFakeId")]
        public void PartDetailsShouldReturnViewWithCorrectModelAndHaveAuthorizeAttribute(string offerId)
        {
            MyController<OffersController>
                .Instance(c => c.WithData(GetFakePartOffer()))
                .Calling(c => c.PartDetails(offerId))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<PartDetailsViewModel>());
        }

        [Theory]
        [InlineData("someFakeId")]
        public void EditPartGetShouldReturnViewWithCorrectModelAndShouldHaveAuthorizeAttribute(string offerId)
        {
            MyController<OffersController>
                .Instance(c => c.WithData(GetFakePartOffer()))
                .Calling(c => c.EditPart(offerId))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<EditPartOfferViewModel>());
        }

        //[Theory]
        //[InlineData("someFakeId")]
        //public void EditPartPostShouldHaveAuthorizeAttributeAndShouldReturnRedirectToAction(string offerId)
        //{
        //    MyController<OffersController>
        //        .Instance(c => c.WithData(GetFakePartOffer()))
        //        .Calling(c => c.EditPart(offerId, With.Default<EditPartOfferViewModel>()))
        //        .ShouldHave()
        //        .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests()
        //        .RestrictingForHttpMethod(HttpMethod.Post))
        //        .AndAlso()
        //        .ShouldReturn()
        //        .RedirectToAction("PartDetails");
        //}

        [Theory]
        [InlineData("someFakeId")]
        public void EditPartPostShouldReturnViewIfModelstateIsNotValid(string offerId)
        {
            MyController<OffersController>
                .Instance()
                .WithSetup(controller => controller.ModelState.AddModelError("TestError", "TestErrorMsg"))
                .Calling(c => c.EditPart(offerId, With.Default<EditPartOfferViewModel>()))
                .ShouldReturn()
                .View(view => view.WithModelOfType<EditPartOfferViewModel>());
        }

        [Theory]
        [InlineData("someFakeId")]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldRedirectToAction(string offerId)
        {
            MyController<OffersController>
                .Instance(c => c.WithData(GetFakePartOffer()))
                .Calling(c => c.Delete(offerId))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");
        }

        private static VehicleOffer GetFakeVehicleOffer()
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

        private static PartOffer GetFakePartOffer()
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
    }
}