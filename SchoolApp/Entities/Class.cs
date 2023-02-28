using System;
using System.Collections.Generic;

namespace SchoolApp.Entities;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudentDetail> StudentDetails { get; } = new List<StudentDetail>();
}
