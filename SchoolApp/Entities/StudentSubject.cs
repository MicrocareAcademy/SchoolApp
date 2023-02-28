using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class StudentSubject
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public virtual StudentDetail Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
