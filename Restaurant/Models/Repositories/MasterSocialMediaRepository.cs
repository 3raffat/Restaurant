using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        public AppDbContext DB { get; }

        public MasterSocialMediaRepository(AppDbContext _DB)
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

        public void Add(MasterSocialMedia entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterSocialMedias.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterSocialMedia entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterSocialMedias.Update(data);
            DB.SaveChanges();
        }

        public MasterSocialMedia Find(int Id)
        {
            return DB.MasterSocialMedias.SingleOrDefault(x => x.MasterSocialMediaId == Id);
        }

        public void Update(int Id, MasterSocialMedia entity)
        {
            var data = Find(Id);
            data.MasterSocialMediaUrl = entity.MasterSocialMediaUrl;
            data.MasterSocialMediaImageUrl = entity.MasterSocialMediaImageUrl;

            DB.MasterSocialMedias.Update(data);
            DB.SaveChanges();
        }

        public List<MasterSocialMedia> View()
        {
            return DB.MasterSocialMedias.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedia> ViewClient()
        {
            return DB.MasterSocialMedias.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
