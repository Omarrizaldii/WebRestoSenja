namespace CoffeSenja.API.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public int Gender { get; set; }

    public int Role { get; set; }

    public int Point { get; set; }

    public string? PhotoPath { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<HeaderTransaction> HeaderTransactions { get; set; } = new List<HeaderTransaction>();

    public virtual ICollection<PointHistory> PointHistories { get; set; } = new List<PointHistory>();
}