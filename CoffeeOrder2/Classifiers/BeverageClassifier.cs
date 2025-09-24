using CoffeeOrder.Classifiers;
using CoffeeOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Categories/labels: `Caffeinated/Decaf`, `DairyFree`, `VeganFriendly`, `KidSafe` (e.g., no espresso).

public static class BeverageClassifier
{
    public static BeverageClassifierResult Classify(Beverage beverage)
    {
        var classifications = new List<string>();
        var vegan = true;

        // Caffeinated/Decaf
        classifications.Add(beverage.IsDecaf ? "Decaf" : "Caffinated"); // Check decaf state of the beverage

        // Dairyfree + Vegan 
        if (!string.IsNullOrWhiteSpace(beverage.Milk)) { // If milk attribute is null
            classifications.Add("Contains dairy"); // Contains Dairy
            vegan = false;
        }
        else classifications.Add("Dairy free"); // Dairy free

        // Vegan cont.
        if (beverage.Syrups.Any(s => s != null) || beverage.Toppings.Any(s => s != null)) // Syrups and toppings may contain animal products
            vegan = false;

        classifications.Add(vegan ? "Vegan" : "Not vegan"); // Add vegans state

        // Kidsafe
        if (beverage.Shots <= 0)           // if there are no shots of espresso
            classifications.Add("Kid safe");    // Kid safe
        else classifications.Add("Adult"); // Adult

        return new BeverageClassifierResult(classifications);
    }
}