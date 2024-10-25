using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MvcDay2Task.Models;
using MvcDay2Task.Repository;
using MvcDay2Task.ViewModel;
using NuGet.Protocol.Core.Types;

namespace MvcDay2Task.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TraineeController : Controller
    {
        ITraineeRepository traineeRepository;
        IDepartmentRepository departmentRepository;
        public TraineeController(ITraineeRepository traineeRepository,IDepartmentRepository departmentRepository)
        {
            this.traineeRepository = traineeRepository;
            this.departmentRepository = departmentRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Trainee> trainees = traineeRepository.GetAll();
            return View("Index",trainees);
        }
        public IActionResult showResult(int id, int crsid)
        {
            CrsResult? crsDetails = traineeRepository.crsResult(id, crsid);

            if (crsDetails == null)
                return Content("unMatched Trainee With Course");

            TraineeCrs traineeCrs = new TraineeCrs();
            traineeCrs.TraineeName = crsDetails.trainee.name;
            traineeCrs.crsName = crsDetails.course.name;
            traineeCrs.degree = crsDetails.degree;

            if (crsDetails.course.minDegree > crsDetails.degree)
                traineeCrs.state = "Failed";
            else
               traineeCrs.state = "Sucsess";

            return View("showResult",traineeCrs);
        }
        public IActionResult GetDetails(int id)
        {
            Trainee? trainee = traineeRepository.GetById(id);
            List<CrsResult>? crsResults = traineeRepository.crsResults(id);

            TraineeCrsDetails traineeCrsDetails = new TraineeCrsDetails();
            traineeCrsDetails.id = trainee.id;
            traineeCrsDetails.address = trainee.address;
            traineeCrsDetails.image = trainee.image;
            traineeCrsDetails.name = trainee.name;
            traineeCrsDetails.grade = trainee.grade;
            traineeCrsDetails.departmentId = trainee.departmentId;
            traineeCrsDetails.crsResults = crsResults;

            if (trainee != null)
            {
                return View("GetDetails", traineeCrsDetails);
            }
            return Content("In Valid Id !!");
        }
        public IActionResult Add()
        {
            TraineeWithDepts traineeWithDepts = new TraineeWithDepts();
            traineeWithDepts.departments = departmentRepository.GetAll();
            return View("Add", traineeWithDepts);
        }
        public async Task<IActionResult> SaveAdd(Trainee trainee)
        {

            if (ModelState.IsValid && trainee.realImage != null && trainee.realImage.Length > 0)
            {
                var fileName = Path.GetFileName(trainee.realImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await trainee.realImage.CopyToAsync(stream);
                }

                trainee.image = $"/images/{fileName}";          

                traineeRepository.Add(trainee);               
                traineeRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            TraineeWithDepts traineeWithDepts = new TraineeWithDepts();
            traineeWithDepts.name = trainee.name;
            traineeWithDepts.address = trainee.address;
            traineeWithDepts.departmentId = trainee.departmentId;
            traineeWithDepts.grade = trainee.grade;
            traineeWithDepts.image = trainee.realImage.ToString();
            traineeWithDepts.departments = departmentRepository.GetAll();

            return View("Add", traineeWithDepts);
        }
        public IActionResult Delete(int id)
        {
            Trainee? trainee = traineeRepository.GetById(id);
            traineeRepository.Delete(trainee);
            traineeRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Search(string name) 
        {
            List<Trainee> trainees = traineeRepository.FilteredTrainees(name);

            return View("Index", trainees);
        }
    }
}
