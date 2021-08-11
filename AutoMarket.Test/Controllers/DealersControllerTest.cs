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
        public void AllShoudReturnRedirectIfUserIsNotLoggedIn()
        {
            MyController<DealersController>
                .Instance()
                .Calling(c => c.All("someName", 1))
                .ShouldReturn()
                .Redirect();
        }

        //[Fact]
        //public void AllShoudReturnViewWithModelIfUserIsLoggedIn()
        //{
        //    MyController<DealersController>
        //        .Instance()
        //        .WithUser()
        //        .WithData(GlobalMocking.GetFakeVehicleOffer().ApplicationUser.UserName = "TestUser")
        //        .Calling(c => c.All(null, 1))
        //        .ShouldReturn()
        //        .View(view => view.WithModelOfType<ListMyOffersViewModel>());
        //}

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
