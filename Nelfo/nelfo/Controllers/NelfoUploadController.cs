using Microsoft.AspNetCore.Mvc;
using nelfo.Dtos;
using nelfo.Services;

namespace nelfo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class NelfoUploadController : ControllerBase
{
    private readonly ILogger<NelfoUploadController> _logger;
    private readonly INelfoReader _nelfoReader;

    public NelfoUploadController(ILogger<NelfoUploadController> logger, INelfoReader nelfoReader)
    {
        _logger = logger;
        _nelfoReader = nelfoReader;
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
    public SellerProductsResponse SellerProducts(IFormFile file)
    {
        _logger.LogInformation($"Received file {file.FileName} with size in bytes {file.Length}");

        return _nelfoReader.ReadSellerProducts(file);
    }
}
