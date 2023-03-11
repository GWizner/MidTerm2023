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
        public string Description { get; set; }
        public decimal Price { get; set; }

        public CoffeeMenu(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;

        }

        public List<CoffeeMenu> coffees = new List<CoffeeMenu>
            {
            new CoffeeMenu (1, "Espresso", "Strong.", 2.50m) ,
            new CoffeeMenu (2, "Cappuccino", "Classic.", 3.50m),
            new CoffeeMenu (3, "Latte", "Frothed milk.", 4.00m),
            new CoffeeMenu (4, "Americano", "Hot.", 3.00m),
            new CoffeeMenu (5, "Mocha", "Chocolate.", 4.50m),
            new CoffeeMenu (6, "Macchiato", "Beverage.", 3.50m),
            new CoffeeMenu (7, "Flat White", "Similar.", 4.50m),
            new CoffeeMenu (8, "Irish Coffee", "Cocktail.", 6.00m),
            new CoffeeMenu (9, "Affogato", "Vanilla.", 5.00m),
            new CoffeeMenu (10, "French Press", "Coarse.", 6.50m),
            new CoffeeMenu (11, "Cold Brew", "Cold.", 4.50m),
            new CoffeeMenu (12, "Nitro Cold Brew", "Nitrogen.", 5.00m),
            new CoffeeMenu (13, "Iced Coffee", "Iced.", 3.50m)
        };

        //public static void DisplayDrinks(string[] args)
        //{
        //    CoffeeMenu menu = new CoffeeMenu();
        //    List<CoffeeMenu> coffees = menu.menuList;

        //    Console.ForegroundColor = ConsoleColor.DarkCyan;
        //    Console.WriteLine("DRINKS MENU:");
        //    Console.ResetColor();


        //    foreach (var drink in coffees)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.Write(String.Format("{0, -1}{1, -17}", counter + ".", drink.Id));
        //        if (counter > 9)
        //        {
        //            Console.WriteLine(String.Format("\x1b[31m" + "{0, 10:C}", drink.Name));
        //        }
        //        else
        //        {
        //            Console.WriteLine(String.Format("\x1b[31m" + "{0, 11:C}", drink.Name));
        //        }
        //        Console.WriteLine(String.Format("\x1b[31m" + "{0, 10:C}", drink.Price));
        //        Console.ResetColor();
        //    }
        //}


        public void DisplayDrinks(List<CoffeeMenu> coffees)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("DRINKS MENU:");
            Console.ResetColor();

            int counter = 1;
            foreach (var drink in coffees)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(String.Format("{0, -1}", drink.Id + "."));
                if (counter > 9)
                {
                    Console.Write(String.Format("\x1b[31m" + "{0, 10:C}", drink.Name));
                }
                else
                {
                    Console.Write(String.Format("\x1b[31m" + "{0, 11:C}", drink.Name));
                }
                Console.Write(String.Format("\x1b[31m" + "{0, 10:C}", drink.Price));
                Console.Write(String.Format("\x1b[31m" + "{0, 10:C}", drink.Description));
                Console.WriteLine(" ");
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