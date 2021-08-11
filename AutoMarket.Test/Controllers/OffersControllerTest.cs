using System;
using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Models.Offers;
using AutoMarket.Data.Models.Enum;
using AutoMarket.Data.Models;
using AutoMarket.Models.Parts;
using System.Linq;
using AutoMarket.Test.Moq;

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
            .Instance(c => c.WithData(GlobalMocking.GetFakeVehicleOffer()))
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
            .Instance(c => c.WithData(GlobalMocking.GetFakeVehicleOffer()))
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
            .Instance(c => c.WithData(GlobalMocking.GetFakeVehicleOffer()))
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
                .Instance(c => c.WithData(GlobalMocking.GetFakePartOffer()))
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
                .Instance(c => c.WithData(GlobalMocking.GetFakePartOffer()))
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
                .Instance(c => c.WithData(GlobalMocking.GetFakePartOffer()))
                .Calling(c => c.Delete(offerId))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");
        }

    }
}
