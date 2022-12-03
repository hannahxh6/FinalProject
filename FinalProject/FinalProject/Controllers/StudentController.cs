using FinalProject.DBModels;
using FinalProject.Models;
using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentRequest body)
        {
            try
            {
                var result = _studentService.AddStudent(body);
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }
        public ActionResult Read()
        {
            return View();
        }
        [HttpGet]

        public IActionResult read()
        {
            try
            {
                var result = _studentService.GetAllStudents();
                //return Ok(result);
                return View(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }
       

    }
}
