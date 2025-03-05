namespace Restaurant.Models;

public partial class MasterServices : BaseEntity
{
    public int MasterServicesId { get; set; }

    public string? MasterServicesTitle { get; set; }

    public string? MasterServicesDesc { get; set; }

    public string? MasterServicesImage { get; set; }
}
