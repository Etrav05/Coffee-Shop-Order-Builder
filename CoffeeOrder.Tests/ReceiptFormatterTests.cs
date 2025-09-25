using CoffeeOrder.Models;
using CoffeeOrder.Receipt;
using CoffeeOrder.Pricing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public void CreateBeverage_FormatData_CheckBaseDrink_and_Size()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge", 
                                "Hot",
                                "Cow", 
                                null,
                                3,   
                                ["Caramel", null], 
                                ["Nuts", "Flakes", "Sprinkles", "Glass", "Bark"],
                                false
            );

            string expected = "London Fog - XLarge";

            string promoCode = null;

            // Act
            var result = ReceiptFormatter.Receipt(beverage, promoCode);

            // Assert
            StringAssert.Contains(result, expected);
        }

        [TestMethod]
        public void CreateBeverage_FormatData_CheckMilk()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge", 
                                "Hot",
                                "Cow",
                                null, 
                                3,   
                                ["Caramel", null], 
                                ["Nuts", "Flakes", "Sprinkles", "Glass", "Bark"],
                                false
            );

            string expected = "Milk: Cow";

            string promoCode = null;

            // Act
            var result = ReceiptFormatter.Receipt(beverage, promoCode);

            // Assert
            StringAssert.Contains(result, expected);
        }

        [TestMethod]
        public void CreateBeverage_FormatData_CheckSyrup()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge", 
                                "Hot",
                                "Cow", 
                                null, 
                                3,   
                                ["Caramel", "Chocolate", null],
                                ["Nuts", "Flakes", "Sprinkles", "Glass", "Bark"],
                                false
            );

            string expected = "Syrup(s):\n  - Caramel\n  - Chocolate";

            string promoCode = null;

            // Act
            var result = ReceiptFormatter.Receipt(beverage, promoCode);

            // Assert
            StringAssert.Contains(result, expected);
        }

        [TestMethod]
        public void CreateBeverage_FormatData_CheckToppings()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                null,
                                3,
                                ["Caramel", "Chocolate", null],
                                ["Nuts", "Flakes", "Sprinkles", "Glass", "Bark"],
                                false
            );

            string expected = "Topping(s):\n  - Nuts\n  - Flakes\n  - Sprinkles\n  - Glass\n  - Bark";

            string promoCode = null;

            // Act
            var result = ReceiptFormatter.Receipt(beverage, promoCode);

            // Assert
            StringAssert.Contains(result, expected);
        }

        [TestMethod]
        public void CreateBeverage_FormatData_CheckTotal()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                null,
                                3,
                                ["Caramel", "Chocolate", null],
                                ["Nuts", "Flakes", "Sprinkles", "Glass", "Bark"],
                                false
            );

            string expected = "Total: $21.25"; // typicaly 20 but we add that chocolate syrup (+1.25)

            string promoCode = null;

            // Act
            var result = ReceiptFormatter.Receipt(beverage, promoCode);

            // Assert
            StringAssert.Contains(result, expected);
        }

        //////////////////////////////////// FAILING TEST ////////////////////////////////////
        [TestMethod]
        public void CreateBeverage_FormatData_CheckWarnings()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                null,
                                3,
                                ["Caramel", "Chocolate", null],
                                ["Nuts", "Flakes", "Sprinkles", "Glass", "Bark"],
                                false
            );

            string expected = "Warning(s):\n  - Caffinated\n  - Contains dairy\n  - Not vegan\n  - Adult\n  - Contains nuts"; 
                                                                                                       // Nuts not implemented yet
            string promoCode = null;

            // Act
            var result = ReceiptFormatter.Receipt(beverage, promoCode);

            // Assert
            StringAssert.Contains(result, expected);
        }
        //////////////////////////////////////////////////////////////////////////////////////
    }
}