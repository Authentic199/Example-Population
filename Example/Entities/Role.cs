using Population.Public;

namespace Example.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public ICollection<User> Users { get; set; } = default!;

    public ICollection<Permission> Permissions { get; set; } = default!;
}
