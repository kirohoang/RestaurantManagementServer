using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models.Entities;

public partial class Seat
{
    public int SeatId { get; set; }

    public int? BranchId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
