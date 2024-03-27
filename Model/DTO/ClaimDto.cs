using System.ComponentModel.DataAnnotations;

namespace iBrokerageWebApi.Model.DTO
{
    public class ClaimDto
    {
        [Key]
        public long ClaimReservedID { get; set; }
        public string? BranchID { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? NotifyDate { get; set; }
        public DateTime? LossDate { get; set; }
    }
}
