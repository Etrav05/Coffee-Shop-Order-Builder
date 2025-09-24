using CoffeeOrder.Models;

namespace CoffeeOrder.Validation;

/*
**Required fields:** 
        [X]`BaseDrink` and `Size` must be present. 
        [X]**Mutually exclusive:** `Temp` is either `Hot` or `Iced` (not both).
        [X]**Milk selection:** May specify *either* dairy **or** plant milk (or neither), **notboth**.
        [X]**Limits:** `Shots` in [0..4], `Syrups.Count` in [0..5]; negative counts invalid.
        []**Allergen:** Plant milks like Almond should flag **“contains tree nuts”** (warning or error—your design; be consistent).
        []**Classification:** `KidSafe` if then no espresso shots (or `IsDecaf == true`) and `Temp != “ExtraHot”` (if you model temperature granularity).
        []**Pricing:** Base price by `Size` + per-addon prices.
        []**Promotions:** e.g., `HAPPYHOUR` (20% off **Hot** drinks only); `BOGO` (buy one get one of equal/lesser value free once per order).
        []**Receipt:** Shows line items, discounts, totals; includes allergen notices when applicable.
*/

public static class OrderValidator
{
    public static ValidationResult Validate(Beverage beverage)
    {
        var errors = new List<string>();

        if (beverage is null)
        {
            return ValidationResult.Fail("Beverage must not be null.");
        }

        // Required fields:

        // Required present attributes
        if (string.IsNullOrWhiteSpace(beverage.BaseDrink)) // Checking that Base drink is entered
            errors.Add("A base beverage is required.");

        if (string.IsNullOrWhiteSpace(beverage.Size)) // Checking that Size is entered
            errors.Add("A size selection is required.");

        // Mutually exclusive Hot and Iced 
        if (beverage.Temp != "Hot" && beverage.Temp != "Iced" ) // Making sure a either temperature is entered
            errors.Add("Temperature selection may either be Hot and Iced.");

        // Milk XOR rule: cannot select both dairy and plant milk
        if (!string.IsNullOrWhiteSpace(beverage.Milk) && !string.IsNullOrWhiteSpace(beverage.PlantMilk)) // Checking that not both milk and plantmilk options are entered
            errors.Add("Milk selection invalid: choose dairy OR plant milk, not both.");

        // Limits
        if (beverage.Shots < 0 || beverage.Shots > 4) // Checking that shots count is between 0 and 4
            errors.Add("Shots must be between 0 and 4 inclusive.");

        if (beverage.Syrups is null || beverage.Syrups.Length > 5 || beverage.Syrups.Any(s => s is null)) // Checking that syrups count is between 0 and 5 AND that the list of syrups isnt null/contains null value
            errors.Add("Syrups must contain 0..5 non-null entries.");

        return errors.Count == 0 ? ValidationResult.Ok() : ValidationResult.Fail(errors.ToArray());
    }
}