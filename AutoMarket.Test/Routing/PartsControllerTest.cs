using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Models.Parts;

namespace AutoMarket.Test.Routing
{
    public class PartsControllerTest
    {
        [Fact]
        public void AllMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Parts/All?id=1")
                .To<PartsController>(c => c.All(1));
        }

        [Fact]
        public void CreateGetMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Parts/Create")
                .To<PartsController>(c => c.Create());
        }

        [Fact]
        public void CreatePostMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap(request => request
                .WithLocation("/Parts/Create")
                .WithMethod(HttpMethod.Post))
                .To<PartsController>(c => c.Create(With.Any<CreatePartViewModel>()));
        }

        [Fact]
        public void DetailsMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Parts/Details?offerId=someId")
                .To<PartsController>(c => c.Details("someId"));
        }
    }
}
