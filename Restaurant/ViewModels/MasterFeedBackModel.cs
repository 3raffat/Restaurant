namespace Restaurant.ViewModels
{
    public class MasterFeedBackModel
    {
        public int MasterFeedBackId { get; set; }
        public string MasterFeedBackDesc { get; set; }
        public string MasterFeedBackCustomerUrl { get; set; }
        public string MasterFeedBackCustomerName { get; set; }
        public IFormFile? CustomerImg { get; set; }
    }
}
