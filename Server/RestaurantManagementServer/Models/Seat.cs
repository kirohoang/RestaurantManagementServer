using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models;

public partial class Seat
{
    public int BranchId { get; set; }

    public int SeatId { get; set; }

    public string? Status { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
