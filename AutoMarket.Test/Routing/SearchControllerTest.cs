using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;

namespace AutoMarket.Test.Routing
{
    public class SearchControllerTest
    {
        [Fact]
        public void AllMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Search/All?make=null&vehicleModel=null&id=1")
                .To<SearchController>(c => c.All(null, null, 1));
        }

        [Fact]
        public void PartsMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Search/Parts?status=null&keyword=null&id=1")
                .To<SearchController>(c => c.Parts(null, null, 1));
        }
    }
}
