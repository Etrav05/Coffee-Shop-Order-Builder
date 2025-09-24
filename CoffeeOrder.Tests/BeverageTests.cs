using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder.Models;

namespace CoffeeOrder.Tests
{
    [TestClass]   // Mark this class as a test container
    public class BeverageTests
    {
        [TestMethod]   // Mark this method as an individual test
        public void CreateBeverage_WithName_SetsNameCorrectly()
        {
            // Arrange
            var beverage = new Beverage("London Fog"); // create a new beverage with the name "London Fog"
            var expected = "London Fog";              // define the expected value

            // Act
            var result = beverage.Name;            // define the actual result

            // Assert
            Assert.AreEqual(expected, result);  // check if the expected and result were the same
        }
    }
}