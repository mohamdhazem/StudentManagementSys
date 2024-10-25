using MvcDay2Task.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDay2Task.ViewModel
{
    public class TraineeWithDepts
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string image { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string grade { get; set; }
        [Required]
        public int departmentId { get; set; }
        public List<Department> departments { get; set; }   
    }

}
