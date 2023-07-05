using nelfo.Controllers;

namespace nelfo.Dtos
{
    public class SellerProductsResponse
    {
        public Seller? Seller { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
