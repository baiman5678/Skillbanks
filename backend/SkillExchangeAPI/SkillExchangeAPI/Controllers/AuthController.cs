using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillExchangeAPI.Data;
using SkillExchangeAPI.Models;
using SkillExchangeAPI.DTOs;
namespace SkillExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ApplicationDbContext _context;
        public AuthController(ILogger<AuthController> logger ,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO registrate)
        {
            try 
            {
                if (registrate == null || string.IsNullOrEmpty(registrate.Email) || string.IsNullOrEmpty(registrate.Password))
                {
                    return BadRequest("Invalid registration data.");
                }

                var existingUser = _context.Users.Where(u => u.Email == registrate.Email).Select(u=>u.Email).FirstOrDefault();
                if (existingUser != null)
                {
                    return Conflict("Email already exists.");
                }
                //先確認資料行
                int nowid = _context.Users.Any() ? _context.Users.Max(u => u.Id) + 1 : 1; // Get the next ID
                // Create a new user
                var newUser = new UserModel
                {
                    Id = nowid,
                    Email = registrate.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(registrate.Password),// Hash the password
                    CreateAt = DateTime.UtcNow,
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return Ok("Registration successful.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during registration.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        
        





    }
}
