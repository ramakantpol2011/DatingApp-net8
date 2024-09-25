using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController(DataContext dataContext) : ControllerBase
{
    private readonly DataContext _context = dataContext;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users =await _context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id:int}")]   // /api/users/id
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if(user==null) return NotFound();

        return user;
    }
}
