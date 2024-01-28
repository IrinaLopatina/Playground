using SodaMachineNew.Model.Inventory;
using System;

namespace SodaMachineNew.Model.Command
{
    public class RecallCommand : ICommand
    {
        public double Execute(double money, string input, IInventory inventory)
        {
            //Give money back
            Console.WriteLine("Returning " + money + " to customer");
            money = 0;
            return money;
        }
    }
}
