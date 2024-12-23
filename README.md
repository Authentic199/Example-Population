This is example source code using Population.NET libraries

- **Models**

    ```csharp
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
    ```

    ```csharp
    public class Role : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public ICollection<User> Users { get; set; } = default!;

        public ICollection<Permission> Permissions { get; set; } = default!;
    }
    ```

    ```csharp
    public class Permission : BaseEntity
    {
        public string Code { get; set; } = default!;

        public string Name { get; set; } = default!;

        public Guid RoleId { get; set; }

        public Role? Role { get; set; }
    }

    ```
- **Response DTOs**
    ```csharp
    public class UserResponse : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string UserName { get; set; } = default!;

        public string Password { get; set; } = default!;

        public UserOperationStatus Status { get; set; } = UserOperationStatus.Active;

        public RoleResponse? Role { get; set; }
    }
    ```
    
    ```csharp
    public class RoleResponse : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public ICollection<PermissionResponse> Permissions { get; set; } = default!;
    }
    ```

    
    ```csharp
    public class PermissionResponse : BaseEntity
    {
        public string Code { get; set; } = default!;

        public string Name { get; set; } = default!;
    }
    ```

- **Config mapping**

    ```csharp
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<Role, RoleResponse>();
            CreateMap<Permission, PermissionResponse>();
        }
    }
    ```

- **Prepare Test Data**

    Let’s create a simple API for **creating users** and use the provided test data.

    ```csharp
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request)
    {
        User user = mapper.Map<User>(request);
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return Ok();
    }
    ```

    **Example JSON Payload**

    ```json
    {
      "name": "John Doe",
      "email": "john.doe@example.com",
      "userName": "johndoe123",
      "password": "Password@123",
      "status": 1,
      "role": {
        "name": "Admin",
        "description": "Administrator role with full access",
        "permissions": [
               {
                  "code": "READ",
                  "name": "Read Access"
               },
               {
                  "code": "WRITE",
                  "name": "Write Access"
               }
            ]
        }
    }
    ```
    
    ```json
    {
       "name": "Jane Smith",
       "email": "jane.smith@example.com",
       "userName": "janesmith456",
       "password": "SecurePass@2024",
       "status": 1,
       "role": {
        "name": "Editor",
        "description": "Editor role with limited access",
        "permissions": [
                {
                    "code": "UPDATE",
                    "name": "Update Access"
                }
            ]
        }
    }
    ```
---