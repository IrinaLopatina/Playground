using SodaMachine.Model;
using SodaMachine.Model.Inventory;

namespace SodaMachine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inventory = new Inventory();
            var sodaMachine = new MySodaMachine(inventory);
            sodaMachine.Start();
        }
    }
}
