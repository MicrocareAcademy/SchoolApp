using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudentSubject> StudentSubjects { get; } = new List<StudentSubject>();
}
