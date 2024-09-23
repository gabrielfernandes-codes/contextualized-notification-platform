using Microsoft.AspNetCore.Http.HttpResults;
using Organizations.Domain.Entities;
using Organizations.Domain.Fixtures.Entities;

namespace Organizations.Api.Routes.Handlers;

#pragma warning disable CS1998 // Temporarily disable async warning
public static class CreateOrganizationEndpoint
{
    public static async Task<Created<Organization>> Handle()
    {
        {
            var organization = OrganizationFixture.CreateEntity();

            return TypedResults.Created(organization.Id.ToString(), organization);
        }
    }

}
#pragma warning restore CS1998 // Temporarily disable async warning