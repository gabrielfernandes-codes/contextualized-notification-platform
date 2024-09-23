
using Microsoft.AspNetCore.Http.HttpResults;
using Organizations.Domain.Entities;
using Organizations.Domain.Fixtures.Entities;

namespace Organizations.Api.Routes.Handlers;

#pragma warning disable CS1998 // Temporarily disable async warning
public static class GetOrganizationEndpoint
{
    public static async Task<Ok<Organization>> Handle()
    {
        {
            var organization = OrganizationFixture.CreateEntity();

            return TypedResults.Ok(organization);
        }
    }

}
#pragma warning restore CS1998 // Temporarily disable async warning