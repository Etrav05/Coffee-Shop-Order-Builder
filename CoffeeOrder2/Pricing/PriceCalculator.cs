using CoffeeOrder.Models;

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

namespace CoffeeOrder.Pricing;

public class PricingCalculator
{
   
    // Size pricing dictionary
    static Dictionary<string, double> sizeDictionary = new()
    {
        { "Small", 7.0 },
        { "Medium", 9.0 },
        { "Large", 10.5 },
        { "XLarge", 12.0 }
    };

    // Milk pricing dictionary
    static Dictionary<string, double> milkDictionary = new()
    {
        { "Cow", 0 },
        { "Goat", 0.25 },
        { "Alpaca", 0.50 },
        { "Special", 1 }
    };

    // Plant milk pricing dictionary
    static Dictionary<string, double> plantmilkDictionary = new()
    {
        { "Oat", 0.50 },
        { "Almond", 0.50 },
        { "Walnut", 0.75 }
    };

    // Syrups pricing dictionary
    static Dictionary<string, double> syrupsDictionary = new()
    {
        { "Chocolate", 1.25 },
        { "Caramel", 1.25 },
        { "Strawberry", 1.25 },
        { "Vanilla", 1.25 },
        { "Unicorn", 2.50 }
    };

    // Toppings pricing dictionary
    static Dictionary<string, double> toppingsDictionary = new()
    {
        { "Nuts", 0.75 },
        { "Flakes", 0.75 },
        { "Sprinkles", 0.75 },
        { "Glass", 0.75 },
        { "Bark", 0.75 }
    };
    
    public static double PricingCalculation(Beverage beverage)
    {
        double total = 0;

        total += sizeDictionary[beverage.Size];                            // Size cost

        if (!string.IsNullOrWhiteSpace(beverage.Milk)) 
            total += milkDictionary[beverage.Milk];                     // Milk cost

        if (!string.IsNullOrWhiteSpace(beverage.PlantMilk))
            total += plantmilkDictionary[beverage.PlantMilk];        // Plant cost
        
        total += beverage.Shots;                                   // Shot(s) cost ($1 each)

        foreach (var syrup in beverage.Syrups)                   // For each Syrup
        {
            if (!string.IsNullOrEmpty(syrup)) // check if the list is empty first
                total += syrupsDictionary[syrup];             // Syrup cost
        }

        foreach (var topping in beverage.Toppings)         // For each topping
        {
            if (!string.IsNullOrEmpty(topping)) // check if the list is empty first
                total += toppingsDictionary[topping];   // Topping cost
        }

        return Math.Round(total, 2); // round total to the nearest hundredth
    }
}