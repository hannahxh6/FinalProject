using System;
using System.Collections.Generic;

namespace FinalProject.DBModels;

public partial class Result
{
    public int Id { get; set; }

    public string StudentId { get; set; } = null!;

    public string ProfId { get; set; } = null!;

    public string TestType { get; set; } = null!;

    public string Score { get; set; } = null!;
}
