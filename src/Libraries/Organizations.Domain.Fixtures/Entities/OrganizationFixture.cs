using Organizations.Domain.DataTransferObjects;
using Organizations.Domain.Entities;

namespace Organizations.Domain.Fixtures.Entities;

public class OrganizationFixture
{
    public static Organization CreateEntity()
    {
        var now = DateTime.UtcNow;

        var dto = new OrganizationDatabaseModel
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "Organization Name",
            CreatedAt = now.AddMonths(-1),
            UpdatedAt = now.AddHours(-1)
        };

        return Organization.HydrateFromDto(dto);
    }
}