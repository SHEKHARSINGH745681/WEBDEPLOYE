using System;
using Microsoft.AspNetCore.Mvc;
using WEBDEPLOYE.Models;

namespace WEBDEPLOYE.Controllers
{
    [Route("api]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // In-memory list of users (for demonstration purposes)
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Email = "user1@example.com", Name = "John Doe", Password = "password123" },
            new User { Id = 2, Email = "user2@example.com", Name = "Jane Smith", Password = "password456" }
        };

        // GET api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(users);  // Return a list of users with HTTP 200 status code
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();  // Returns HTTP 404 if the user is not found
            }

            return Ok(user);  // Returns the found user with HTTP 200 status code
        }

        // POST api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Invalid user data.");  // Returns HTTP 400 if data is invalid
            }

            // Set an ID for the new user (simple approach here, but you'd likely use a database to generate IDs)
            newUser.Id = users.Max(u => u.Id) + 1;

            // Add the new user to the in-memory list (you would save this to the database in a real app)
            users.Add(newUser);

            // Return the created user with HTTP 201 status code
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }
    }
}