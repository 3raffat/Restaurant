namespace Restaurant.ViewModels
{
    public class MasterContactUsInformationModel
    {
        public int MasterContactUsInformationId { get; set; }

        public string? MasterContactUsInformationIdesc { get; set; }

        public string? MasterContactUsInformationImageUrl { get; set; }

        public string? MasterContactUsInformationRedirect { get; set; }
        public IFormFile? File { get; set; }
    }
}
