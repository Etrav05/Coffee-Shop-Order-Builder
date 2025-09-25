using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoffeeOrder.Pricing;
using CoffeeOrder.Models;


namespace CoffeeOrder.Promotions;

public class PromotionHelper 
{

    static Dictionary<string, (double discount, string temp)> promotionsDictionary = new() // taking advantage of tuples to pack discount at the item they apply to into one attribute
    {
        { "HONOUR", (0.15, "Hot") },
        { "SUMMER2025", (0.20, "Iced") },
        { "CEODISCOUNT", (0.99, "All") },
        { "5OFF", (0.5, "All") },
    };

    public static double ApplyPromotion(Beverage beverage, string promoCode)
    {
        double price = PricingCalculator.PricingCalculation(beverage);
        double discountedPrice = 0;

        if (promoCode != null && promotionsDictionary.TryGetValue(promoCode, out var promo)) // if the promoCode is not null && the promoCode is in the promotionsDictionary 
        {                                                                                    // then the tuple is grabbed (discount, temp) 
            if (promo.temp == "All" || promo.temp == beverage.Temp)                        // Apply only if beverage matches the Temp defined
            {
                discountedPrice = price * (1 - promo.discount);
            }
        }

        return Math.Round(discountedPrice, 2); // round discounted price to the nearest hundredth
    }
}
