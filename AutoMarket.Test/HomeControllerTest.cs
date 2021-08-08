using System;
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
            var controller = MyMvc.Pipeline();
            //Act
           var call = controller.ShouldMap("/")
                .To<HomeController>(c => c.Index()).Which();
            //Assert
            call.ShouldReturn().View();
        }

        [Fact]
        public void HomeControllerPrivacyActionShouldReturnView()
        {
            //Arrange
            var controller = MyMvc.Pipeline();
            //Act
            var call = controller.ShouldMap("/Home/Privacy")
                .To<HomeController>(c => c.Privacy()).Which();
            //Assert
            call.ShouldReturn().View();
        }
        [Fact]
        public void HomeControllerErrorActionShouldReturnView()
        {
            //Arrange
            var controller = MyMvc.Pipeline();
            //Act
            var call = controller.ShouldMap("/Home/Error")
                .To<HomeController>(c => c.Error()).Which();
            //Assert
            call.ShouldReturn().View();
        }

        private static ICollection<int> GetOffersCount()
        {
            return new List<int> { 5, 7 };
        }
    }
}
