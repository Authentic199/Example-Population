using Example.Entities;

namespace Example.Request;

public class CreateUserRequest
{
    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public string Password { get; set; } = default!;

    public UserOperationStatus Status { get; set; } = UserOperationStatus.Active;

    public CreateRoleRequest? Role { get; set; }
}
