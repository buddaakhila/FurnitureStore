using System;
using System.Collections.Generic;

namespace FurnitureStore.Models;

public partial class CustomerMaster
{
    public int CustomerId { get; set; }

    public string? Username { get; set; }

    public string Password { get; set; } = null!;

    public string? Displayname { get; set; }

    public long? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<BillingTable> BillingTables { get; set; } = new List<BillingTable>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
