using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Models.Dealers;
using AutoMarket.Test.Moq;
using AutoMarket.Models.Offers;
using AutoMarket.Data.Models;

namespace AutoMarket.Test.Controllers
{
    public class DealersControllerTest
    {
        [Fact]
        public void AllShoudReturnViewWithModelIfUserIsLoggedInAndShouldHaveAuthorizeAttribute()
        {
            MyController<DealersController>
                .Instance()
                .WithUser()
                .WithData(GlobalMocking.GetFakeVehicleOffer())
                .Calling(c => c.All(null, 1))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<ListMyOffersViewModel>());
        }

        [Fact]
        public void BecomeDealerGetIsForRegisterUserOnly()
        {
            MyController<DealersController>
                .Instance(c => c.WithUser())
                .Calling(c => c.BecomeDealer())
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests());
        }

        [Theory]
        [InlineData("Admin")]
        [InlineData("Dealer")]
        public void BecomeDealersShouldRedirectIfUserIsAdminOrDealer(string role)
        {
            MyController<DealersController>
                .Instance(c => c.WithUser(u => u.InRole(role)))
                .Calling(c => c.BecomeDealer())
                .ShouldReturn()
                .Redirect();
        }

        [Fact]
        public void BecomeDealerShoudBeForAuthorizedUsersAndAlsoShouldReturnView()
        {
            MyController<DealersController>
                .Instance(c => c.WithUser().WithData(GlobalMocking.GetFakeUser()))
                .Calling(c => c.BecomeDealer())
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(c => c.WithModelOfType<BecomeDealerViewModel>());
        }

        [Fact]
        public void BecomeDealerPostIsForAuthorizedUsersOnlyAndReturnRedurect()
        {
            MyMvc.
            Controller<DealersController>()
                .Calling(c => c.BecomeDealer(With.Default<BecomeDealerViewModel>()))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForHttpMethod(HttpMethod.Post)
                .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .Redirect();
        }


    }
}
