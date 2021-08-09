using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Models.Offers;
using AutoMarket.Models.Dealers;

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

        [Fact]
        public void AllShoudReturnViewWithModelIfUserIsLoggedIn()
        {
            MyController<DealersController>
                .Instance(c => c.WithUser())
                .Calling(c => c.All(null, 1))
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

        //[Fact]
        //public void BecomeDealerShoudBeForAuthorizedUsersAndAlsoShouldReturnView()
        //{
        //    MyController<DealersController>
        //        .Instance(c => c.WithUser())
        //        .Calling(c => c.BecomeDealer(new BecomeDealerViewModel
        //        {
        //            DealerName = "dealerName",
        //            UserEmail = "dealer@mail.bg",
        //            CardHolder = "John Dow",
        //            CardExpiredMonth = 12,
        //            CardExpiredYear = 2022,
        //            CardNumber = "0000-0000-0000-0000",
        //            CVV = 123
        //        }))
        //        .ShouldHave()
        //        .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
        //        .AndAlso()
        //        .ShouldReturn()
        //        .View(c => c.WithModelOfType<BecomeDealerViewModel>());
        //}

        [Fact]
        public void BecomeDealerPostIsForAuthorizedUsersOnly()
        {
            MyController<DealersController>
                .Instance(c=>c.WithUser())
                .Calling(c => c.BecomeDealer())
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests().RestrictingForHttpMethod(HttpMethod.Post));
                
        }
    }
}
