using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Models.Offers;

namespace AutoMarket.Test.Routing
{
    public class VehiclesControllerTest
    {
        [Fact]
        public void AllMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Vehicles/All?id=1")
                .To<VehiclesController>(c => c.All(1));
        }

        [Fact]
        public void CreateGetMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Vehicles/Create")
                .To<VehiclesController>(c => c.Create());
        }

        [Fact]
        public void CreatePostMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap(request => request
                .WithLocation("/Vehicles/Create")
                .WithMethod(HttpMethod.Post))
                .To<VehiclesController>(c => c.Create(With.Any<CreateVehicleOfferViewModel>()));
        }

        [Fact]
        public void DetailsMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Vehicles/Details?offerId=someId")
                .To<VehiclesController>(c => c.Details("someId"));
        }
    }
}
