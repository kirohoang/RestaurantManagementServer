using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models.Entities;

public partial class Branch
{
    public int BranchId { get; set; }

    public string BranchName { get; set; } = null!;

    public string BranchAddress { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
