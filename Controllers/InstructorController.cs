using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcDay2Task.Models;
using MvcDay2Task.Repository;
using MvcDay2Task.ViewModel;

namespace MvcDay2Task.Controllers;

public class InstructorController : Controller
{
    IInstructorRepository instructorRepository;
    IDepartmentRepository departmentRepository;
    ICourseRepository courseRepository;

    
    public InstructorController(IInstructorRepository insRepository, IDepartmentRepository deptRepository, ICourseRepository crsRepository)
    {
        instructorRepository = insRepository;
        departmentRepository = deptRepository;
        courseRepository = crsRepository;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        List<Instructor> instructors = instructorRepository.GetAll();
        ViewData["depts"] = departmentRepository.GetAll();
        return View("Index",instructors);
    }
    public IActionResult GetDetails(int id)
    {
        Instructor? instructor = instructorRepository.GetByIdWithNav(id);

        if(instructor != null)
        {
            return View("GetDetails", instructor);
        }
        return Content("In Valid Id !!");
    }
    public IActionResult Add()
    {
        InstructorDeptsCrs instructorDeptsCrs = new InstructorDeptsCrs();
        instructorDeptsCrs.departments = departmentRepository.GetAll();
        instructorDeptsCrs.courses = courseRepository.GetAll();
        return View("Add", instructorDeptsCrs);
    }
    public async Task<IActionResult> SaveAdd(Instructor instructor) 
    {

        if (ModelState.IsValid && instructor.realImage != null && instructor.realImage.Length > 0)
        {
            // Define the path where the file will be saved
            var fileName = Path.GetFileName(instructor.realImage.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            // Ensure the directory exists
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Save the file to the specified path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await instructor.realImage.CopyToAsync(stream);
            }

            // Store the file path or filename in the database
            instructor.image = $"/images/{fileName}";

            //mycontext.instructors.Add(instructor);
            instructorRepository.Add(instructor);
            instructorRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        InstructorDeptsCrs instructorDeptsCrs = new InstructorDeptsCrs();
        instructorDeptsCrs.name = instructor.name;
        instructorDeptsCrs.address = instructor.address;
        instructorDeptsCrs.departmentId = instructor.departmentId;
        instructorDeptsCrs.courseId = instructor.courseId ?? 0 ;
        instructorDeptsCrs.image = instructor.realImage;
        instructorDeptsCrs.salary = instructor.salary;

        instructorDeptsCrs.departments = departmentRepository.GetAll();
        instructorDeptsCrs.courses = courseRepository.GetAll();
        
        return View("Add", instructorDeptsCrs);
    }
    public IActionResult Edit(int id)
    {

        Instructor instructor = instructorRepository.GetById(id);

        InstructorDeptsCrs instructorDeptsCrs = new InstructorDeptsCrs();
        instructorDeptsCrs.id = instructor.id;
        instructorDeptsCrs.name = instructor.name;
        instructorDeptsCrs.address = instructor.address;
        instructorDeptsCrs.departmentId = instructor.departmentId;
        instructorDeptsCrs.courseId = instructor.courseId ?? 0;
        instructorDeptsCrs.image = instructor.realImage;
        instructorDeptsCrs.salary = instructor.salary;

        instructorDeptsCrs.departments = departmentRepository.GetAll();
        instructorDeptsCrs.courses = courseRepository.GetAll();

        return View("Edit",instructorDeptsCrs);
    }

    public async Task<IActionResult> SaveEdit(int id,InstructorDeptsCrs instructorDeptsCrs)
    {
        //if(ModelState.IsValid && instructorDeptsCrs.image )
        Instructor instructor = instructorRepository.GetById(id);

        if(instructor.realImage == null && instructorDeptsCrs.image != null) 
        {
            instructor.realImage = instructorDeptsCrs.image;
            var fileName = Path.GetFileName(instructor.realImage.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            // Ensure the directory exists
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Save the file to the specified path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await instructor.realImage.CopyToAsync(stream);
            }

            // Store the file path or filename in the database
            instructor.image = $"/images/{fileName}";
        }

        instructor.name = instructorDeptsCrs.name;
        instructor.address = instructorDeptsCrs.address;
        instructor.departmentId = instructorDeptsCrs.departmentId;
        instructor.courseId = instructorDeptsCrs.courseId;
        instructor.salary = instructorDeptsCrs.salary;

        instructorRepository.Update(instructor);
        instructorRepository.SaveChanges();

        return RedirectToAction("Index");
    }
    public IActionResult Delete(int id)
    {
        Instructor? ins=instructorRepository.GetById(id);
        instructorRepository.Delete(ins);
        instructorRepository.SaveChanges();

        return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public IActionResult Search(string name,int DeptId)
    {
        List<Instructor> filteredInstructors = instructorRepository.FilteredInstructors(name,DeptId);

        ViewData["depts"] = departmentRepository.GetAll();
        return View("Index",filteredInstructors);
    }
}
