using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    internal readonly object Iduser1;

    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

}

