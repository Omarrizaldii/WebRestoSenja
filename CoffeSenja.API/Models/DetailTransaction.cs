using System;
using System.Collections.Generic;

namespace CoffeSenja.API.Models;

public partial class DetailTransaction
{
    public int Id { get; set; }

    public int HeaderTransactionId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual HeaderTransaction HeaderTransaction { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
