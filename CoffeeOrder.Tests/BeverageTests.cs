using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder.Models;

namespace CoffeeOrder.Tests
{
    [TestClass]   // Mark this class as a test container
    public class BeverageTests
    {
        [TestMethod]   // Mark this method as an individual test
        public void CreateBeverage_WithBaseDrink_LondonFog_SetsNameCorrectly() // BaseDrink assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog", // BaseDrink
                                "XLarge",
                                "Hot",
                                "Cow",
                                "Oat",
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true 
                              ); 

            var expected = "London Fog";             

            // Act
            var result = beverage.BaseDrink;       // define the actual result

            // Assert
            Assert.AreEqual(expected, result);  // check if the expected and result were the same
        }

        [TestMethod]
        public void CreateBeverage_WithSize_XLarge_SetsSizeCorrectly() // Size assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge", // Size
                                "Hot",
                                "Cow",
                                "Oat",
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true
                              ); 

            var expected = "XLarge";                            

            // Act
            var result = beverage.Size;                      

            // Assert
            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void CreateBeverage_WithTemp_Hot_SetsTempCorrectly() // Temp assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot", // Temp
                                "Cow",
                                "Oat",
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true 
                              ); 

            var expected = "Hot";                                      

            // Act
            var result = beverage.Temp;                             

            // Assert
            Assert.AreEqual(expected, result);                   
        }

        [TestMethod]
        public void CreateBeverage_WithMilk_Cow_SetsMilkCorrectly() // Milk assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow", // Milk
                                "Oat",
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true 
                              ); 
            
            var expected = "Cow";                                             

            // Act
            var result = beverage.Milk;                                     

            // Assert
            Assert.AreEqual(expected, result);                           
        }

        [TestMethod]
        public void CreateBeverage_WithPlantMilk_Oat_SetsMilkCorrectly() // PlantMilk assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                "Oat", // PlantMilk
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true 
                              ); 
            
            var expected = "Oat";

            // Act
            var result = beverage.PlantMilk;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateBeverage_WithShots_3Shots_SetsShotsCorrectly() // Shots assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                "Oat",
                                3, // Shots
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true 
                              ); 
            
            var expected = 3;

            // Act
            var result = beverage.Shots;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateBeverage_WithSyrups_2Syrups_SetsSyrupsCorrectly() // Syrups assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                "Oat",
                                3,
                                ["Caramel", "Unicorn"], // Syrups
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true 
                              ); 
            
            var expected = new string[] { "Caramel", "Unicorn" };

            // Act
            var result = beverage.Syrups;

            // Assert
            CollectionAssert.AreEqual(expected, result); // Used CollectionAssert as we are comparing 2 lists
        }

        [TestMethod]
        public void CreateBeverage_WithToppings_4Toppings_SetsToppingsCorrectly() // Toppings assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow",
                                "Oat",
                                3,
                                ["Caramel", "Unicorn"],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                true
                              );

            var expected = new string[] { "Nuts", "Flakes", "Sprinkles", "Glass" };

            // Act
            var result = beverage.Toppings;

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CreateBeverage_IsDecaf_True_SetsIsDecafCorrectly() // IsDecaf assignment test
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog", 
                                "XLarge", 
                                "Hot",
                                "Cow", 
                                "Oat", 
                                3, 
                                ["Caramel", "Unicorn"], 
                                ["Nuts", "Flakes", "Sprinkles", "Glass"], 
                                true // Decaf
                              );

            var expected = true;

            // Act
            var result = beverage.IsDecaf;

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}