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

public class ProductsByFileNameResponse
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

    public Product(string? productNo, string? description, string? priceUnit, decimal? price, int? quantity, decimal? weight)
    {
        ProductNo = productNo;
        Description = description;
        PriceUnit = priceUnit;
        Price = price;
        Quantity = quantity;
        Weight = weight;
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

    [HttpGet]
    public ProductsByFileNameResponse ProductsByFileName([FromQuery]string fileName)
    {
        _logger.LogInformation($"Getting products from {fileName ?? string.Empty} ...");

        return new ProductsByFileNameResponse()
        {
            Seller = new Seller("aa", "bb"),
            Products = new List<Product>()
        };
    }
}
