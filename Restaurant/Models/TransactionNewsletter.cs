namespace Restaurant.Models;

public partial class TransactionNewsletter
{
    public int TransactionNewsletterId { get; set; }

    public string? TransactionNewsletterEmail { get; set; }
    public string? CreateId { get; set; }
    public DateTime CreateDate { get; set; }
}
