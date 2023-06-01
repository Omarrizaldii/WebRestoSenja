using System;
using System.Collections.Generic;

namespace CoffeSenja.API.Models;

public partial class PointHistory
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int HeaderTransactionId { get; set; }

    public int PointGained { get; set; }

    public int PointDeducated { get; set; }

    public int PointBefore { get; set; }

    public int PointAfter { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual HeaderTransaction HeaderTransaction { get; set; } = null!;
}
