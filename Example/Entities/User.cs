using Population.Public;

namespace Example.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public string Password { get; set; } = default!;

    public UserOperationStatus Status { get; set; } = UserOperationStatus.Active;

    public Guid RoleId { get; set; }

    public Role? Role { get; set; }
}

public enum UserOperationStatus
{
    /// <summary>
    /// Active
    /// </summary>
    Active = 1,

    /// <summary>
    /// Locked
    /// </summary>
    Locked = 2,
}
