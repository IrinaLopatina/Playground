namespace SodaMachine.Model.Inventory
{
    public class InventoryItem
    {
        public Soda Soda { get; private set; }
        public int Quantity { get; private set; }

        public InventoryItem(Soda soda, int quantity)
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
