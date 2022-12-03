using FinalProject.DBModels;
using FinalProject.Models;

namespace FinalProject.Services
{
    public class StudentService : IStudentService
    {
        public PostgresContext _context;

        public StudentService(PostgresContext context)
        {
            _context = context;
        }

        public Student AddStudent(StudentRequest body)
        {
                var result = _context.Students.Where(element => element.Fname.ToLower() == body.Fname.ToLower() &&
                element.Lname.ToLower() == body.Lname.ToLower()).FirstOrDefault();
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

        public List<StudentResponse> GetAllStudents()
        {
            var result = (from student in _context.Students
                          select new StudentResponse()
                          {
                              Id = student.Id,
                              Fname = student.Fname,
                              Email = student.Email,
                              NrAme = student.NrAme
                          }).ToList();
            return result;
        }
    }
}
