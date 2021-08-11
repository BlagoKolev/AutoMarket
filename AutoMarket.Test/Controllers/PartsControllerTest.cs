using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Test.Moq;
using AutoMarket.Models.Parts;

namespace AutoMarket.Test.Controllers
{
    public class PartsControllerTest
    {
        [Fact]
        public void AllShoudReturnViewWithCorrectModel()
        {
            MyController<PartsController>
                .Instance(c => c.WithData(GlobalMocking.GetFakePartOffer()))
                .Calling(c => c.All(1))
                .ShouldReturn()
                .View(view => view.WithModelOfType<ListPartsAllViewModel>());
        }

        [Fact]
        public void CreateGetShouldReturnViewAndAlsoShouldHaveAuthorizeAttribute()
        {
            MyController<PartsController>
                .Instance()
                .Calling(c => c.Create())
                .ShouldHave()
                .ActionAttributes(c => c.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();
        }

        [Fact]
        public void CreatePostShouldRedirectAndShouldHaveAuthorizeAndPostAttribute()
        {
            MyController<PartsController>
                .Instance()
                .Calling(c => c.Create(GlobalMocking.GetFakeModelToCreatePart()))
                .ShouldHave()
                .ActionAttributes(c => c.RestrictingForAuthorizedRequests()
                .RestrictingForHttpMethod(HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .Redirect("/Offers/All");
        }

        [Fact]
        public void CreatePostShouldRedirectToSameActionIfModelStateIsNotValid()
        {
            MyController<PartsController>
                .Instance()
                .WithSetup(c => c.ModelState.AddModelError("TestError", "TestErrorMsg"))
                .Calling(c => c.Create(With.Default<CreatePartViewModel>()))
                .ShouldReturn()
                .Redirect();
        }

        [Theory]
        [InlineData("someFakeId")]
        public void DetailsShouldReturnViewWithCorrectModel(string offerId)
        {
            MyController<PartsController>
                .Instance(c=>c.WithData(GlobalMocking.GetFakePartOffer()))
                .Calling(c => c.Details(offerId))
                .ShouldHave()
                .NoActionAttributes()
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<DetailsPartsViewModel>());
        }

        [Theory]
        [InlineData("someFakeId")]
        public void DetailsShouldReturnNotFoundIfModelIsNull(string offerId)
        {
            MyController<PartsController>
                .Instance()
                .Calling(c => c.Details(offerId))
                .ShouldReturn()
                .NotFound();
        }

    }
}
