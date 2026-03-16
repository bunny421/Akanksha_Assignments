using System;
using System.Collections.Generic;

namespace BDFirstEFinAsp.Models;

public partial class View2
{
    public string? CompanyName { get; set; }

    public int? OrderId { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? Quantity { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal? Expr1 { get; set; }
}
