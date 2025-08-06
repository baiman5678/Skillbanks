using Microsoft.EntityFrameworkCore;

namespace SkillExchangeAPI.Data
{
    public class ApplicationDbContext: DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Models.UserModel> Users { get; set; } // 用戶表
        public DbSet<Models.SkillExchangeModel> SkillExchanges { get; set; } // 技能交換紀錄表

    }
}
