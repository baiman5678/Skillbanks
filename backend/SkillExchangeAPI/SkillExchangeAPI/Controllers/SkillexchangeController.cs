using Microsoft.AspNetCore.Mvc;
using SkillExchangeAPI.Data;
using SkillExchangeAPI.DTOs;
using SkillExchangeAPI.Models;
using SkillExchangeAPI.Services;
namespace SkillExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillexchangeController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly PassWordService _passWordService;
        public SkillexchangeController(ILogger<AuthController> logger, ApplicationDbContext context, PassWordService passWord)
        {
            _logger = logger;
            _context = context;
            _passWordService = passWord;
        }
        [HttpGet("GetExchanges")]
        public IActionResult GetExchanges()
        {
            var exchanges = _context.SkillExchanges.ToList();
            if (exchanges == null || !exchanges.Any())
            {
                return NotFound("No skill exchanges found.");
            }
            return Ok(exchanges);
        }

        [HttpPost("BuildExchange")]
        public IActionResult BuildExchange(SkillExchangeDTO skillExchange)
        {
            if (skillExchange == null || skillExchange.LearnerID == null || skillExchange.SkillDescription == null)
            {
                return BadRequest("Invalid skill exchange data.");
            }
            var user = _context.Users.FirstOrDefault(u => u.Id == skillExchange.LearnerID);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            var skillExchangeModel = new SkillExchangeModel
            {
                ID = _context.SkillExchanges.Any() ? _context.SkillExchanges.Max(s => s.ID) + 1 : 1, // Get the next ID
                LearnerId = skillExchange.LearnerID,
                SkillDescription = skillExchange.SkillDescription,
                Findtype = skillExchange.Findtype,
                WantSkill = skillExchange.WantSkill,
                Description = skillExchange.Description,
                Status = "媒合中", // Default status to "Pending"
                ExchangeDate = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };
            _context.Add(skillExchangeModel);
            _context.SaveChanges();
            return Ok("Skill exchange created successfully.");
        }
        [HttpPut("ModifyExchange")]
        public IActionResult ModifyExchange(ModifyExchangeDTO MDExchange)
        {
            if (MDExchange == null || MDExchange.ID == null || MDExchange.SkillDescription == null)
            {
                return BadRequest("Invalid skill exchange data.");
            }
            var exchange = _context.SkillExchanges.FirstOrDefault(s => s.ID == MDExchange.ID);
            if (exchange == null)
            {
                return NotFound("Skill exchange not found.");
            }
            exchange.SkillDescription = MDExchange.SkillDescription;
            exchange.WantSkill = MDExchange.WantSkill;
            exchange.Description = MDExchange.Description;
            exchange.Findtype = MDExchange.Findtype;
            exchange.UpdateAt = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok("Skill exchange modified successfully.");
        }


    }
}
