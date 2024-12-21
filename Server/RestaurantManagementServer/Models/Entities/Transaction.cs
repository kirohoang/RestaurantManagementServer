using System;
using System.Collections.Generic;

namespace RestaurantManagementServer.Models.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? CustomerId { get; set; }

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }

    public string TransactionType { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Customer? Customer { get; set; }
}
