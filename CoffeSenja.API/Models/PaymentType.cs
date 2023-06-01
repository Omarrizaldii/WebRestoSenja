using System;
using System.Collections.Generic;

namespace CoffeSenja.API.Models;

public partial class PaymentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<HeaderTransaction> HeaderTransactions { get; set; } = new List<HeaderTransaction>();
}
