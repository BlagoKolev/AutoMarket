using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;

namespace AutoMarket.Test.Pipeline
{
   public class HomeControllerTest
    {
        [Fact]
        public void IndexActionPipelineTest()
        {
            MyMvc
                .Pipeline()
                .ShouldMap("/Home/Index")
                .To<HomeController>(c => c.Index())
                .Which()
                .ShouldReturn()
                .View();
        }
        [Fact]
        public void PrivacyActionPipelineTest()
        {
            MyMvc
                .Pipeline()
                .ShouldMap("/Home/Privacy")
                .To<HomeController>(c => c.Privacy())
                .Which()
                .ShouldReturn()
                .View();
        }
        [Fact]
        public void ErrorActionPipelineTest()
        {
            MyMvc
                .Pipeline()
                .ShouldMap("/Home/Error")
                .To<HomeController>(c => c.Error())
                .Which()
                .ShouldReturn()
                .View();
        }
    }
}
