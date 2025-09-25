using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder.Models;
using CoffeeOrder.Pricing;
using CoffeeOrder.Promotions;

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class PromotionHelperTests
    {

        [TestMethod]
        public void CreateBeverage_CalculatePromotion_Expected_20Dollars()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge", // $12
                                "Hot",
                                "Cow", // $0
                                null, // $0
                                3,   // $1x3
                                ["Caramel", null], // $1.25
                                ["Nuts", "Flakes", "Sprinkles", "Glass", "Bark"], // $0.75x5
                                true
            );

            string promo = "SUMMER2025"; // 20% discount

            double expected = 16.00;

            // Act
            var result = PromotionHelper.ApplyPromotion(beverage, promo);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateBeverage_CalculateFakePromotion_Expected_20Dollars()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge", // $12
                                "Hot",
                                "Cow", // $0
                                null, // $0
                                3,   // $1x3
                                ["Caramel", null], // $1.25
                                ["Nuts", "Flakes", "Sprinkles", "Glass", "Bark"], // $0.75x5
                                true
            );

            string promo = "SAVEMEMONEY"; // Fake discount - nothing applied

            double expected = 20.00;

            // Act
            var result = PromotionHelper.ApplyPromotion(beverage, promo);

            // Assert
            Assert.AreEqual(expected, result);



        }
    }
}
