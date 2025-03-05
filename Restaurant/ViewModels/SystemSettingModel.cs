namespace Restaurant.ViewModels
{
    public class SystemSettingModel
    {
        public int SystemSettingId { get; set; }

        public string? SystemSettingLogoImageUrl { get; set; }
        public IFormFile? FileLogo1 { get; set; }

        public string? SystemSettingLogoImageUrl2 { get; set; }
        public IFormFile? FileLogo2 { get; set; }
        public string? SystemSettingCopyright { get; set; }

        public string? SystemSettingWelcomeNoteTitle { get; set; }

        public string? SystemSettingWelcomeNoteBreef { get; set; }

        public string? SystemSettingWelcomeNoteDesc { get; set; }

        public string? SystemSettingWelcomeNoteUrl { get; set; }

        public string? SystemSettingWelcomeNoteImageUrl { get; set; }
        public IFormFile? FileNote { get; set; }

        public string? SystemSettingMapLocation { get; set; }
        public string? contactUsEmail { get; set; }
        public string? contactUsPhone { get; set; }
        public string? contactUsLocation { get; set; }
    }
}
