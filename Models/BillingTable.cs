using System;
using System.Collections.Generic;

namespace FurnitureStore.Models;

public partial class BillingTable
{
    public int BillingId { get; set; }

    public int? OrderNumberId { get; set; }

    public decimal? BillingAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CustomerId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual CustomerMaster? Customer { get; set; }

    public virtual OrderNumber? OrderNumber { get; set; }
}
