namespace SodaMachine.Model.Inventory
{
    public class Soda
    {
        public string Name { get; private set; }

        public int Price { get; private set; }

        public Soda(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
