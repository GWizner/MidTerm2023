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

        public CoffeeMenu(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }


        public Dictionary<string, decimal> addOns = new Dictionary<string, decimal>
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
    }
}
       