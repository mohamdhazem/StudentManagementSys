using MvcDay2Task.Models;

namespace MvcDay2Task.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly Context context;
        public CourseRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Course course)
        {
            context.Add(course);
        }
        public void Update(Course course)
        {
            context.Update(course);
        }
        public void Delete(Course course)
        {
            context.Remove(course);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public List<Course> GetAll()
        {
            return context.courses.ToList();
        }
        public Course? GetById(int id)
        {
            return context.courses.FirstOrDefault(c => c.id == id);
        }
    }
}
