namespace Organizations.Domain.DataTransferObjects;

public class OrganizationDatabaseModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}