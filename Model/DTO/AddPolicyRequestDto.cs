using System.ComponentModel.DataAnnotations;

namespace iBrokerageWebApi.Model.DTO
{
    public class AddPolicyRequestDto
    {
        [Key]
        public string PolicyNo { get; set; }
        public string? CoPolicyNo { get; set; }
        public string? BranchID { get; set; }
        public string? Branch { get; set; }
        public string? BizSource { get; set; }
    }
}
