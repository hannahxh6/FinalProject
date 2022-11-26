using FinalProject.DBModels;
using FinalProject.Models;

namespace FinalProject.Services
{
    public class StudentService : IStudentService
    {
        public postgresContext _context;
        private object element;

        public StudentService(postgresContext context)
        {
            _context = context;
        }

        public Student AddStudent(StudentRequest body)
        {
                var result = _context.Students.Where(element => element.FName.ToLower() == body.Fname.ToLower() &&
                element.LName.ToLower() == body.Lname.ToLower()).FirstOrDefault();
                if (result != null)
                {
                    throw new Exception("User already exist");
                }
                Student student = new Student();

                student.Fname = body.Fname;
                student.Lname = body.Lname;
                student.NrAme = body.NrAme;
                student.Email = body.Email;

                var response = _context.Students.Add(student);
                _context.SaveChanges();
                return response.Entity;
            }

        
    }
}
