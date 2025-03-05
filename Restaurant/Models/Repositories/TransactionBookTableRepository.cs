using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        public AppDbContext DB { get; }

        public TransactionBookTableRepository(AppDbContext _DB)
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

        public void Add(TransactionBookTable entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.TransactionBookTables.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.TransactionBookTables.Update(data);
            DB.SaveChanges();
        }

        public TransactionBookTable Find(int Id)
        {
            return DB.TransactionBookTables.SingleOrDefault(x => x.TransactionBookTableId == Id);
        }

        public void Update(int Id, TransactionBookTable entity)
        {


            DB.TransactionBookTables.Update(entity);
            DB.SaveChanges();
        }

        public List<TransactionBookTable> View()
        {
            return DB.TransactionBookTables.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionBookTable> ViewClient()
        {
            return DB.TransactionBookTables.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
