using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2023
{

    public class CoffeeMenu
    {
        public Dictionary<string, decimal> drinks;

        public Dictionary<string, decimal> addOns;

        public Dictionary<int, string> drinkMenu;

        public CoffeeMenu(string drinkName, int drinkNum)
        {
            drinks = new Dictionary<string, decimal>
            {
            { "Espresso", 3.00m },
            { "Cappuccino", 4.50m },
            { "Latte", 4.00m },
            { "Americano", 3.50m },
            { "Mocha", 5.00m },
            { "Macchiato", 4.50m },
            { "Flat White", 4.50m },
            { "Irish Coffee", 6.50m },
            { "Affogato", 5.00m },
            { "French Press", 5.50m },
            { "Cold Brew", 4.50m },
            { "Nitro Cold Brew", 5.50m },
            { "Iced Coffee", 3.50m }
            };

            drinkMenu = new Dictionary<int, string>
            {
                { 1, "Espresso"},
                { 2, "Cappuccino"},
                { 3, "Latte"},
                { 4, "Amricano"},
                { 5, "Mocha"},
                { 6, "Macchiato"},
                { 7, "Flat White"},
                { 8, "Irish Coffee"},
                { 9, "Affogato"},
                { 10, "French Press"},
                { 11, "Cold Brew"},
                { 12, "Nitro Cold Brew"},
                { 13, "Iced Coffee"}
            };
            drinkNum = drinkMenu.FirstOrDefault(x => x.Value == drinkName).Key - 1;


            addOns = new Dictionary<string, decimal>
        {
            { "Milk", 0.25m },
            { "Whipped Cream", 0.50m },
            { "Caramel", 0.50m },
            { "Chocolate", 0.50m },
            { "Vanilla", 0.50m },
            { "Oat Milk", 1.00m },
            { "Almond Milk", 1.00m },
            { "Shot of Baileys", 5.00m },
            { "Shot of Vodka", 6.00m },
            { "Shot of Bourbon", 6.00m }
        };
        }

        public void DisplayDrinks()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("DRINKS MENU:");
            Console.ResetColor();

            int counter = 1;
            foreach (var drink in drinks)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(String.Format("{0, -5}{1, -17}", counter + ".", drink.Key));
                Console.WriteLine(String.Format("\x1b[31m" + "{0, 10:C}", drink.Value));
                Console.ResetColor();
                counter++;
            }
        }
        //public void DisplayDrinks()
        //{
        //    Console.ForegroundColor = ConsoleColor.DarkCyan;
        //    Console.WriteLine("DRINKS MENU:");
        //    Console.ResetColor();
        //    foreach (var drink in drinks)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.Write(String.Format("{0, -20}", drink.Key));
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(String.Format("{0, 10:C}", drink.Value));
        //        Console.ResetColor();
        //    }
        //}

        public void DisplayAddOns()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("ADD-ONS MENU:");
            Console.ResetColor();
            foreach (var addOn in addOns)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(String.Format("{0, -20}", addOn.Key));
                Console.WriteLine(String.Format("\x1b[31m" + "{0, 10:C}", addOn.Value));
                Console.ResetColor();
            }
        }

        public decimal GetDrinkPrice(string drinkName, string selectedDrinkName, int drinkNum)
        {
            if (drinks.ContainsKey(selectedDrinkName))
            {
                return drinks[selectedDrinkName];
            }
            else if (drinkMenu.ContainsKey(drinkNum))
            {
                return drinks[selectedDrinkName];
            }
            else
            {
                throw new ArgumentException($"Invalid drink name: {drinkName}");
            }
        }
        // change 
        public decimal GetAddOnPrice(string addOnName)
        {
            if (addOns.ContainsKey(addOnName))
            {
                return addOns[addOnName];
            }
            else
            {
                throw new ArgumentException($"Invalid add-on name: {addOnName}");
            }
        }
    }
}