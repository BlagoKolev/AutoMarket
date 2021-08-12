using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Test.Moq;
using AutoMarket.Models.Vehicles;
using AutoMarket.Models.Offers;

namespace AutoMarket.Test.Controllers
{
    public class VehicleControllerTest
    {
        [Fact]
        public void AllShoudReturnViewWithCorrectModel()
        {
            MyController<VehiclesController>
                .Instance(c => c.WithData(GlobalMocking.GetFakeVehicleOffer()))
                .Calling(c => c.All(1))
                .ShouldReturn()
                .View(view => view.WithModelOfType<ListAllVehicleViewModel>());
        }

        [Fact]
        public void CreateGetShouldReturnViewAndAlsoShouldHaveAuthorizeAttribute()
        {
            MyController<VehiclesController>
                .Instance()
                .Calling(c => c.Create())
                .ShouldHave()
                .ActionAttributes(c => c.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();
        }

        [Fact]
        public void CreatePostShouldRedirectToActionAndShouldHaveAuthorizeAndPostAttribute()
        {
            MyController<VehiclesController>
                .Instance()
                .Calling(c => c.Create(GlobalMocking.GetFakeModelToCreateVehicle()))
                .ShouldHave()
                .ActionAttributes(c => c.RestrictingForAuthorizedRequests()
                .RestrictingForHttpMethod(HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");
        }

        [Fact]
        public void CreatePostShouldRedirectToSameActionIfModelStateIsNotValid()
        {
            MyController<VehiclesController>
                .Instance()
                .WithSetup(c => c.ModelState.AddModelError("TestError", "TestErrorMsg"))
                .Calling(c => c.Create(With.Default<CreateVehicleOfferViewModel>()))
                .ShouldReturn()
                .Redirect();
        }
        [Theory]
        [InlineData("someFakeId")]
        public void DetailsShouldReturnViewWithCorrectModel(string offerId)
        {
            MyController<VehiclesController>
                .Instance(c => c.WithData(GlobalMocking.GetFakeVehicleOffer()))
                .Calling(c => c.Details(offerId))
                .ShouldHave()
                .NoActionAttributes()
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<DetailsOfferViewModel>());
        }

        [Theory]
        [InlineData("someFakeId")]
        public void DetailsShouldReturnNotFoundIfModelIsNull(string offerId)
        {
            MyController<VehiclesController>
                .Instance()
                .Calling(c => c.Details(offerId))
                .ShouldReturn()
                .NotFound();
        }
    }
}
