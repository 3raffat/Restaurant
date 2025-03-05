using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class MasterItemMenuModel
    {
        public int MasterItemMenuId { get; set; }
        public string? MasterItemMenuTitle { get; set; }

        //public string? MasterItemMenuBreef { get; set; }

        public string? MasterItemMenuDesc { get; set; }

        public decimal? MasterItemMenuPrice { get; set; }

        public string? MasterItemMenuImageUrl { get; set; }
        public IFormFile? File { get; set; }

        public DateTime? MasterItemMenuDate { get; set; }
        public int? MasterCategoryMenuId { get; set; }

        public MasterCategoryMenu? MasterCategoryMenu { get; set; }
    }
}
