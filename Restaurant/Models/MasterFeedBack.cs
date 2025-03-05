namespace Restaurant.Models
{
    public class MasterFeedBack : BaseEntity
    {
        public int MasterFeedBackId { get; set; }
        public string MasterFeedBackDesc { get; set; }
        public string MasterFeedBackCustomerUrl { get; set; }
        public string MasterFeedBackCustomerName { get; set; }

    }
}
