using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoffeeOrder.Models;
using CoffeeOrder.Classifiers;
using CoffeeOrder.Pricing;
using CoffeeOrder.Promotions;
using CoffeeOrder.Validation;
using CoffeeOrder.Receipt;

namespace CoffeeOrder.AppDriver
{
    public class AppDriver
    {
        public static string UIBasicChoices(string[] options, string type)
        {
            Console.Write("Choose your " + type + ":\n");

            for (int i = 0; i < options.Length; i++)
                Console.WriteLine("  " + (i + 1) + ". " + options[i]);

            int selection; // The users selected item #

            do // Do this question
            {
                Console.Write("\nEnter number here: ");

                if (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > options.Length) // check if value is vaild
                    Console.WriteLine("Invaild " + type + " option");                                               // if not, error message
            }

            while (selection < 1 || selection > options.Length); // while the input is outside the given range

            Console.WriteLine("You selected: " + options[selection - 1] + "\n");

           
            return options[selection - 1];
        }

        public static int UIAmountChoices(int max, string type)
        {
            int selection;     // The users selected # of things

            do // Do this question
            {
                Console.Write("How many " + type + " do you want (Max " + max + ")? ");

                if (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection > max) // check if value is vaild
                    Console.WriteLine("Invaild " + type + " option");                                    // if not, error message
            }

            while (selection < 0 || selection > max); // while the input is outside the given range

            Console.WriteLine("You selected: " + selection + "\n");

            return selection; 
        }

        public static string[] UIMultiSelectChoices(string[] options, int max, string type)
        {
            // Selecting amount of "thing"
            int amountSelection; // The users selected item #

            do // Do this question
            {
                Console.Write("How many " + type + " do you want (Max " + max + ")? ");

                if (!int.TryParse(Console.ReadLine(), out amountSelection) || amountSelection < 0 || amountSelection > max) // check if value is vaild
                    Console.WriteLine("Invaild amount option");                                                            // if not, error message
            }

            while (amountSelection < 0 || amountSelection > max); // while the input is outside the given range


            // Selecting what "thing(s)"
            int choiceSelection; // The users selected item #
            int[] chosenValues = new int[amountSelection]; // make an array to save the syrup value choices (which is the size of the amountSelection from above)

            Console.Write("Choose your " + type + "(s):\n");

            for (int i = 0; i < options.Length; i++)
                Console.WriteLine("  " + (i + 1) + ". " + options[i]);

            for (int i = 0; i < amountSelection; i++)
            {
                do // Do this question
                {
                    Console.Write("\nEnter number here (One at a time): ");

                    if (!int.TryParse(Console.ReadLine(), out choiceSelection) || choiceSelection < 1 || choiceSelection > options.Length) // check if value is vaild
                        Console.WriteLine("Invaild " + type + " option");                                                                 // if not, error message
                }

                while (choiceSelection < 1 || choiceSelection > options.Length); // while the input is outside the given range

                chosenValues[i] = choiceSelection;
            }

            string[] chosenItems = new string[amountSelection];

            Console.Write("You selected: ");
            for (int i = 0; i < chosenValues.Length; i++)
            {
                int choice = chosenValues[i]; // menu number user typed
                Console.Write(options[choice - 1] + " ");
                chosenItems[i] = options[choice - 1];
            }

            Console.WriteLine("\n"); // just spacing

            return chosenItems;
        }

        public static string[][] AppDriverUI()
        {
            string[][] order = new string[10][]; // create a string[] to hold the order (everything as string[])
                                                // note: everythings gotta be converted to string[]'s for this to work

            Console.Write("========== CoffeeZilla inc ==========\n\n");
            int MAXSHOTS = 4;      // max shots options allowed (0 - 4)
            int MAXSYRUPS = 5;    // max syrups allowed
            int MAXTOPPINGS = 6; // max toppings allowed (just defined as 6 because max wasnt listed)

            // Basedrink
            string[] baseDrinks = { "London Fog", "Coffee", "Hot Chocolate", "Frappee" };

            order[0] = new string[] { UIBasicChoices(baseDrinks, "drink") };

            // Size
            string[] sizes = { "Small", "Medium", "Large", "XLarge" };

            order[1] = new string[] { UIBasicChoices(sizes, "size") };

            // Temp
            string[] temps = { "Hot", "Iced" };

            order[2] = new string[] { UIBasicChoices(temps, "temperature") };

            // Milk 
            string[] milks = { "Cow", "Goat", "Alpaca", "Special", "none" };
            string milkChoice = UIBasicChoices(milks, "milk");
            order[3] = milkChoice.Equals("none") ? null : new string[] { milkChoice }; // if the user selects "none" then null will be add to the order
                                                                                      // otherwise, the regular choice will be added
            // Plant milk
            string[] pMilk = { "Oat", "Almond", "Walnut", "none" };

            if (order[3] == null) // Only asked if no regular milk was chosen
            {
                string plantChoice = UIBasicChoices(pMilk, "plant milk");
                order[4] = plantChoice.Equals("none") ? null : new string[] { plantChoice };
            }
            else
                order[4] = null;

            // Shots 
            order[5] = new string[] { UIAmountChoices(MAXSHOTS, "expresso shots").ToString() };

            // Syrups
            string[] syrups = { "Caramel", "Chocolate", "Strawberry", "Vanilla", "Unicorn" };

            order[6] = UIMultiSelectChoices(syrups, MAXSYRUPS, "syrup");

            // Toppings
            string[] toppings = { "Nuts", "Flakes", "Sprinkles", "Glass", "Bark" };

            order[7] = UIMultiSelectChoices(toppings, MAXTOPPINGS, "topping");

            // Decaf boolian
            string[] yesNo = { "Yes", "No" };

            order[8] = new string[] { UIBasicChoices(yesNo, "decaf") };

            // Promotion
            string[] promoCodes = { "HONOUR", "SUMMER2025", "CEODISCOUNT", "5OFF" };

            Console.Write("\nEnter promocode here: ");
            string input = Console.ReadLine();

            // Check if input is a valid promo code
            if (promoCodes.Contains(input?.ToUpper()))
                Console.WriteLine("Promocode accepted\n\n");
            else
                Console.WriteLine("Invalid promocode\n\n");

            order[9] = new string[] { input };

            return order;
        }


        static int Main()
        {
            string[][] order = AppDriverUI();

            // Already properly fomatted types
            string baseDrink = order[0][0];
            string size = order[1][0];
            string temp = order[2][0];
            string? milk = order[3]?[0];       // will be null if "none"
            string? plantMilk = order[4]?[0];  // will be null if "none"

            // Shots (converted from string to int)
            int shots = int.Parse(order[5][0]);

            // Multiselections that are already arrays
            IEnumerable<string> syrups = order[6];
            IEnumerable<string> toppings = order[7];

            // Decaf (converted from string: "Yes"/"No" to their bools)
            bool isDecaf = false;
            if (order[8][0] == "Yes")
                isDecaf = true;

            // Promocode
            string promoCode = order[9][0];

            // Create Beverage
            Beverage beverage = new Beverage(
                baseDrink,
                size,
                temp,
                milk,
                plantMilk,
                shots,
                syrups,
                toppings,
                isDecaf
            );



            // Validate drink
            var validateBeverage = OrderValidator.Validate(beverage);

            // Classifiy drink
            var classifierResult = BeverageClassifier.Classify(beverage); // string[]

            // Calaculate price of drink
            var pricingResult = PricingCalculator.PricingCalculation(beverage); // double

            // Make receipt
            var receipt = ReceiptFormatter.Receipt(beverage, promoCode);
            
            // Write the receipt into the console
            Console.WriteLine(receipt);

            return 0;
        }
    }
}