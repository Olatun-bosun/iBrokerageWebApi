namespace iBrokerageWebApi.Model
{
    public class Claim
    {
        public string ClaimNo { get; set; } = "";
        public long ClaimReservedID { get; set; }
        public string BranchID { get; set; } = "";
        public DateTime? EntryDate { get; set; }
        public DateTime? NotifyDate { get; set; }
        public DateTime? LossDate { get; set; }
    }
}
