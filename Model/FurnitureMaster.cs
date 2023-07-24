using System;
using System.Collections.Generic;

namespace FurnitureStore.Model;

public partial class FurnitureMaster
{
    public int FurnitureId { get; set; }

    public string? FurnitureName { get; set; }

    public decimal? Price { get; set; }

    public string? Material { get; set; }

    public string? Detail { get; set; }

    public string? Manufacturer { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
