namespace Organizations.Api.Controllers;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Organizations.Api.Http;
using Organizations.Api.Models;

#pragma warning disable CS1998 // Temporarily disable async warning
[Area("organizations")]
public class GetOrganizationController : ApiV1ControllerBase
{
    public GetOrganizationController(ILogger<ApiV1ControllerBase> logger) : base(logger) { }

    [HttpGet("{id}")]
    public async Task<Ok<Organization>> Index()
    {
        var organization = new Organization
        {
            Id = Guid.NewGuid().ToString(),
        };

        _logger.LogInformation("Organization retrieved: {Id}", organization.Id);

        return TypedResults.Ok(organization);
    }
}
#pragma warning restore CS1998 // Temporarily disable async warning