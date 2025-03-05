
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public AppDbContext DB { get; }

        public MasterMenuRepository(AppDbContext _DB)
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

        public void Add(MasterMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterMenus.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterMenus.Update(data);
            DB.SaveChanges();
        }

        public MasterMenu Find(int Id)
        {
            return DB.MasterMenus.SingleOrDefault(x => x.MasterMenuId == Id);
        }

        public void Update(int Id, MasterMenu entity)
        {

            var data = Find(Id);
            data.MasterMenuName = entity.MasterMenuName;
            DB.MasterMenus.Update(data);
            DB.SaveChanges();
        }

        public List<MasterMenu> View()
        {
            return DB.MasterMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterMenu> ViewClient()
        {
            return DB.MasterMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
