using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public AppDbContext DB { get; }

        public MasterItemMenuRepository(AppDbContext _DB)
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

        public void Add(MasterItemMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterItemMenus.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterItemMenus.Update(data);
            DB.SaveChanges();
        }

        public MasterItemMenu Find(int Id)
        {
            return DB.MasterItemMenus.Include(x => x.MasterCategoryMenu).SingleOrDefault(x => x.MasterItemMenuId == Id);
        }

        public void Update(int Id, MasterItemMenu entity)
        {
            var obj = Find(Id);
            obj.MasterCategoryMenu = entity.MasterCategoryMenu;
            obj.MasterItemMenuTitle = entity.MasterItemMenuTitle;
            obj.MasterItemMenuDesc = entity.MasterItemMenuDesc;
            obj.MasterItemMenuPrice = entity.MasterItemMenuPrice;
            obj.MasterItemMenuImageUrl = entity.MasterItemMenuImageUrl;

            DB.MasterItemMenus.Update(obj);
            DB.SaveChanges();
        }

        public List<MasterItemMenu> View()
        {
            return DB.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterItemMenu> ViewClient()
        {
            return DB.MasterItemMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
