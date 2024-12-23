using Population.Public;

namespace Example.Response;

public class PermissionResponse : BaseEntity
{
    public string Code { get; set; } = default!;

    public string Name { get; set; } = default!;
}
