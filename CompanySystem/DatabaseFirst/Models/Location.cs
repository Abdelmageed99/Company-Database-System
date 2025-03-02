using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class Location
{
    public int Dnum { get; set; }

    public int LocationId { get; set; }

    public string Location1 { get; set; } = null!;

    public virtual Department DnumNavigation { get; set; } = null!;
}
