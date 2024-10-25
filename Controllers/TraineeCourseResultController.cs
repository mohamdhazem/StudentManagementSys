using Microsoft.AspNetCore.Mvc;
using MvcDay2Task.Models;
using MvcDay2Task.Repository;
using MvcDay2Task.ViewModel;

namespace MvcDay2Task.Controllers
{
    public class TraineeCourseResultController : Controller
    {
        private readonly ITraineeCrsResultRepository traineeCrsResultRepository;
        private readonly ITraineeRepository traineeRepository;
        private readonly ICourseRepository courseRepository;

        public TraineeCourseResultController(ITraineeCrsResultRepository traineeCrsResultRepository,ITraineeRepository traineeRepository,ICourseRepository courseRepository)
        {
            this.traineeCrsResultRepository = traineeCrsResultRepository;
            this.traineeRepository = traineeRepository;
            this.courseRepository = courseRepository;
        }

        public IActionResult Add(int id)
        {
            ViewBag.coursesList = courseRepository.GetAll();
            ViewBag.id = id;    
            return View("Add");
        }

        public IActionResult SaveAdd(int id, TraineeCrsResultViewModel traineeCrsResultViewModel) 
        {
            CrsResult crsResult = new CrsResult();
            crsResult.traineeId=id;
            crsResult.courseId = traineeCrsResultViewModel.CourseId;
            crsResult.degree = traineeCrsResultViewModel.Degree;

            traineeCrsResultRepository.Add(crsResult);
            traineeCrsResultRepository.SaveChanges();
            return RedirectToAction("GetDetails", "Trainee", new { id = id });
        }

        public IActionResult Delete(int courseid,int traineeId)
        {
            CrsResult crsResult = traineeCrsResultRepository.GetById(courseid);
            traineeCrsResultRepository.Delete(crsResult);
            traineeCrsResultRepository.SaveChanges();

            return RedirectToAction("GetDetails", "Trainee", new { id = traineeId });
        }
    }
}
