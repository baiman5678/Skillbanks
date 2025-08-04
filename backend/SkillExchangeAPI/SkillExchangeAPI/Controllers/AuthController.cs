using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillExchangeAPI.Data;
using SkillExchangeAPI.Models;
using SkillExchangeAPI.DTOs;
using SkillExchangeAPI.Services;
namespace SkillExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly PassWordService _passWordService;
        public AuthController(ILogger<AuthController> logger ,ApplicationDbContext context,PassWordService passWord)
        {
            _logger = logger;
            _context = context;
            _passWordService = passWord;
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
                    return Ok("Email already exists.");
                }
                //先確認資料行
                int nowid = _context.Users.Any() ? _context.Users.Max(u => u.Id) + 1 : 1; // Get the next ID
                // Create a new user
                var newUser = new UserModel
                {
                    Id = nowid,
                    Email = registrate.Email,
                    PasswordHash = _passWordService.HashPassword(registrate.Password),// Hash the password
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
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO login)
        {
            try
            {
                if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
                {
                    return BadRequest("Invalid login data.");
                }
                var user = _context.Users.Where(u=> u.Email == login.Email).FirstOrDefault();
                var passwordHash = user.PasswordHash;
                if (user == null)
                {
                    return Unauthorized("Invalid email or password.");
                }
                // Verify the password
                if (!_passWordService.VerifyPassword(login.Password, passwordHash))
                {
                    return Unauthorized("Invalid email or password.");
                }
                // Here you would typically generate a JWT token or session for the user
                return Ok("Login successful.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }






    }
}
