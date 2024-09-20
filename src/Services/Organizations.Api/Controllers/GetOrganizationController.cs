
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Organizations.Api.Http;
using Organizations.Domain.Entities;
using Organizations.Domain.Fixtures.Entities;

namespace Organizations.Api.Controllers;

#pragma warning disable CS1998 // Temporarily disable async warning
[Area("organizations")]
public class GetOrganizationController : ApiV1ControllerBase
{
    public GetOrganizationController(ILogger<ApiV1ControllerBase> logger) : base(logger) { }

    [HttpGet("{id}")]
    public async Task<Ok<Organization>> Index()
    {
        var organization = OrganizationFixture.CreateEntity();

        _logger.LogInformation("Organization retrieved: {Id}", organization.Id);

        return TypedResults.Ok(organization);
    }
}
#pragma warning restore CS1998 // Temporarily disable async warning