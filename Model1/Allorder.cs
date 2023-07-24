using System;
using System.Collections.Generic;

namespace FurnitureStore.Model1;

public partial class Allorder
{
    public int Orderid { get; set; }

    public int? Quantity { get; set; }

    public string? FurnitureName { get; set; }

    public decimal? Price { get; set; }

    public int? Customerid { get; set; }
}
