using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models;

public partial class Branch
{
    public int BranchId { get; set; }

    public string? BranchName { get; set; }

    public string? BranchAddress { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
