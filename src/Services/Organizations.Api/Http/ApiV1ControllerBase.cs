namespace Organizations.Api.Http;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1/[area]")]
public abstract class ApiV1ControllerBase : ControllerBase
{
    protected readonly ILogger<ApiV1ControllerBase> _logger;

    public ApiV1ControllerBase(ILogger<ApiV1ControllerBase> logger)
    {
        _logger = logger;
    }
}