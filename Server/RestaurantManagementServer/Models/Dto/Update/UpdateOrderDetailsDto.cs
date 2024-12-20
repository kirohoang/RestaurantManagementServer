namespace RestaurantManagementServer.Models.Dto.Update
{
    public class UpdateOrderDetailsDto
    {
        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
