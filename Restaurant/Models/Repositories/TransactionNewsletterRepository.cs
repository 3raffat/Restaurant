using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        public AppDbContext DB { get; }

        public TransactionNewsletterRepository(AppDbContext _DB)
        {
            DB = _DB;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            DB.Update(data);
            DB.SaveChanges();
        }

        public void Add(TransactionNewsletter entity)
        {

            entity.CreateDate = DateTime.Now;
            DB.TransactionNewsletters.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
            entity = Find(Id);
            DB.TransactionNewsletters.Remove(entity);
            DB.SaveChanges();
        }

        public TransactionNewsletter Find(int Id)
        {
            return DB.TransactionNewsletters.SingleOrDefault(x => x.TransactionNewsletterId == Id);
        }

        public void Update(int Id, TransactionNewsletter entity)
        {
            var data = Find(Id);



            DB.TransactionNewsletters.Update(entity);
            DB.SaveChanges();
        }

        public List<TransactionNewsletter> View()
        {
            return DB.TransactionNewsletters.ToList();
        }

        public List<TransactionNewsletter> ViewClient()
        {
            return DB.TransactionNewsletters.ToList();
        }
    }
}
