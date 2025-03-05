namespace Restaurant.Models;

public partial class TransactionContactUs
{
    public int TransactionContactUsId { get; set; }

    public string? TransactionContactUsFullName { get; set; }

    public string? TransactionContactUsEmail { get; set; }

    public string? TransactionContactUsSubject { get; set; }

    public string? TransactionContactUsMessage { get; set; }
    public string? CreateId { get; set; }
    public DateTime CreateDate { get; set; }
}
