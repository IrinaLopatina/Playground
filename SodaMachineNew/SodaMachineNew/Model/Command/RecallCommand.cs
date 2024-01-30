using SodaMachineNew.Model.Inventory;
using System;

namespace SodaMachineNew.Model.Command
{
    public class RecallCommand : ICommand
    {
        public int Id { get; private set; } = 4;
        public string Name { get; private set; } = "recall";
        public string Description { get; set; } = "recall - gives money back";

        public double Execute(double money, string input, IInventory inventory)
        {
            //Give money back
            Console.WriteLine("Returning " + money + " to customer");
            money = 0;
            return money;
        }
    }
}
