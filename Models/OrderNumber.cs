using System;
using System.Collections.Generic;

namespace FurnitureStore.Models;

public partial class OrderNumber
{
    public int OrderNumberId { get; set; }

    public Guid? TransactionId { get; set; }

    public virtual ICollection<BillingTable> BillingTables { get; set; } = new List<BillingTable>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
