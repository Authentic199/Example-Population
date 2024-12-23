using AutoMapper;
using Example.Entities;
using Example.Request;
using Example.Response;

namespace Example.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<Role, RoleResponse>();
        CreateMap<Permission, PermissionResponse>();


        CreateMap<CreateUserRequest, User>();
        CreateMap<CreateRoleRequest, Role>();
        CreateMap<CreatePermissionRequest, Permission>();
    }
}
