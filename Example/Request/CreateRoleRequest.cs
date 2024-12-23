namespace Example.Request;

public class CreateRoleRequest
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public List<CreatePermissionRequest>? Permissions { get; set; }
}
