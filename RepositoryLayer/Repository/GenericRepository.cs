using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> entities;
        public GenericRepository()
        {
            this._context = new ApplicationDbContext();
            entities = _context.Set<T>();
        }
        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            entities = _context.Set<T>();
        }

        public void Create(T entity) 
        {
            if (entity == null) 
                throw new ArgumentNullException("entity create error");
                entities.Add(entity);
                Save();
        }
        
        public void Delete(T entity)
        {
                if (entity == null)
                    throw new ArgumentNullException("entity delete error");
                entities.Remove(entity);
                Save();
        }

        public ICollection<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public void Remove(T entity)
        {
            if(entity == null)
                    throw new ArgumentNullException("entity remove error");
            entities.Remove(entity);
        }
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity delete error");
            entities.Update(entity);
            Save();
        } 
        public void Save()
        {
            _context.SaveChanges();
        }
    }
 }