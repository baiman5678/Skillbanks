namespace SkillExchangeAPI.Models
{
    public class SkillExchangeModel
    {//技能交換紀錄
        public int Id { get; set; } //技能交換紀錄ID
        public int TeacherId { get; set; } //教學者ID
        public int LearnerId { get; set; } //學習者ID

        public int SkillId { get; set; } //技能ID
        public DateTime ExchangeDate { get; set; } //交換日期
        public string Description { get; set; } //交換描述
        public int PointsUsed { get; set; } //使用的技能點數
        public string Status { get; set; } //交換狀態（例如：Pending、Completed、Cancelled）

    }
}
