using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;

namespace AutoMarket.Test.Routing
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexActionShoudMachSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Home/Index")
                .To<HomeController>(c => c.Index());
        }

        [Fact]
        public void ErrorActionShouldMachSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Home/Error")
                .To<HomeController>(c => c.Error());
        }
    }
}
