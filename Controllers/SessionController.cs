using Microsoft.AspNetCore.Mvc;

namespace MvcDay2Task.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult SetSession(string name)
        {
            HttpContext.Session.SetString("Name",name);
            return View();
        }
        public IActionResult GetSession()
        {
            string? n = HttpContext.Session.GetString("Name");
            return Content($"name:{n} ");
        }
    }
}
