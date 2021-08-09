using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Models.Offers;

namespace AutoMarket.Test.Routing
{
    public class OffersControllerTest
    {
        [Fact]
        public void AllMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Offers/All?id=1")
                .To<OffersController>(c => c.All(1));
        }
        [Fact]
        public void VehicleDetailsShouldMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Offers/VehicleDetails?offerId=randomId")
                .To<OffersController>(c => c.VehicleDetails("randomId"));
        }

        [Fact]
        public void PartDetailsShouldMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("Offers/PartDetails?offerId=someId")
                .To<OffersController>(c => c.PartDetails("someId"));
        }

        [Theory]
        [InlineData("someId")]
        public void EditVehicleGetShouldMatchSpecificRoute(string offerId)
        {
            MyRouting
                .Configuration()
                .ShouldMap($"/Offers/EditVehicle?offerId={offerId}")
                .To<OffersController>(c => c.EditVehicle(offerId));
        }

        [Theory]
        [InlineData("someId")]
        public void EditVehiclePostShouldMatchSpecificRoute(string offerId)
        {
            MyRouting
                .Configuration()
                .ShouldMap(request => request
                .WithLocation($"/Offers/EditVehicle?offerId={offerId}")
                .WithMethod(HttpMethod.Post))
                .To<OffersController>(c => c.EditVehicle(offerId, With.Any<EditVehicleOfferViewModel>()));
        }

        [Theory]
        [InlineData("someId")]
        public void EditPartGetShouldMatchSpecificRoute(string offerId)
        {
            MyRouting
               .Configuration()
               .ShouldMap($"/Offers/EditPart?offerId={offerId}")
               .To<OffersController>(c => c.EditPart(offerId));
        }

        [Theory]
        [InlineData("someId")]
        public void EditPartPostShouldMatchSpecificRoute(string offerId)
        {
            MyRouting
                .Configuration()
                .ShouldMap(request => request
                .WithLocation($"/Offers/EditPart?offerId={offerId}")
                .WithMethod(HttpMethod.Post))
                .To<OffersController>(c => c.EditPart(offerId, With.Any<EditPartOfferViewModel>()));
        }

        [Fact]
        public void DeletePartShouldMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Offers/Delete?offerId=someId")
                .To<OffersController>(c => c.Delete("someId"));
        }
       
    }
}
