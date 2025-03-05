using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        public AppDbContext DB { get; }

        public MasterOfferRepository(AppDbContext _DB)
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

        public void Add(MasterOffer entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterOffers.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterOffer entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterOffers.Update(data);
            DB.SaveChanges();
        }

        public MasterOffer Find(int Id)
        {
            return DB.MasterOffers.SingleOrDefault(x => x.MasterOfferId == Id);
        }

        public void Update(int Id, MasterOffer entity)
        {
            var data = Find(Id);
            data.MasterOfferTitle = entity.MasterOfferTitle;
            data.MasterOfferDesc = entity.MasterOfferDesc;
            data.MasterOfferBreef = entity.MasterOfferBreef;
            data.MasterOfferImageUrl = entity.MasterOfferImageUrl;
            DB.Update(data);
            DB.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return DB.MasterOffers.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return DB.MasterOffers.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
