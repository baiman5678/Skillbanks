using BCrypt.Net;
namespace SkillExchangeAPI.Services
{
    public class PassWordService
    {
        public string HashPassword(string password)
        {
            //使用BCrypt.Net 加密
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            // 使用BCrypt.Net來驗證密碼
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
