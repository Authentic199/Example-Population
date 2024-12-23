using Population.Public;

namespace Example.Response;

public class RoleResponse : BaseEntity
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public ICollection<PermissionResponse> Permissions { get; set; } = default!;
}
