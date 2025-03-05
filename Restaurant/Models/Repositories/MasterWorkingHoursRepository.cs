using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterWorkingHoursRepository : IRepository<MasterWorkingHours>
    {
        public AppDbContext DB { get; }

        public MasterWorkingHoursRepository(AppDbContext _DB)
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

        public void Add(MasterWorkingHours entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterWorkingHours.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterWorkingHours entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterWorkingHours.Update(data);
            DB.SaveChanges();
        }

        public MasterWorkingHours Find(int Id)
        {
            return DB.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHoursId == Id);
        }

        public void Update(int Id, MasterWorkingHours entity)
        {
            var data = Find(Id);
            data.MasterWorkingHoursTimeFormTo = entity.MasterWorkingHoursTimeFormTo;
            data.MasterWorkingHoursName = entity.MasterWorkingHoursName;
            DB.MasterWorkingHours.Update(data);
            DB.SaveChanges();
        }

        public List<MasterWorkingHours> View()
        {
            return DB.MasterWorkingHours.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHours> ViewClient()
        {
            return DB.MasterWorkingHours.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
