using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterServicesRepository : IRepository<MasterServices>
    {
        public AppDbContext DB { get; }

        public MasterServicesRepository(AppDbContext _DB)
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

        public void Add(MasterServices entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterServices.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterServices entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterServices.Update(data);
            DB.SaveChanges();
        }

        public MasterServices Find(int Id)
        {
            return DB.MasterServices.SingleOrDefault(x => x.MasterServicesId == Id);
        }

        public void Update(int Id, MasterServices entity)
        {
            var data = Find(Id);
            data.MasterServicesTitle = entity.MasterServicesTitle;
            data.MasterServicesDesc = entity.MasterServicesDesc;
            data.MasterServicesImage = entity.MasterServicesImage;

            DB.MasterServices.Update(data);
            DB.SaveChanges();
        }

        public List<MasterServices> View()
        {
            return DB.MasterServices.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterServices> ViewClient()
        {
            return DB.MasterServices.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
