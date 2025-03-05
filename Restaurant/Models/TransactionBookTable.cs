namespace Restaurant.Models;

public partial class TransactionBookTable : BaseEntity
{
    public int TransactionBookTableId { get; set; }

    public string? TransactionBookTableFullName { get; set; }

    public string? TransactionBookTableEmail { get; set; }

    public string? TransactionBookTableMobileNumber { get; set; }

    public DateTime? TransactionBookTableDate { get; set; }
}
