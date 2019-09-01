using System;
using Xunit;
using MVC.Models;
using System.Collections.Generic;
using MVC.Controllers;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        Wine test = new Wine();


        [Fact]
        public void TestPoints()
        {
            string testPoints = "90";
            test.Points = testPoints; // testing set

            Assert.Equal(testPoints, test.Points); // testing get
        }

        [Fact]
        public void TestPrice()
        {
            string testPrice = "$65";
            test.Price = testPrice; // testing set

            Assert.Equal(testPrice, test.Price); // testing get
        }

        [Fact]
        public void TestCountry()
        {
            string testCountry = "90";
            test.Country = testCountry; // testing set

            Assert.Equal(testCountry, test.Country); // testing get
        }

        [Fact]
        public void TestDescription()
        {
            string testDescription = "90";
            test.Description = testDescription; // testing set

            Assert.Equal(testDescription, test.Description); // testing get
        }

        [Fact]
        public void TestWinery()
        {
            string testWinery = "90";
            test.Winery = testWinery; // testing set

            Assert.Equal(testWinery, test.Winery); // testing get
        }
    }
}
