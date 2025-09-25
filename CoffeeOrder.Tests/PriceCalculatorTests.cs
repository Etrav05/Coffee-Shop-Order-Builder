using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder.Models;
using CoffeeOrder.Pricing;  

/*
    public string? BaseDrink { get; }   // Get the name of the base drink
        Not factored in

    public string? Size { get; }        // Get the size (Small - Medium - Large - XLarge)
        Small  = $7
        Medium = $9
        Large  = $10.50
        XLarge = $12

    public string? Temp { get; }        // Get type of temp (Hot or Iced)
        Not factored in

    public string? Milk { get; }        // Get type of milk (Cow - Goat - Alpaca - Special)
        Cow     = $0
        Goat    = $0.25
        Alpaca  = $0.50
        Special = $1

    public string? PlantMilk { get; }   // Get type of plant based milk (Oat - Almond - Walnut)
        Oat    = $0.50
        Almond = $0.50
        Walnut = $0.75

    public int Shots { get; }           // Get number of shots of expresso (0 - 4)
        Shot = $1/each (max 4)

    public string[] Syrups { get; }     // Get list of syrup flavours (Chocolate - Caramel - Strawberry - Vanilla - Unicorn) (0 - 5)
        All     = $1.25 (max 5)
        Unicorn = $2.50

    public string[] Toppings { get; }   // Get list of toppings (0 - many)
        Toppings = $0.75/each

    public bool IsDecaf { get; }        // Flag for decaf

*/

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class PriceCalculatorTests
    {

        [TestMethod]
        public void CreateBeverage_CalculatePricing_Expected_20Dollars()
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

            double expected = 20.00;

            // Act
            var result = PricingCalculator.PricingCalculation(beverage);

            // Assert
            Assert.AreEqual(expected, result);
                          
        }

        [TestMethod]
        public void CreateBeverage_CalculatePricing_NoAddons_Expected_7Dollars()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "Small", // $7
                                "Hot",
                                null, // $0
                                null, // $0
                                0,    // $0
                                [],   // $0
                                [],   // $0
                                true 
            );

            double expected = 7.00;

            // Act
            var result = PricingCalculator.PricingCalculation(beverage);

            // Assert
            Assert.AreEqual(expected, result);

        }
    }
}
