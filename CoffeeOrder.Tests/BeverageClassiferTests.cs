using CoffeeOrder.Models;
using CoffeeOrder.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Categories/labels: `Caffeinated/Decaf`, `DairyFree`, `VeganFriendly`, `KidSafe` (e.g., no espresso).

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class BeverageClassiferTests
    {
        [TestMethod]
        public void CreateBeverage_ClassifyDecaf_CheckResult_AreEqual() // Checking Decaf classifier
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
                                true // Decaf boolian
            );

            var expected = new string[] { "Decaf", "Contains dairy", "Not vegan", "Adult" }; 
                         
            // Act
            var result = BeverageClassifier.Classify(beverage);

            // Assert
            CollectionAssert.AreEqual(expected, result.Classifications.ToArray()); // Used CollectionAssert as we are comparing 2 lists 
                                                                                  // Change Classification ToArray to make it comparable with the expected
        }

        [TestMethod]
        public void CreateBeverage_ClassifyDairyFree_CheckResult_AreEqual() // Checking Dairy free classifier
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                null, // Dairy free
                                "Oat",
                                3,
                                ["Caramel", null],
                                ["Nuts", "Flakes", "Sprinkles", "Glass"],
                                false
            );

            var expected = new string[] { "Caffinated", "Dairy free", "Not vegan", "Adult" };

            // Act
            var result = BeverageClassifier.Classify(beverage);

            // Assert
            CollectionAssert.AreEqual(expected, result.Classifications.ToArray());
        }

        [TestMethod]
        public void CreateBeverage_ClassifyVegan_CheckResult_AreEqual() // Checking Vegan classifier
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                null, // Dairy free
                                "Oat",
                                3,
                                [null], // No syrup
                                [null], // No toppings
                                false
            );

            var expected = new string[] { "Caffinated", "Dairy free", "Vegan", "Adult" };

            // Act
            var result = BeverageClassifier.Classify(beverage);

            // Assert
            CollectionAssert.AreEqual(expected, result.Classifications.ToArray()); // Used CollectionAssert as we are comparing 2 lists 
                                                                                   // Change Classification ToArray to make it comparable with the expected
        }

        [TestMethod]
        public void CreateBeverage_ClassifyKidSafe_CheckResult_AreEqual() // Checking Kid safe classifier
        {
            // Arrange
            var beverage = new Beverage(
                                "London Fog",
                                "XLarge",
                                "Hot",
                                "Cow", 
                                null,
                                0, // No caffine
                                ["Caramel"],
                                ["Nuts"],
                                true
            );

            var expected = new string[] { "Decaf", "Contains dairy", "Not vegan", "Kid safe" };

            // Act
            var result = BeverageClassifier.Classify(beverage);

            // Assert
            CollectionAssert.AreEqual(expected, result.Classifications.ToArray()); // Used CollectionAssert as we are comparing 2 lists 
                                                                                   // Change Classification ToArray to make it comparable with the expected
        }
    }
}
