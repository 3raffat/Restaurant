namespace Restaurant.ViewModels
{
    public class MasterServicesModel
    {
        public int MasterServicesId { get; set; }

        public string? MasterServicesTitle { get; set; }

        public string? MasterServicesDesc { get; set; }

        public string? MasterServicesImage { get; set; }
        public IFormFile? File { get; set; }
    }
}
