using ConsoleApplication1.Model.SodaTypes;

namespace ConsoleApplication1.Model.Inventory
{
    public class InventoryItem
    {
        public ISoda Soda { get; private set; }
        public int Quantity { get; private set; }

        public InventoryItem(ISoda soda, int quantity)
        {
            Soda = soda;
            Quantity = quantity;
        }
        public void ReduceQuantityByNumber(int nr)
        {
            Quantity -= nr;
        }
    }
}
