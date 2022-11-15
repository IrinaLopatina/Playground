using SodaMachine.Model;
using SodaMachine.Model.Inventory;

namespace SodaMachine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inventory = new Inventory();
            inventory.AddInventoryItem(new InventoryItem(new Soda("coke", 20), 5));
            inventory.AddInventoryItem(new InventoryItem(new Soda("sprite", 15), 3));
            inventory.AddInventoryItem(new InventoryItem(new Soda("fanta", 15), 3));

            var sodaMachine = new MySodaMachine(inventory);
            sodaMachine.Start();
        }
    }
}
