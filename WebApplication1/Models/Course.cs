using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Course
{
    public int Idcourses { get; set; }

    public int Idmanager { get; set; }

    public int Idteacher { get; set; }

    public virtual ItEnglish IdcoursesNavigation { get; set; } = null!;

    public virtual Manager? Manager { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
