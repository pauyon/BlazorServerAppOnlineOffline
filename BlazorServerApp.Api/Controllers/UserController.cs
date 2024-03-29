﻿using BlazorServerApp.DataStorageSqlServer;
using BlazorServerApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SqlServerDataContext _sqlServerContext;

        public UserController(SqlServerDataContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _sqlServerContext.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
            var user = await _sqlServerContext.Users.FindAsync(id);

            if (user == null)
            {
                return BadRequest("User does not exist.");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _sqlServerContext.Users.Add(user);
            await _sqlServerContext.SaveChangesAsync();

            return Ok(await _sqlServerContext.Users.ToListAsync());
        }
    }
}
