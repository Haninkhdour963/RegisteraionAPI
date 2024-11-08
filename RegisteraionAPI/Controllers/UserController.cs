using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using RegisteraionAPI.Model;
using RegistrationAPI.Data;
using System.Threading.Tasks;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegistrationContext _context;

        public UserController(RegistrationContext context)
        {
            _context = context;
        }

        // POST: api/User/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == user.Email);
    
                if (existingUser != null)
                    return BadRequest("User with this email already exists.");

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); // Hash the password for security
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "User registered successfully" });
            }
            return BadRequest("Invalid data.");
        }

        // GET: api/User/GetUser/{id}
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }
    }
}
