using MvcDay2Task.Models;

namespace MvcDay2Task.Repository
{
    public interface IInstructorRepository:IRepository<Instructor>
    {
        public Instructor? GetByIdWithNav(int id);
        public List<Instructor> FilteredInstructors(string name,int? DeptId);
    }
}
