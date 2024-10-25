using System.ComponentModel.DataAnnotations;

namespace MvcDay2Task.ViewModel
{
    public class TraineeCrsResultViewModel
    {
        [Display(Name ="Trainee Name")]
        public string TraineeName { get; set; }
        public int TraineeId { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public int Degree { get; set; }

    }
}
