using Population.Public;

namespace Example.Entities;

public class Permission : BaseEntity
{
    public string Code { get; set; } = default!;

    public string Name { get; set; } = default!;

    public Guid RoleId { get; set; }

    public Role? Role { get; set; }
}
