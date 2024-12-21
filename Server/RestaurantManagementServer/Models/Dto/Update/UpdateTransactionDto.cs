namespace RestaurantManagementServer.Models.Dto.Update
{
    public class UpdateTransactionDto
    {
        public int? CustomerId { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TransactionType { get; set; } = null!;

        public string? Description { get; set; }
    }
}
