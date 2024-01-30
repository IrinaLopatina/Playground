using SodaMachineNew.Model.Inventory;

namespace SodaMachineNew.Model.Command
{
    public class SmsOrderCommand : ICommand
    {
        public double Execute(double money, string input, IInventory inventory)
        {
            var csoda = input.Split(' ')[2];

            inventory.SmsOrderSoda(csoda);
            return money;
        }
    }
}
