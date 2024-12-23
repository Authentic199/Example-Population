using AutoMapper;
using AutoMapper.QueryableExtensions;
using Example.Entities;
using Example.Request;
using Example.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Population;

namespace Example.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ApplicationDbContext context;

    public UserController(IMapper mapper, ApplicationDbContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request)
    {
        User user = mapper.Map<User>(request);
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("UsingProjectTo")]
    public async Task<IActionResult> GetAllAsync()
    {
        List<UserResponse> response = await context.Users
            .ProjectTo<UserResponse>(mapper.ConfigurationProvider)
            .ToListAsync();

        return Ok(response);
    }


    [HttpGet("SimplePopulation")]
    public async Task<IActionResult> GetAllWithSimplePopulationAsync([FromQuery] QueryContext queryContext)
    {
        List<dynamic> response = await context.Users
            .ProjectDynamic<UserResponse>(mapper, queryContext.Populate)
            .ToListAsync();

        return Ok(response);
    }


    [HttpGet("PopulationWithDataManipulation")]
    public async Task<IActionResult> GetAllWithSimplePopulationWithDataManipulationAsync([FromQuery] QueryContext queryContext)
    {
        PaginationResponse<dynamic> response = await context.Users.CompileQueryAsync<UserResponse>(queryContext, mapper);

        return Ok(response);
    }
}
