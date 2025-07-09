using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkillExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("AuthController is working!");
        }
        // 其他的認證相關方法可以在這裡添加
    }
}
