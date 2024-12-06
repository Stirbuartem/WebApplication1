using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int Iduser { get; set; }

    public string Name { get; set; } = null!;

    public string? Surname { get; set; }

    public int Age { get; set; }

    public string? EMail { get; set; }

    public string Password { get; set; } = null!;

    public int Idteacher { get; set; }

    public virtual ItEnglish Iduser1 { get; set; } = null!;

    public virtual Manager Iduser2 { get; set; } = null!;

    public virtual Curator IduserNavigation { get; set; } = null!;

    public virtual Teacher? Teacher { get; set; }
}
