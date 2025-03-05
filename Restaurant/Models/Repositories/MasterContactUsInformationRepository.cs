using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        public AppDbContext DB { get; }

        public MasterContactUsInformationRepository(AppDbContext _DB)
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

        public void Add(MasterContactUsInformation entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterContactUsInformations.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterContactUsInformation entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterContactUsInformations.Update(data);
            DB.SaveChanges();
        }

        public MasterContactUsInformation Find(int Id)
        {
            return DB.MasterContactUsInformations.SingleOrDefault(x => x.MasterContactUsInformationId == Id);
        }

        public void Update(int Id, MasterContactUsInformation entity)
        {
            var data = Find(Id);
            data.MasterContactUsInformationIdesc = entity.MasterContactUsInformationIdesc;
            data.MasterContactUsInformationRedirect = entity.MasterContactUsInformationRedirect;
            data.MasterContactUsInformationImageUrl = entity.MasterContactUsInformationImageUrl;
            DB.MasterContactUsInformations.Update(data);
            DB.SaveChanges();
        }

        public List<MasterContactUsInformation> View()
        {
            return DB.MasterContactUsInformations.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterContactUsInformation> ViewClient()
        {
            return DB.MasterContactUsInformations.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
