using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models.Entities;

public partial class CustomerDetail
{
    public int CustomerDetailId { get; set; }

    public int? CustomerId { get; set; }

    public decimal CustomerBudget { get; set; }

    public string Status { get; set; } = null!;

    public virtual Customer? Customer { get; set; }
}
