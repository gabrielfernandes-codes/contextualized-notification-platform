namespace Organizations.Api.Controllers;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Organizations.Api.Http;
using Organizations.Api.Models;

#pragma warning disable CS1998 // Temporarily disable async warning
[Area("organizations")]
public class CreateOrganizationController : ApiControllerBase
{
    public CreateOrganizationController(ILogger<ApiControllerBase> logger) : base(logger) { }

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