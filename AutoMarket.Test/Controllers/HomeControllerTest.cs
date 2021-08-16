using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using System.Collections.Generic;

namespace AutoMarket.Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void HomeControllerIndexActionShouldReturnView()
        {
            //Arange  
            var controller = MyController<HomeController>.Instance();
            //Act
            var call = controller.Calling(c => c.Index());
            //Assert
            call.ShouldReturn().View();
        }

        [Fact]
        public void HomeControllerErrorActionShouldReturnView()
        {
            //Arrange
            var controller = MyController<HomeController>.Instance();
            //Act
            var call = controller.Calling(c => c.Error());
            //Assert
            call.ShouldReturn().View();
        }
    }
}
