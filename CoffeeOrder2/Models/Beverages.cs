// 1. Beverage (model)   
// •	Properties:
// `BaseDrink` (e.g., Latte/Tea/Chocolate),
// `Size` (e.g., Tall/Grande/Venti),
// `Temp` (Hot/Iced),
// `Milk` (Dairy type),
// `PlantMilk` (Oat/Almond/etc.),
// `Shots` (0–4),
// `Syrups` (0–5, list),
// `Toppings` (list),
// flags like `IsDecaf`,
// etc.

namespace CoffeeOrder.Models;

public class Beverage
{
    public string? BaseDrink { get; }   // Get the name of the base drink

    public string? Size { get; }        // Get the size (Small - Medium - Large - XLarge)

    public string? Temp { get; }        // Get type of temp (Hot or Iced)

    public string? Milk { get; }        // Get type of milk (Cow - Goat - Alpaca - Special)

    public string? PlantMilk { get; }   // Get type of plant based milk (Oat - Almond - Walnut)

    public int Shots { get; }           // Get number of shots of expresso (0 - 4)

    public string[] Syrups { get; }     // Get list of syrup flavours (Chocolate - Caramel - Strawberry - Vanilla - Unicorn) (0 - 5)

    public string[] Toppings { get; }   // Get list of toppings (0 - many)

    public bool IsDecaf { get; }        // Flag for decaf

    public Beverage(
       string? baseDrink, 
       string? size,
       string? temp,
       string? milk,
       string? plantMilk,
       int shots,
       IEnumerable<string>? syrups,
       IEnumerable<string>? toppings,
       bool isDecaf
     )

    {
        BaseDrink = baseDrink;
        Size = size;
        Temp = temp;
        Milk = milk;
        PlantMilk = plantMilk;
        Shots = shots;
        Syrups = (syrups ?? Array.Empty<string>()).ToArray();
        Toppings = (toppings ?? Array.Empty<string>()).ToArray();
        IsDecaf = isDecaf;
    }
}