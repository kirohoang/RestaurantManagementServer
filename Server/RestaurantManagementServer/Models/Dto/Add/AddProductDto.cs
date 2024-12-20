namespace RestaurantManagementServer.Models.Dto.Add
{
    public class AddProductDto
    {
        public string? ProductName { get; set; }

        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Type { get; set; }
    }
}
