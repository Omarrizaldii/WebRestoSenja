using System;
using System.Collections.Generic;

namespace CoffeSenja.API.Models;

public partial class HeaderTransaction
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int PaymentTypeId { get; set; }

    public DateTime Datetime { get; set; }

    public decimal SubTotal { get; set; }

    public int PointUsed { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<DetailTransaction> DetailTransactions { get; set; } = new List<DetailTransaction>();

    public virtual PaymentType PaymentType { get; set; } = null!;

    public virtual ICollection<PointHistory> PointHistories { get; set; } = new List<PointHistory>();
}
