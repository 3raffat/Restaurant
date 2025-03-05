using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterFeedBackRepository : IRepository<MasterFeedBack>
    {
        public AppDbContext DB { get; }

        public MasterFeedBackRepository(AppDbContext _DB)
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

        public void Add(MasterFeedBack entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterFeedBacks.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterFeedBack entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterFeedBacks.Update(data);
            DB.SaveChanges();
        }

        public MasterFeedBack Find(int Id)
        {
            return DB.MasterFeedBacks.SingleOrDefault(x => x.MasterFeedBackId == Id);
        }

        public void Update(int Id, MasterFeedBack entity)
        {

            var data = Find(Id);
            data.MasterFeedBackDesc = entity.MasterFeedBackDesc;
            data.MasterFeedBackCustomerUrl = entity.MasterFeedBackCustomerUrl;
            data.MasterFeedBackCustomerName = entity.MasterFeedBackCustomerName;
            DB.MasterFeedBacks.Update(data);
            DB.SaveChanges();
        }

        public List<MasterFeedBack> View()
        {
            return DB.MasterFeedBacks.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterFeedBack> ViewClient()
        {
            return DB.MasterFeedBacks.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
