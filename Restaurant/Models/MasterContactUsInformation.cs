namespace Restaurant.Models;

public partial class MasterContactUsInformation : BaseEntity
{
    public int MasterContactUsInformationId { get; set; }

    public string? MasterContactUsInformationIdesc { get; set; }

    public string? MasterContactUsInformationImageUrl { get; set; }

    public string? MasterContactUsInformationRedirect { get; set; }
}
