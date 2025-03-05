namespace Restaurant.Models;

public partial class MasterMenu : BaseEntity
{
    public int MasterMenuId { get; set; }

    public string MasterMenuName { get; set; } = null!;

    public string MasterMenuUrl { get; set; } = null!;
}
