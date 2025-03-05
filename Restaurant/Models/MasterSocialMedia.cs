namespace Restaurant.Models;

public partial class MasterSocialMedia : BaseEntity
{
    public int MasterSocialMediaId { get; set; }

    public string MasterSocialMediaImageUrl { get; set; }

    public string MasterSocialMediaUrl { get; set; }
}
