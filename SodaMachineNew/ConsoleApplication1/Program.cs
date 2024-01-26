using SodaMachineNew.Model;
using SodaMachineNew.Model.Inventory;

namespace SoodaMachineNew
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            MySodaMachineNew sodaMachine = new MySodaMachineNew(inventory);
            sodaMachine.Start();
        }
    }
}
