using Example.Entities;
using Population.Public;

namespace Example.Response;

public class UserResponse : BaseEntity
{
    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public string Password { get; set; } = default!;

    public UserOperationStatus Status { get; set; } = UserOperationStatus.Active;

    public RoleResponse? Role { get; set; }
}
