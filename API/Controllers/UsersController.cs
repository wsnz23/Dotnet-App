using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class UserController(DataContext context) : ControllerBase
{
[HttpGet]
public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
{
    var users = await context.Users.ToListAsync();
    return users;
}


[HttpGet("{id:int}")] // /api/users/2
public async Task<ActionResult<AppUser>> GetUser(int id)
{
    var user = await context.Users.FindAsync(id); // Await the ValueTask

    if (user == null)
        return NotFound(); // Return a 404 response if the user is not found

    return user; // Return the user as the ActionResult
}

}