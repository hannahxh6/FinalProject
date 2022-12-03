using FinalProject.DBModels;
using FinalProject.Models;

namespace FinalProject.Services
{
    public interface IStudentService
    {
        public List<StudentResponse> GetAllStudents();
        public Student AddStudent(StudentRequest body);
    }
}
