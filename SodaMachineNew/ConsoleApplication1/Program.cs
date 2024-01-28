using SodaMachineNew.Model;
using SodaMachineNew.Model.Inventory;

namespace SoodaMachineNew
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            inventory.Initialize();

            MySodaMachineNew sodaMachine = new MySodaMachineNew(inventory);
            sodaMachine.Start();
        }
    }
}
