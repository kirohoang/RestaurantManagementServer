namespace RestaurantManagementServer.Models.Dto.Add
{
    public class AddOrderDetailsDto
    {
        public int? OrderId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
