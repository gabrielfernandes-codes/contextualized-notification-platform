namespace Organizations.Api.Http;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1/[area]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly ILogger<ApiControllerBase> _logger;

    public ApiControllerBase(ILogger<ApiControllerBase> logger)
    {
        _logger = logger;
    }
}