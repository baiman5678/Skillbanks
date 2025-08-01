using System.ComponentModel.DataAnnotations.Schema;

namespace SkillExchangeAPI.Models
{
    [Table("Users")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public string Avatar { get; set; }//頭像
        public string PasswordHash { get; set; } //存放加密後的密碼

        public string Salt { get; set; } //加密用的鹽值
        public int SkillPoints { get; set; }
        public string PhoneNumber { get; set; } //電話號碼  
        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
