using MvcDay2Task.Models;

namespace MvcDay2Task.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly Context context;
        public DepartmentRepository(Context context)
        {
            this.context = context;
        }
        public void Add(Department dept)
        {
            context.Add(dept);
        }
        public void Update(Department dept)
        {
            context.Update(dept);
        }
        public void Delete(Department dept)
        {
            context.Remove(dept);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public List<Department> GetAll()
        {
            return context.departments.ToList();
        }
        public Department? GetById(int id)
        {
            return context.departments.FirstOrDefault(d => d.Id == id);
        }             
    }
}
