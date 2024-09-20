

using Organizations.Domain.DataTransferObjects;

namespace Organizations.Domain.Entities;

public class Organization
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Organization()
    {
        Id = Guid.NewGuid();

        var now = DateTime.UtcNow;

        CreatedAt = now;
        UpdatedAt = now;
    }

    public static Organization Create()
    {
        return new Organization();
    }

    public Organization WithName(string? name)
    {
        SetName(name);

        UpdatedAt = DateTime.UtcNow;

        return this;
    }

    public static Organization HydrateFromDto(OrganizationDatabaseModel dto)
    {
        return new Organization
        {
            Id = dto.Id,
            Name = dto.Name,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt
        };
    }

    private void SetName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Name = null;
        }
        else
        {
            Name = name;
        }
    }
}