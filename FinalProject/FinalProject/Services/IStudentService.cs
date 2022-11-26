using FinalProject.DBModels;
using FinalProject.Models;

namespace FinalProject.Services
{
    public interface IStudentService
    {
        public Student AddStudent(StudentRequest body);
    }
}
