namespace RepositoryLayer.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void Save();
    }
}
