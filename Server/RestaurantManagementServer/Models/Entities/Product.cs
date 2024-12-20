using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Quantity { get; set; }

    public string Description { get; set; } = null!;

    public string? Image { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
