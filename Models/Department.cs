namespace MvcDay2Task.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string manager { get; set; }
        public List<Instructor>? instructors { get;  set; }
        public List<Trainee>? trainees { get; set; }
        public List<Course>? courses { get; set; }

    }
}
