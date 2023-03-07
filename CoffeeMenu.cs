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

        public CoffeeMenu()
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
            Console.WriteLine("DRINKS MENU:");
            foreach (var drink in drinks)
            {
                Console.WriteLine($"{drink.Key} - ${drink.Value:F2}");
            }
        }

        public void DisplayAddOns()
        {
            Console.WriteLine("ADD-ONS MENU:");
            foreach (var addOn in addOns)
            {
                Console.WriteLine($"{addOn.Key} - ${addOn.Value:F2}");
            }
        }

        public decimal GetDrinkPrice(string drinkName)
        {
            if (drinks.ContainsKey(drinkName))
            {
                return drinks[drinkName];
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
