using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Organizations.Api.Http;
using Organizations.Api.Models;

namespace Organizations.Api.Controllers;

#pragma warning disable CS1998 // Temporarily disable async warning
[Area("organizations")]
public class CreateOrganizationController : ApiV1ControllerBase
{
    public CreateOrganizationController(ILogger<ApiV1ControllerBase> logger) : base(logger) { }

    [HttpPost()]
    public async Task<Created<Organization>> Index()
    {
        var organization = new Organization
        {
            Id = Guid.NewGuid().ToString(),
        };

        _logger.LogInformation("Organization created: {Id}", organization.Id);

        return TypedResults.Created(organization.Id, organization);
    }
}
#pragma warning restore CS1998 // Temporarily disable async warning