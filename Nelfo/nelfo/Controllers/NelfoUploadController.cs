using Microsoft.AspNetCore.Mvc;

namespace cwproj.Controllers;

public class HealthCheckRequest
{
    public bool? CheckMoreStuff { get; set; }
}

public class HealthCheckResponse
{
    public string? Message { get; set; }
}

public class ProductsFromFileResponse
{
    public Seller? Seller { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}

public class Product
{
    public string? ProductNo { get; set; }
    public string? Description { get; set; }
    public string? PriceUnit { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public decimal? Weight { get; set; }

    public Product(string? productNo, string? description, string? priceUnit, decimal? price, int? quantity)
    {
        ProductNo = productNo;
        Description = description;
        PriceUnit = priceUnit;
        Price = price;
        Quantity = quantity;
    }
}

public class Seller
{
    public string? OrgNo { get; }
    public string? OrgName { get; }

    public Seller(string? orgNo, string? orgName)
    {
        OrgNo = orgNo;
        OrgName = orgName;
    }
}


[ApiController]
[Route("[controller]/[action]")]
public class NelfoUploadController : ControllerBase
{
    private readonly char[] _separators = { ';' };
    private readonly ILogger<NelfoUploadController> _logger;

    public NelfoUploadController(ILogger<NelfoUploadController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public HealthCheckResponse HealthCheck(HealthCheckRequest? req)
    {
        _logger.LogInformation($"HealthCheck: {req?.CheckMoreStuff??false}");

        return new HealthCheckResponse()
        {
            Message = "OK"
        };
    }

    [HttpPost]
    public ProductsFromFileResponse ProductsFromFile(IFormFile file)
    {
        _logger.LogInformation($"Received file {file.FileName} with size in bytes {file.Length}");

        //process file content
        Seller? seller;
        List<Product> products = new List<Product>();

        //var result = new StringBuilder();
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
                    products.Add(nextProduct);

                //result.AppendLine(line);
            }
        }
        
        //var dummy = result.ToString();

        return new ProductsFromFileResponse()
        {
            Seller = seller,
            Products = products
        };
    }

    Seller? ParseSellerInfo(string? header)
    {
        var sellerArray = header.Split(_separators);

        if (sellerArray.Length < 11) return null;
        if (!sellerArray[0].Equals("VH")) return null;
        if (!sellerArray[1].Equals("EFONELFO")) return null;
        if (!sellerArray[2].Equals("4.0")) return null;

        return new Seller(sellerArray[3], sellerArray[10]);
    }

    Product? ParseProductInfo(string? line, Product product)
    {
        var productArray = line.Split(_separators);

        if (productArray.Length >= 17 &&
            productArray[0].Equals("VL") &&
            productArray[1].Equals("1"))
        {
            return new Product(productArray[2], productArray[3], productArray[6], decimal.Parse(productArray[8]), int.Parse(productArray[9]));
        }

        return null;
    }
}
