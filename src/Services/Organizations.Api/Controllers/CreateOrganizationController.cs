using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Organizations.Api.Http;
using Organizations.Domain.Entities;
using Organizations.Domain.Fixtures.Entities;

namespace Organizations.Api.Controllers;

#pragma warning disable CS1998 // Temporarily disable async warning
[Area("organizations")]
public class CreateOrganizationController : ApiV1ControllerBase
{
    public CreateOrganizationController(ILogger<ApiV1ControllerBase> logger) : base(logger) { }

    [HttpPost()]
    public async Task<Created<Organization>> Index()
    {
        var organization = OrganizationFixture.CreateEntity();

        _logger.LogInformation("Organization created: {Id}", organization.Id);

        return TypedResults.Created(organization.Id.ToString(), organization);
    }
}
#pragma warning restore CS1998 // Temporarily disable async warning