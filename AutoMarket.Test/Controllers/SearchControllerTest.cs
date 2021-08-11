using Xunit;
using MyTested.AspNetCore.Mvc;
using AutoMarket.Controllers;
using AutoMarket.Models.Search;
using AutoMarket.Test.Moq;

namespace AutoMarket.Test.Controllers
{
    public class SearchControllerTest
    {
        [Theory]
        [InlineData("BMW", "E90", 1)]
        public void AllShouldReturnViewWithModelAndHaveNoActionAttributes(string make, string vehicleModel, int id)
        {
            MyController<SearchController>
                .Instance(c => c.WithData(GlobalMocking.GetFakeVehicleOffer()))
                .Calling(c => c.All(make, vehicleModel, id))
                .ShouldHave()
                .NoActionAttributes()
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<SearchVehicleViewModel>());
        }

        [Theory]
        [InlineData("New", "Clutch", 1)]
        public void PartsShouldReturnViewWithModelAndHaveNoActionAttributes(string status, string keyword, int id)
        {
            MyController<SearchController>
                .Instance(c => c.WithData(GlobalMocking.GetFakePartOffer()))
                .Calling(c => c.Parts(status, keyword, id))
                .ShouldHave()
                .NoActionAttributes()
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<SearchPartViewModel>());
        }
    }
}
