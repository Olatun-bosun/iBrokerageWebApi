using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace iBrokerageWebApi.Model.DTO
{
    public class PolicyDto
    {
        [Key]
        public string PolicyNo { get; set; }
        public string? CoPolicyNo { get; set; }
        public string? BranchID { get; set; }
        public string? Branch { get; set; }
        public string? BizSource { get; set; }
    }
}
