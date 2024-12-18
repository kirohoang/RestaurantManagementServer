using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
