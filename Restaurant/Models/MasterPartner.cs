namespace Restaurant.Models;

public partial class MasterPartner : BaseEntity
{
    public int MasterPartnerId { get; set; }

    public string? MasterPartnerName { get; set; }

    public string? MasterPartnerLogoImageUrl { get; set; }

    public string? MasterPartnerWebsiteUrl { get; set; }
}
