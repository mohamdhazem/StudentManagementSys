using MvcDay2Task.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDay2Task.ViewModel
{
    public class TraineeCrsDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public string grade { get; set; }
        public int departmentId { get; set; }
        public List<CrsResult>? crsResults { get; set; }
    }
}
