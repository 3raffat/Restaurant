using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<MasterCategoryMenu> MasterCategoryMenus { get; set; }

        public DbSet<MasterContactUsInformation> MasterContactUsInformations { get; set; }

        public DbSet<MasterItemMenu> MasterItemMenus { get; set; }

        public DbSet<MasterMenu> MasterMenus { get; set; }

        public DbSet<MasterOffer> MasterOffers { get; set; }

        public DbSet<MasterPartner> MasterPartners { get; set; }

        public DbSet<MasterServices> MasterServices { get; set; }

        public DbSet<MasterSlider> MasterSliders { get; set; }

        public DbSet<MasterSocialMedia> MasterSocialMedias { get; set; }

        public DbSet<MasterWorkingHours> MasterWorkingHours { get; set; }

        public DbSet<SystemSetting> SystemSettings { get; set; }

        public DbSet<TransactionBookTable> TransactionBookTables { get; set; }

        public DbSet<TransactionContactUs> TransactionContactUs { get; set; }

        public DbSet<TransactionNewsletter> TransactionNewsletters { get; set; }
        public DbSet<MasterFeedBack> MasterFeedBacks { get; set; }


    }
}
