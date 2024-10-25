using Microsoft.AspNetCore.Mvc;

namespace MvcDay2Task.Controllers
{
    public class FiltterController : Controller
    {
        [HandleError]
        public IActionResult Index()
        {
            throw new Exception("Exception is throwed");
        }
    }
}
