namespace Restaurant.Models;

public partial class MasterWorkingHours : BaseEntity
{
    public int MasterWorkingHoursId { get; set; }

    public string? MasterWorkingHoursName { get; set; }

    public string? MasterWorkingHoursTimeFormTo { get; set; }
}
