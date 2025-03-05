namespace Restaurant.Models;

public partial class SystemSetting : BaseEntity
{
    public int SystemSettingId { get; set; }

    public string? SystemSettingLogoImageUrl { get; set; }

    public string? SystemSettingLogoImageUrl2 { get; set; }

    public string? SystemSettingCopyright { get; set; }

    public string? SystemSettingWelcomeNoteTitle { get; set; }

    public string? SystemSettingWelcomeNoteBreef { get; set; }

    public string? SystemSettingWelcomeNoteDesc { get; set; }

    public string? SystemSettingWelcomeNoteUrl { get; set; }

    public string? SystemSettingWelcomeNoteImageUrl { get; set; }

    public string? SystemSettingMapLocation { get; set; }
    public string? contactUsEmail { get; set; }
    public string? contactUsPhone { get; set; }
    public string? contactUsLocation { get; set; }

}
