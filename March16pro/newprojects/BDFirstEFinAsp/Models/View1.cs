using System;
using System.Collections.Generic;

namespace BDFirstEFinAsp.Models;

public partial class View1
{
    public DateTime? OrderDate { get; set; }

    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? City { get; set; }
}
