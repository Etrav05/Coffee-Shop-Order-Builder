using CoffeeOrder.Models;
using CoffeeOrder.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// line items
// discounts
// totals
// and warnings 

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class ReceiptFormatterTests
    {

        [TestMethod]
        public void CreateBeverage_CalculatePricing_Classify_FormateData()
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

            var expected = " 1x London Fog, Cow milk, Caramel, Nuts, Flakes, Sprinkles, Glass, Bark" // Line items
                         + " No discount applied " // Discounts
                         + " $20 "                // Total
                         + " Contains Nuts ";    // Warnings

            // Act
            var result = PricingCalculator.PricingCalculation(beverage);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}