using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MvcDay2Task.Models
{
    public class Instructor
    {
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        public string? image { get; set; }
        [NotMapped]
        public IFormFile? realImage { get; set; }
        [Required]
        public string? address { get; set; }
        public int salary { get; set; }

        [ForeignKey("Department")]
        public int departmentId { get; set; }
        public Department? department { get; set; }
        
        [ForeignKey("Course")]
        public int? courseId { get; set; }
        public Course? course { get; set; }
    }
}
