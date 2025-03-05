namespace Restaurant.ViewModels
{
    public class MasterPartnerModel
    {
        public int MasterPartnerId { get; set; }

        public string? MasterPartnerName { get; set; }

        public string? MasterPartnerLogoImageUrl { get; set; }

        public string? MasterPartnerWebsiteUrl { get; set; }
        public IFormFile? File { get; set; }
    }
}
