using System.ComponentModel.DataAnnotations;

namespace iBrokerageWebApi.Model.Domain
{
    public class Policy
    {
        [Key]
        public string PolicyNo { get; set; } = "";
        public string CoPolicyNo { get; set; } = "";
        public string BranchID { get; set; } = "";
        public string Branch { get; set; } = "";
        public string BizSource { get; set; } = "";
    }
}
