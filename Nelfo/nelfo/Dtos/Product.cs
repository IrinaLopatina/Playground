namespace nelfo.Dtos
{
    public class Product
    {
        public string? ProductNo { get; }
        public string? Description { get; }
        public string? PriceUnit { get; }
        public decimal? Price { get; }
        public int? Quantity { get; }
        public decimal? Weight { get; private set; }

        public Product(string? productNo, string? description, string? priceUnit, decimal? price, int? quantity)
        {
            ProductNo = productNo;
            Description = description;
            PriceUnit = priceUnit;
            Price = price;
            Quantity = quantity;
        }

        public void SetWeight(decimal? weight)
        {
            Weight = weight;
        }
    }
}
