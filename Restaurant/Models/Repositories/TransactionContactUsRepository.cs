using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        public AppDbContext DB { get; }

        public TransactionContactUsRepository(AppDbContext _DB)
        {
            DB = _DB;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            DB.Update(data);
            DB.SaveChanges();
        }

        public void Add(TransactionContactUs entity)
        {

            entity.CreateDate = DateTime.Now;
            DB.TransactionContactUs.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, TransactionContactUs entity)
        {
            entity = Find(Id);
            DB.TransactionContactUs.Remove(entity);
            DB.SaveChanges();
        }

        public TransactionContactUs Find(int Id)
        {
            return DB.TransactionContactUs.SingleOrDefault(x => x.TransactionContactUsId == Id);
        }

        public void Update(int Id, TransactionContactUs entity)
        {




            DB.TransactionContactUs.Update(entity);
            DB.SaveChanges();
        }

        public List<TransactionContactUs> View()
        {
            return DB.TransactionContactUs.ToList();
        }

        public List<TransactionContactUs> ViewClient()
        {
            return DB.TransactionContactUs.ToList();
        }
    }
}
