namespace Restaurant.Models.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(int Id, T entity);
        void Delete(int Id, T entity);
        void Active(int Id);
        List<T> View();
        T Find(int Id);
        List<T> ViewClient();
    }
}
