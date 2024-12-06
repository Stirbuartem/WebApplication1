using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ItEnglish
{
    public int Iduser { get; set; }

    public int Idteacher { get; set; }

    public int Idmanager { get; set; }

    public int Idcurator { get; set; }

    public int IdCourses { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Curator? Curator { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public virtual User? User { get; set; }
}
