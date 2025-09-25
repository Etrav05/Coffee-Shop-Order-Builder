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
        double discountedPrice = price;


        foreach (KeyValuePair<string, (double discount, string temp)> promo in promotionsDictionary)
        {
            if (promoCode == promo.Key) // If the promo code is found in the dictionary
            {
                if (promo.Value.temp == "All" || promo.Value.temp == beverage.Temp) // And the beverage temp matches the promo Temp defined
                {
                    discountedPrice = price * (1 - promo.Value.discount);
                }

                break;
            }
        }
            
        return Math.Round(discountedPrice, 2); // round discounted price to the nearest hundredth
    }
}
