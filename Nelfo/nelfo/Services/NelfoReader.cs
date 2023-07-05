using nelfo.Dtos;

namespace nelfo.Services
{
    public interface INelfoReader
    {
        SellerProductsResponse ReadSellerProducts(IFormFile file);
    }

    public class NelfoReader : INelfoReader
    {
        private readonly char[] _separators = { ';' };

        public SellerProductsResponse ReadSellerProducts(IFormFile file)
        {
            Seller? seller;
            List<Product> products = new();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var header = reader.ReadLine();
                seller = ParseSellerInfo(header);

                Product? product = null;
                Product? nextProduct = null;
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine();

                    nextProduct = ParseProductInfo(line, product);
                    if (nextProduct != null)
                    {
                        products.Add(nextProduct);
                        product = nextProduct;
                    }
                }
            }

            return new SellerProductsResponse()
            {
                Seller = seller,
                Products = products
            };
        }

        Seller? ParseSellerInfo(string? line)
        {
            var sellerInfo = line.Split(_separators);

            if (sellerInfo.Length >= 11 &&
                sellerInfo[0].Equals("VH") &&
                sellerInfo[1].Equals("EFONELFO") &&
                sellerInfo[2].Equals("4.0"))
            {
                return new Seller(sellerInfo[3], sellerInfo[10]);
            }

            return null;
        }

        Product? ParseProductInfo(string? line, Product product)
        {
            var productInfo = line.Split(_separators);

            if (productInfo.Length >= 17 &&
                productInfo[0].Equals("VL") &&
                productInfo[1].Equals("1"))
            {
                return new Product(productInfo[2], productInfo[3], productInfo[6], decimal.Parse(productInfo[8]), int.Parse(productInfo[9]));
            }

            if (product != null &&
                productInfo.Length == 3 &&
                productInfo[0].Equals("VX") &&
                productInfo[1].Equals("VEKT"))
            {
                product.SetWeight(decimal.Parse(productInfo[2]));
            }

            return null;
        }
    }
}
