using System;
using System.Collections.Generic;

namespace CoffeSenja.API.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int Stock { get; set; }

    public string? ImageName { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<DetailTransaction> DetailTransactions { get; set; } = new List<DetailTransaction>();
}
