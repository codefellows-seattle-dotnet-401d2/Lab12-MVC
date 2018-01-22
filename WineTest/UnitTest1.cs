using System;
using Xunit;
using DontWine.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WineTest
{
    public class UnitTest1
    {
        [Fact]
        public async void WineListPopulates()
        {
            var controller = new HomeController();

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Wine.GetWineList();
                viewResult.ViewData.Model);
            Assert.Equal(1000, model.Count);
        }
        
        [Fact]
        public async void HomeControllerIndexReturnsSomething()
        {
            var controller = new HomeController();

            var result = controller.Index();

            var ViewResult = Assert.IsType<ViewResult>(result);
            var model = Wine.GetWineList();
        }
    }
}
