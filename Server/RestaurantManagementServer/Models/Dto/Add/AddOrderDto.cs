namespace RestaurantManagementServer.Models.Dto.Add
{
    public class AddOrderDto
    {
        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        public int? SeatId { get; set; }

        public int? BranchId { get; set; }

        public int? Quantity { get; set; }

        public string Status { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public string Isship { get; set; } = null!;

        public string Ispayment { get; set; } = null!;

        public string PaymentMethod { get; set; } = null!;
    }
}
