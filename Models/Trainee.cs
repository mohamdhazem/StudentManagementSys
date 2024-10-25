using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDay2Task.Models
{
    public class Trainee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? image { get; set; }
        [NotMapped]
        public IFormFile? realImage { get; set; }
        public string address { get; set; }
        public string grade { get; set; }

        [ForeignKey("Department")]
        public int departmentId { get; set; }
        public Department? department { get; set; }
        public List<CrsResult>? crsResults { get; set; }
    }
}
