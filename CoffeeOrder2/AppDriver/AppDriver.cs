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
        public static bool UIBasicChoices(string[] options, string type)
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

            if (type == "milk" && selection != options.Length)
                return true; // make sure we cant select a milk and plant milk
            else
                return false;
        }

        public static void UIAmountChoices(int max, string type)
        {
            int selection;     // The users selected # of things

            do // Do this question
            {
                Console.Write("How many " + type + " do you want (Max " + max + ")? ");

                if (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > max) // check if value is vaild
                    Console.WriteLine("Invaild " + type + " option");                                    // if not, error message
            }

            while (selection < 1 || selection > max); // while the input is outside the given range

            Console.WriteLine("You selected: " + selection + "\n");
        }

        public static void UIMultiSelectChoices(string[] options, int max, string type)
        {
            // Selecting amount of "thing"
            int amountSelection; // The users selected item #

            do // Do this question
            {
                Console.Write("How many " + type + " do you want (Max " + max + ")? ");

                if (!int.TryParse(Console.ReadLine(), out amountSelection) || amountSelection < 1 || amountSelection > max) // check if value is vaild
                    Console.WriteLine("Invaild amount option");                                                            // if not, error message
            }

            while (amountSelection < 1 || amountSelection > max); // while the input is outside the given range


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
                        Console.WriteLine("Invaild " + type + " option");                                               // if not, error message
                }

                while (choiceSelection < 1 || choiceSelection > options.Length); // while the input is outside the given range

                chosenValues[i] = choiceSelection;
            }

            Console.Write("You selected: ");
            foreach (var choice in chosenValues)
            {
                Console.Write(options[choice - 1] + " ");
            }

            Console.WriteLine("\n"); // just spacing
        }

        public static void AppDriverUI()
        {
            Console.Write("========== CoffeeZilla inc ==========\n\n");
            bool milked = false;
            int MAXSHOTS = 4;      // max shots allowed
            int MAXSYRUPS = 5;    // max syrups allowed
            int MAXTOPPINGS = 6; // max toppings allowed (just defined as 6 because max wasnt listed)

            // Basedrink
            string[] baseDrinks = { "London Fog", "Coffee", "Hot Chocolate", "Frappee" };

            UIBasicChoices(baseDrinks, "drink");

            // Size
            string[] sizes = { "Small", "Medium", "large", "XLarge" };

            UIBasicChoices(sizes, "size");

            // Temp
            string[] temps = { "Hot", "Iced" };

            UIBasicChoices(temps, "temperature");

            // Milk
            string[] milks = { "Cow", "Goat", "Alpaca", "Special", "None"};

            milked = UIBasicChoices(milks, "milk");

            // Plant milks
            string[] pMilk = { "Oat", "Almond", "Walnut", "None" };

            if (milked == false ) // skip this option if milk has already been selected
                UIBasicChoices(pMilk, "Plant milk");

            // Shots 
            UIAmountChoices(MAXSHOTS, "expresso shots");

            // Syrups
            string[] syrups = { "Caramel", "Chocolate", "Strawberry", "Vanilla", "Unicorn" };

            UIMultiSelectChoices(syrups, MAXSYRUPS, "syrup");

            // Toppings
            string[] toppings = { "Nuts", "Flakes", "Sprinkles", "Glass", "Bark" };

            UIMultiSelectChoices(toppings, MAXTOPPINGS, "topping");

            // Decaf boolian
            string[] yesNo = { "Yes", "No" };

            UIBasicChoices(yesNo, "decaf");
        }


        static int Main()
        {
            AppDriverUI();

            return 0; // exit code
        }
    }
}