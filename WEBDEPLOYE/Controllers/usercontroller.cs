using System;
using Microsoft.AspNetCore.Mvc;
using WEBDEPLOYE.DATA;
using WEBDEPLOYE.Models;

namespace WEBDEPLOYE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("add")]
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
        [Route("get")]
        [HttpGet]
        public IActionResult GetUserById()
        {
            var user = _context.Users.Find();
            if (user == null)
            {
                return NotFound($"User with ID  not found.");
            }
            return Ok(user);
        }
    }
}