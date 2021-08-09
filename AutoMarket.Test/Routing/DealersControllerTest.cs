using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using System.Linq;
using AutoMarket.Models.Dealers;

namespace AutoMarket.Test.Routing
{
    public class DealersControllerTest
    {
        [Fact]
        public void AllActionShoudMatchSpecificRoute()
        {
            MyRouting
            .Configuration()
            .ShouldMap("Dealers/All?id=1")
            .To<DealersController>(c => c.All(null, 1));
        }

        [Fact]
        public void GetBecomeDealerShouldMatchRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Dealers/BecomeDealer")
                .To<DealersController>(c => c.BecomeDealer());
        }

        [Fact]
        public void PostBecomeDealerShouldMatchRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap(request => request
                .WithPath("/Dealers/BecomeDealer")
                .WithMethod(HttpMethod.Post))
                .To<DealersController>(c => c.BecomeDealer(With.Any<BecomeDealerViewModel>()));
        }

    }
}
