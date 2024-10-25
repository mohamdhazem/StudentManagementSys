using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MvcDay2Task.Models;
using MvcDay2Task.Repository;

namespace MvcDay2Task.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public CourseController(ICourseRepository _courseRepository, IDepartmentRepository departmentRepository)//will be injected in ioc service in program.cs  
        {
            this.courseRepository = _courseRepository;
            this.departmentRepository = departmentRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Course> courses = courseRepository.GetAll();
            return View("Index",courses);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["depts"]=departmentRepository.GetAll();
            return View("Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(Course course)
        {
            //if(course.name != null && course.departmentId != 0)
            if(ModelState.IsValid == true)
            {
                courseRepository.Add(course);
                courseRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["depts"] = departmentRepository.GetAll();
            return View("Add",course);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course course = courseRepository.GetById(id);

            ViewData["id"] = id;
            ViewData["depts"] = departmentRepository.GetAll();
            return View("Edit",course);
        }

        [HttpPost]
        public IActionResult SaveEdit(Course course)
        {
            //if(course.name != null && course.departmentId != 0)
            if (ModelState.IsValid == true)
            {
                courseRepository.Update(course);
                courseRepository.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewData["depts"] = departmentRepository.GetAll();
            return View("Edit", course);
        }

        public IActionResult Delete(int id)
        {
            Course? csr = courseRepository.GetById(id);
            courseRepository.Delete(csr);
            courseRepository.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult DegreeCheck(int Degree,int minDegree)
        {
            if (Degree >= minDegree)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
