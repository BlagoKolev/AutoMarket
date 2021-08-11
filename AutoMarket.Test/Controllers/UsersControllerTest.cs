using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Test.Moq;
using AutoMarket.Models.Users;
using AutoMarket.Models.Offers;
using AutoMarket.Data.Models;

namespace AutoMarket.Test.Controllers
{
    public class UsersControllerTest
    {
        [Theory]
        [InlineData("TestId")]
        public void EditShouldBeForAdminOnlyAndHaveAuthorizeAttribute(string id)
        {
            MyController<UsersController>
                .Instance(c => c.WithData(GlobalMocking.GetFakeUser()))
                .Calling(c => c.Edit(id))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<UserDetailsViewModel>());
        }

        [Theory]
        [InlineData("TestId")]
        public void EditPostShouldHaveAuthorizeAndPostAttributeAndShouldReturnRedirectAndIsForAdminOnly(string id)
        {
            MyController<UsersController>
                .Instance(c => c.WithData(GlobalMocking.GetFakeUser()))
                .Calling(c => c.Edit(With.Default<UserDetailsViewModel>(), id))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests()
                .RestrictingForHttpMethod(HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .Redirect();
        }

        [Theory]
        [InlineData("TestId", 1)]
        public void AllShouldReturnViewWithModelAndShouldHaveAuthorizeAttribute(string userId, int pageNumber)
        {
            MyController<UsersController>
                .Instance(c => c.WithData(GlobalMocking.GetFakeVehicleOffer()))
                .Calling(c => c.All(userId, pageNumber))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<ListMyOffersViewModel>());
        }

        [Theory]
        [InlineData("TestId")]
        public void DetailsShouldReturnViewWithModelAndShouldHaveAuthorizeAttribute(string userId)
        {
            MyController<UsersController>
                .Instance(c=>c.WithData(GlobalMocking.GetFakeUser()))
                .Calling(c => c.Details(userId))
                .ShouldHave()
                .ActionAttributes(x => x.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<UserDetailsViewModel>());
        }

        [Theory]
        [InlineData(1)]
        public void AccountsShouldReturnViewWithModelAndHaveAuthorizeAttribute(int pageNumber)
        {
            MyController<UsersController>
                .Instance(c=>c.WithData(GlobalMocking.GetFakeUser())
                .WithUser(x=>x.InRole("Admin")
                .WithIdentity(x=>x.WithIdentifier("fakeAdmin"))
                .WithUsername("Admin@automarket.com")))
                .Calling(c => c.Accounts(pageNumber))
                .ShouldHave()
                .ActionAttributes(c => c.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<ListUsersAllViewModel>());
        }

        [Theory]
        [InlineData("TestId")]
        public void DeleteShouldHaveAuthorizedAttributeAndShouldRedirectToAction(string userId)
        {
            MyController<UsersController>
                .Instance(c => c.WithData(GlobalMocking.GetFakeUser()))
                .Calling(c => c.Delete(userId))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Accounts");
        }
    }
}
