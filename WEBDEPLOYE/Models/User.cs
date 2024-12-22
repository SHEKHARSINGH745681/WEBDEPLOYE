using System;
namespace WEBDEPLOYE.Models
{
	public class User
	{
        public int Id { get; set; }  // Property for user ID
        public string? Email { get; set; }  // Property for email
        public string? Name { get; set; }  // Property for first name
        public string? Password { get; set; }
    }
}

