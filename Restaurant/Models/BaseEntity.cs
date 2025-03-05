namespace Restaurant.Models
{
    public class BaseEntity
    {

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public string? CreateId { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? EditId { get; set; }
        public DateTime? EditDate { get; set; }

    }
}
