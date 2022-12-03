using System;
using System.Collections.Generic;

namespace FinalProject.DBModels;

public partial class Student
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? NrAme { get; set; }
}
