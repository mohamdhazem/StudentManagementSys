using MvcDay2Task.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDay2Task.ViewModel
{
    public class InstructorDeptsCrs
    {
        public int id { get; set; }
        public string? name { get; set; }
        public IFormFile? image { get; set; }
        public string? address { get; set; }
        public int salary { get; set; }
        public int departmentId { get; set; }
        public List<Department>? departments { get; set; }
        public int courseId { get; set; }
        public List<Course>? courses { get; set; }
    }
}
