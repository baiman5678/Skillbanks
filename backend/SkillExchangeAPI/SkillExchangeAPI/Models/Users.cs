namespace SkillExchangeAPI.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string Avatar { get; set; }
        public string PasswordHash { get; set; } //存放加密後的密碼

        public string Salt { get; set; } //加密用的鹽值
        public int SkillPoints { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
