using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDay2Task.Models
{
    public class Course
    {
        public int id { get; set; }


        [MinLength(2,ErrorMessage ="name must be greater than 2 letter")]
        [MaxLength(30, ErrorMessage = "name must be less than 30 letter")]
        public string? name { get; set; }

        [Remote(action:"DegreeCheck",controller:"Course"
                                    ,ErrorMessage ="Degree must be greater than MinDegree", AdditionalFields = "minDegree")]
        [Display(Name = "Maximum Degree")]
        public int degree { get; set; }

        [Display(Name = "Minimum Degree")]
        [Range(20,50,ErrorMessage ="range should be between (20,50)")]
        public int minDegree { get; set; }
        [Range(1,200,ErrorMessage ="Hours must be greater than 1 ")]
        public int hours { get; set; }

        [ForeignKey("Department")]
        public int departmentId { get; set; }
        public Department? department { get; set; }
        public List<Instructor>? instructors { get; set; }
        public List<CrsResult>? crsResults { get; set; }
    }
}
