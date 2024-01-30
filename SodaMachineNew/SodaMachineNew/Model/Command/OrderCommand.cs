using SodaMachineNew.Model.Inventory;

namespace SodaMachineNew.Model.Command
{
    public class OrderCommand : ICommand
    {
        public double Execute(double money, string input, IInventory inventory)
        {
            var csoda = input.Split(' ')[1];
            money = inventory.OrderSoda(csoda, money);

            return money;
        }
    }
}
