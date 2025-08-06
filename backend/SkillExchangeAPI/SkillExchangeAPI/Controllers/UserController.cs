using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillExchangeAPI.Data;
using SkillExchangeAPI.DTOs;
using SkillExchangeAPI.Services;

namespace SkillExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly PassWordService _passWordService;
        public UserController(ILogger<AuthController> logger, ApplicationDbContext context, PassWordService passWord)
        {
            _logger = logger;
            _context = context;
            _passWordService = passWord;
        }
        [HttpGet]
        public IActionResult getUserInfo(string email)
        {
           var user = _context.Users.AsNoTracking().FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(new
            {
                user.Email,
                user.Name,
                user.SkillPoints,
                user.PhoneNumber,
            });

        }

        [HttpPut("Update")]
        public IActionResult UpdateUserInfo(UpdateUserDTO updateUser)
        {
            try
            {
                if (updateUser == null || string.IsNullOrEmpty(updateUser.Email))
                {
                    return BadRequest("Invalid user data.");
                }
                var user = _context.Users.FirstOrDefault(u => u.Email == updateUser.Email);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                user.Name = updateUser.Name;
                user.PhoneNumber = updateUser.PhoneNumber;
                user.UpdateAt = DateTime.UtcNow;
                _context.SaveChanges();
                return Ok("User information updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating user information.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
