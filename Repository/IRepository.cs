using MvcDay2Task.Models;

namespace MvcDay2Task.Repository
{
    public interface IRepository<T>
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void SaveChanges();
        public List<T> GetAll();
        public T? GetById(int id);
    }
}
