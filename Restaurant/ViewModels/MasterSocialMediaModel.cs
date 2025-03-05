namespace Restaurant.ViewModels
{
    public class MasterSocialMediaModel
    {
        public int MasterSocialMediaId { get; set; }

        public string MasterSocialMediaImageUrl { get; set; }
        public string MasterSocialMediaName { get; set; }

        public string MasterSocialMediaUrl { get; set; }
        public IFormFile? File { get; set; }
    }
}
