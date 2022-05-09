using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Areas.Admin.Controllers;

namespace AutoMarket.Test.Routing
{
    public class UsersControllerTest
    {
        [Fact]
        public void AllMustMatchSpecificValue()
        {
            MyRouting
                .Configuration()
                .ShouldMap("Users/All?userId=someId&id=1")
                .To<UsersController>(c=>c.All("someId",1));
        }

        [Fact]
        public void DetailsMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Users/Details?userId=someId")
                .To<UsersController>(c => c.Details("someId"));
        }

        [Fact]
        public void AccountsMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Users/Accounts?id=1")
                .To<UsersController>(c => c.Accounts(1));
        }

        [Fact]
        public void DeleteMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Users/Delete?userId=someId")
                .To<UsersController>(c=>c.Delete("someId"));
        }

        [Fact]
        public void EditGetMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Users/Edit?userId=someId")
                .To<UsersController>(c=>c.Edit("someId"));
        }

        [Fact]
        public void EditPostMustMatchSpecificRoute()
        {
            MyRouting
                .Configuration()
                .ShouldMap(request => request
                .WithLocation("/Users/Edit?userId=someId")
                .WithMethod(HttpMethod.Post))
                .To<UsersController>(c => c.Edit(With.Any<UserDetailsViewModel>(),"someId"));
        }
    }
}
