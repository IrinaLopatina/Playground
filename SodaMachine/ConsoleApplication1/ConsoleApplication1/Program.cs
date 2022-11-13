using ConsoleApplication1.Model;
using ConsoleApplication1.Model.Inventory;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inventory = new Inventory();
            var sodaMachine = new SodaMachine(inventory);
            sodaMachine.Start();
        }
    }
}
