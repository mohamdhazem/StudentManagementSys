using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDay2Task.Models
{
    public class CrsResult
    {
        public int id { get; set; }
        public int degree { get; set; }

        [ForeignKey("Course")]
        public int? courseId { get; set; }
        public Course? course { get; set; }

        [ForeignKey("Trainee")]
        public int traineeId { get; set; }
        public Trainee? trainee { get; set; }
    }
}
