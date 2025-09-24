using CoffeeOrder.Models;
using CoffeeOrder.Validation;


namespace CoffeeOrder.Tests
{
    [TestClass]
    public sealed class ValidationTest
    {
        [TestMethod]
        public void CreateValidBeverage_CheckResultOfBeverageValidation_IsTrue()
        {
            // Arrange
            var beverage = new Beverage(  
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                null,  // Following XOR rule of milks
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true 
                              );

            // Act
            var result = OrderValidator.Validate(beverage);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void CreateInvalidBeverage_CheckResultOfBeverageValidation_IsFalse()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                "Oat",  // Breaking XOR rule of milks
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true
                              );

            // Act
            var result = OrderValidator.Validate(beverage);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void CreateInvalidBeverage_NotHot_OrIced_CheckResultOfBeverageValidation_IsFalse()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Something Tasteful", // Not hot or iced
                                "Cow",
                                null, 
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true
                              );

            // Act
            var result = OrderValidator.Validate(beverage);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void CreateInvalidBeverage_20Shots_CheckResultOfBeverageValidation_IsFalse()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                null, 
                                20, // Too many shots (heart attack incoming)
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true
                              );

            // Act
            var result = OrderValidator.Validate(beverage);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void CreateInvalidBeverage_NullSyrup_CheckResultOfBeverageValidation_IsFalse()
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
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true
                              );

            // Act
            var result = OrderValidator.Validate(beverage);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void CreateInvalidBeverage_6Syrups_CheckResultOfBeverageValidation_IsFalse()
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                null,
                                3,
                                ["Caramel", "Choclate", "Unicorn", "Vanilla", "Strawberry", "Pumpkin Spice" ],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true
                              );

            // Act
            var result = OrderValidator.Validate(beverage);

            // Assert
            Assert.IsFalse(result.IsValid);
        }
    }
}