using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Teacher
{
    public int Idteacher { get; set; }

    public int Age { get; set; }

    public int Price { get; set; }

    public string Diplomas { get; set; } = null!;

    public int? Workexperience { get; set; }

    public int Idcourses { get; set; }

    public virtual ItEnglish Idteacher1 { get; set; } = null!;

    public virtual User Idteacher2 { get; set; } = null!;

    public virtual Course IdteacherNavigation { get; set; } = null!;
}
