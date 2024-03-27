
namespace iBrokerageWebApi.Model.DTO
{
    public class AddClaimRequest
    {
        public string? BranchID { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? NotifyDate { get; set; }
        public DateTime? LossDate { get; set; }

    }
}
