using System;
using System.Collections.Generic;

namespace FurnitureStore.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public int? OrderNumberId { get; set; }

    public int? Quantity { get; set; }

    public string? FurnitureName { get; set; }

    public decimal? Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? FurnitureId { get; set; }

    public int? CustomerId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual CustomerMaster? Customer { get; set; }

    public virtual FurnitureMaster? Furniture { get; set; }

    public virtual OrderNumber? OrderNumber { get; set; }
}


public partial class OrderResponse
{
    public int OrderId { get; set; }

    public int? Quantity { get; set; }

    public string? FurnitureName { get; set; }

    public decimal? Price { get; set; }

    public int? CustomerId { get; set; }

}

public partial class Order1
{

    public string? FurnitureName { get; set; }

 

    public decimal? Price { get; set; }

 

    public int? FurnitureId { get; set; }

 

    public int? CustomerId { get; set; }

 

}

 

public partial class UpdateOrder
{

    public int OrderId { get; set; }

 

    public int? Quantity { get; set; }
}