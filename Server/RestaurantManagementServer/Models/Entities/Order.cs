using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public int? SeatId { get; set; }

    public int? BranchId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Ispayment { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product? Product { get; set; }

    public virtual Seat? Seat { get; set; }
}
