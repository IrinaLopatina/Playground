using SodaMachineNew.Model.Inventory;

namespace SodaMachineNew.Model.Command
{
    public class SmsOrderCommand : ICommand
    {
        public int Id { get; private set; } = 3;
        public string Name { get; private set; } = "sms order";
        public string Description { get; set; } = $"sms order (coke, sprite, fanta) - Order sent by sms";

        public double Execute(double money, string input, IInventory inventory)
        {
            var csoda = input.Split(' ')[2];

            inventory.SmsOrderSoda(csoda);
            return money;
        }
    }
}
