using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Curator
{
    public int Idcurator { get; set; }

    public int Iduser { get; set; }

    public int Visiruser { get; set; }

    public int Paymentuser { get; set; }

    public virtual ItEnglish IdcuratorNavigation { get; set; } = null!;

    public virtual User? User { get; set; }
}
