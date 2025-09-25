using CoffeeOrder.Models;
using CoffeeOrder.Pricing;
using CoffeeOrder.Promotions;
using CoffeeOrder.Validation;

/*
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

// line items
// discounts
// totals
// and warnings 

var expected = " London Fog, Cow milk, Caramel, 1x Nuts, 1x Flakes, 1x Sprinkles, 1x Glass, 1x Bark" // Line items
             + " No discount applied "                                                  // Discounts
             + " $20 "                                                                 // Total
             + " Contains Nuts ";                                                     // Warnings
*/

namespace CoffeeOrder.Receipt;

public class ReceiptFormatter
{
    public static string Receipt(Beverage beverage, string promoCode)
    {
        ///////// LINE ITEMS /////////
        string receipt = "";

        // Base drink + Size
        receipt = beverage.BaseDrink + " - " + beverage.Size + "\n\n"; // Base drink - XLarge\n\n

        // Milk/PlantMilk
        if (!string.IsNullOrEmpty(beverage.Milk))
            receipt += "Milk: " + beverage.Milk + "\n\n"; // Milk: milk\n\n

        if (!string.IsNullOrEmpty(beverage.PlantMilk))
            receipt += "Plant milk: " + beverage.PlantMilk + "\n\n"; // Plant milk: plant milk\n\n

        // Syrup(s)
        receipt += "Syrup(s):\n";

        foreach (var syrup in beverage.Syrups)                   // For each Syrup
        {
            if (!string.IsNullOrEmpty(syrup))                  // check if the list is empty first
                receipt += "  - " + syrup + "\n";             // Syrup name
        }

        // Topping(s)
        receipt += "\nTopping(s):\n";

        foreach (var topping in beverage.Toppings)         // For each topping
        {
            if (!string.IsNullOrEmpty(topping))          // check if the list is empty first
                receipt += "  - " + topping + "\n";     // Topping name
        }
        /////////////////////////////

        ///// DISCOUNTS & PRICE /////

        double price = PricingCalculator.PricingCalculation(beverage);

        double discountedPrice = PromotionHelper.ApplyPromotion(beverage, promoCode);

        if (price != discountedPrice)
            receipt += "Promotion applied: " + promoCode;
        else
            receipt += "No promotion applied: " + promoCode;

        return receipt;
    }

}