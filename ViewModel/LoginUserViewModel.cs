using System.ComponentModel.DataAnnotations;

namespace MvcDay2Task.ViewModel
{
    public class LoginUserViewModel
    {
        [Display(Name ="User Name")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }

    }
}
