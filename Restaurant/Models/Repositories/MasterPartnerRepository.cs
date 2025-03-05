using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        public AppDbContext DB { get; }

        public MasterPartnerRepository(AppDbContext _DB)
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

        public void Add(MasterPartner entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterPartners.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterPartner entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterPartners.Update(data);
            DB.SaveChanges();
        }

        public MasterPartner Find(int Id)
        {
            return DB.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == Id);
        }

        public void Update(int Id, MasterPartner entity)
        {
            var data = Find(Id);
            data.MasterPartnerWebsiteUrl = entity.MasterPartnerWebsiteUrl;
            data.MasterPartnerLogoImageUrl = entity.MasterPartnerLogoImageUrl;
            data.MasterPartnerName = entity.MasterPartnerName;

            DB.MasterPartners.Update(data);
            DB.SaveChanges();
        }

        public List<MasterPartner> View()
        {
            return DB.MasterPartners.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
            return DB.MasterPartners.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
