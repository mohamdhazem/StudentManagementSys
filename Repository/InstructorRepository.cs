using Microsoft.EntityFrameworkCore;
using MvcDay2Task.Models;

namespace MvcDay2Task.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly Context context;
        public InstructorRepository(Context context)
        {
            this.context = context;
        }
        public void Add(Instructor instructor)
        {
            context.Add(instructor);
        }
        public void Update(Instructor instructor)
        {
            context.Update(instructor);
        }

        public void Delete(Instructor instructor)
        {
            context.Remove(instructor);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public List<Instructor> GetAll()
        {
            return context.instructors.ToList();
        }

        public Instructor? GetById(int id)
        {
            return context.instructors.FirstOrDefault(i => i.id == id);
        }

        public Instructor? GetByIdWithNav(int id)
        {
            return context.instructors.Include(i => i.course).Include(i => i.department).FirstOrDefault(i => i.id == id);
        }

        public List<Instructor> FilteredInstructors(string name, int? DeptId)
        {
            var query = context.instructors.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(i => i.name.Contains(name));
            }

            if (DeptId.HasValue && DeptId.Value > 0)
            {
                query = query.Where(i => i.departmentId == DeptId.Value);
            }

            return query.ToList();
        }

    }
}
