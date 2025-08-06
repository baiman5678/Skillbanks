using System.ComponentModel.DataAnnotations.Schema;

namespace SkillExchangeAPI.Models
{
    [Table("SkillExchange")]
    public class SkillExchangeModel
    {//技能交換紀錄
        public int ID { get; set; } //技能交換紀錄ID
        public int? TeacherId { get; set; } //教學者ID
        public int LearnerId { get; set; } //學習者ID
        public string SkillDescription { get; set; } //技能描述

        public string ? WantSkill { get; set; } //想學的技能
        public string?Description { get; set; } //交換描述
        public int ?PointsUsed { get; set; } //使用的技能點數
        public string? Status { get; set; } //交換狀態（例如：Pending、Completed、Cancelled）
        public string? Findtype { get; set; } 

        public DateTime? ExchangeDate { get; set; } //交換日期
        public DateTime? UpdateAt { get; set; } //更新時間
    }
}
