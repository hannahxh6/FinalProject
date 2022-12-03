namespace FinalProject.Models
{
    public class StudentResponse
    {
        public int Id { get; set; }

        public string? StudentId { get; set; }

        public string? Fname { get; set; }

        public string? Lname { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string? NrAme { get; set; }
    }
}
