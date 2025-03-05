using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {
        public AppDbContext DB { get; }

        public SystemSettingRepository(AppDbContext _DB)
        {
            DB = _DB;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            DB.Update(data);
            DB.SaveChanges();
        }

        public void Add(SystemSetting entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.SystemSettings.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, SystemSetting entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.SystemSettings.Update(data);
            DB.SaveChanges();
        }

        public SystemSetting Find(int Id)
        {
            return DB.SystemSettings.SingleOrDefault(x => x.SystemSettingId == Id);
        }

        public void Update(int Id, SystemSetting entity)
        {
            var data = Find(Id);
            data.SystemSettingCopyright = entity.SystemSettingCopyright;
            data.SystemSettingMapLocation = entity.SystemSettingMapLocation;
            data.SystemSettingWelcomeNoteBreef = entity.SystemSettingWelcomeNoteBreef;
            data.SystemSettingWelcomeNoteDesc = entity.SystemSettingWelcomeNoteDesc;
            data.SystemSettingWelcomeNoteTitle = entity.SystemSettingWelcomeNoteTitle;
            data.SystemSettingWelcomeNoteUrl = entity.SystemSettingWelcomeNoteUrl;
            data.SystemSettingLogoImageUrl = entity.SystemSettingLogoImageUrl;
            data.SystemSettingLogoImageUrl2 = entity.SystemSettingLogoImageUrl2;
            data.SystemSettingWelcomeNoteImageUrl = entity.SystemSettingWelcomeNoteImageUrl;
            data.contactUsEmail = entity.contactUsEmail;
            data.contactUsPhone = entity.contactUsPhone;
            data.contactUsLocation = entity.contactUsLocation;
            DB.SystemSettings.Update(data);
            DB.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return DB.SystemSettings.Where(x => x.IsDelete == false).ToList();
        }

        public List<SystemSetting> ViewClient()
        {
            return DB.SystemSettings.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
