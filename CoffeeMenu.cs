using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2023
{
    public class CoffeeMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        List<CoffeeMenu> coffees = new List<CoffeeMenu>
        {
            new CoffeeMenu { Id = 1, Name = "Espresso", Price = 2.50m, Description = "A strong, concentrated coffee made by forcing hot water through finely ground coffee beans under high pressure." },
            new CoffeeMenu { Id = 2, Name = "Cappuccino", Price = 3.50m, Description = "A classic Italian coffee beverage made with equal parts espresso, steamed milk, and frothed milk." },
            new CoffeeMenu { Id = 3, Name = "Latte", Price = 4.00m, Description = "A coffee beverage made with espresso and steamed milk, often topped with a small layer of frothed milk." },
            new CoffeeMenu { Id = 4, Name = "Americano", Price = 3.00m, Description = "A coffee beverage made by adding hot water to a shot of espresso." },
            new CoffeeMenu { Id = 5, Name = "Mocha", Price = 4.50m, Description = "A coffee beverage made with espresso, steamed milk, and chocolate syrup or powder." },
            new CoffeeMenu { Id = 6, Name = "Macchiato", Price = 3.50m, Description = "A coffee beverage made with espresso and a small amount of frothed milk." },
            new CoffeeMenu { Id = 7, Name = "Flat White", Price = 4.50m, Description = "A coffee beverage similar to a latte, but with a higher ratio of espresso to milk." },
            new CoffeeMenu { Id = 8, Name = "Irish Coffee", Price = 6.00m, Description = "A cocktail made with hot coffee, Irish whiskey, and sugar, topped with whipped cream." },
            new CoffeeMenu { Id = 9, Name = "Affogato", Price = 5.00m, Description = "A dessert beverage made by pouring a shot of espresso over a scoop of vanilla ice cream or gelato." },
            new CoffeeMenu { Id = 10, Name = "French Press", Price = 6.50m, Description = "A brewing method that involves steeping coarse coffee grounds in hot water, and then pressing the mixture through a metal or mesh filter." },
            new CoffeeMenu { Id = 11, Name = "Cold Brew", Price = 4.50m, Description = "A coffee beverage made by steeping coarse coffee grounds in cold water for an extended period of time, often 12-24 hours." },
            new CoffeeMenu { Id = 12, Name = "Nitro Cold Brew", Price = 5.00m, Description = "A type of cold brew coffee that is infused with nitrogen gas, giving it a creamy, velvety texture and a foamy top similar to a draft beer." },
            new CoffeeMenu { Id = 13, Name = "Iced Coffee", Price = 3.50m, Description = "A coffee beverage served over ice, often made by brewing hot coffee and then chilling it or pouring it over ice." }
        };

        public void DisplayDrinks(List<CoffeeMenu> coffees)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("DRINKS MENU:");
            Console.ResetColor();

            int counter = 1;
            foreach (var drink in coffees)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(String.Format("{0, -1}{1, -17}", counter + ".", drink.Id));
                if (counter > 9)
                {
                    Console.WriteLine(String.Format("\x1b[31m" + "{0, 10:C}", drink.Name));
                }
                else
                {
                    Console.WriteLine(String.Format("\x1b[31m" + "{0, 11:C}", drink.Name));
                }
                Console.WriteLine(String.Format("\x1b[31m" + "{0, 10:C}", drink.Price));
                Console.ResetColor();
                counter++;
            }
        }

        //public Dictionary<string, decimal> drinks;

        //public Dictionary<string, decimal> addOns;

        //public Dictionary<int, string> drinkMenu;

        //public CoffeeMenu(string drinkName, int drinkNum)
        //{
        //    drinks = new Dictionary<string, decimal>
        //    {
        //    { "Espresso", 3.00m},
        //    { "Cappuccino", 4.50m },
        //    { "Latte", 4.00m },
        //    { "Americano", 3.50m },
        //    { "Mocha", 5.00m },
        //    { "Macchiato", 4.50m },
        //    { "Flat White", 4.50m },
        //    { "Irish Coffee", 6.50m },
        //    { "Affogato", 5.00m },
        //    { "French Press", 5.50m },
        //    { "Cold Brew", 4.50m },
        //    { "Nitro Cold Brew", 5.50m },
        //    { "Iced Coffee", 3.50m }
        //    };

        //    drinkMenu = new Dictionary<int, string>
        //    {
        //        { 1, "Espresso"},
        //        { 2, "Cappuccino"},
        //        { 3, "Latte"},
        //        { 4, "Americano"},
        //        { 5, "Mocha"},
        //        { 6, "Macchiato"},
        //        { 7, "Flat White"},
        //        { 8, "Irish Coffee"},
        //        { 9, "Affogato"},
        //        { 10, "French Press"},
        //        { 11, "Cold Brew"},
        //        { 12, "Nitro Cold Brew"},
        //        { 13, "Iced Coffee"}
        //    };
        //    drinkNum = drinkMenu.FirstOrDefault(x => x.Value == drinkName).Key - 1;


        Dictionary<string, decimal> addOns = new Dictionary<string, decimal>
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
        //public decimal GetDrinkPrice(string drinkName, string selectedDrinkName, int drinkNum)
        //{
        //    if (drinks.ContainsKey(selectedDrinkName))
        //    {
        //        return drinks[selectedDrinkName];
        //    }
        //    else if (drinkMenu.ContainsKey(drinkNum))
        //    {
        //        return drinks[selectedDrinkName];
        //    }
        //    else
        //    {
        //        throw new ArgumentException($"Invalid drink name: {drinkName}");
        //    }
        //}

        public static decimal GetAddOnPrice(Dictionary<string, decimal> addOns, string addOnName)
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