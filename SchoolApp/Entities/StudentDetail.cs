using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class StudentDetail
{
    public int Id { get; set; }

    public string FName { get; set; } = null!;

    public string LName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<StudentSubject> StudentSubjects { get; } = new List<StudentSubject>();
}
