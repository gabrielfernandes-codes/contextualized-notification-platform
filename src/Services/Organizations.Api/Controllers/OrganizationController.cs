namespace Organizations.Api.Controllers;

using Organizations.Api.Entity;

public class OrganizationController
{
    public static IResult Create()
    {
        var organization = new Organization { Id = Guid.NewGuid().ToString() };

        return TypedResults.Created(organization.Id, organization);
    }
}
