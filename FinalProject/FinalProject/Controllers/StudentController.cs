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
        [HttpPost("/addStudent")]
        public Student AddStudent(StudentRequest body)
        {
            return _studentService.AddStudent(body);
        }

    }
}
