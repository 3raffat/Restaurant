using Restaurant.Data;

namespace Restaurant.Models.Repositories
{

    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        public AppDbContext DB { get; }

        public MasterCategoryMenuRepository(AppDbContext _DB)
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

        public void Add(MasterCategoryMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterCategoryMenus.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterCategoryMenus.Update(data);
            DB.SaveChanges();
        }

        public MasterCategoryMenu Find(int Id)
        {
            return DB.MasterCategoryMenus.SingleOrDefault(x => x.MasterCategoryMenuId == Id);
        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
            var data = Find(Id);
            data.MasterCategoryMenuName = entity.MasterCategoryMenuName;
            DB.MasterCategoryMenus.Update(data);
            DB.SaveChanges();
        }

        public List<MasterCategoryMenu> View()
        {
            return DB.MasterCategoryMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterCategoryMenu> ViewClient()
        {
            return DB.MasterCategoryMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }

}
