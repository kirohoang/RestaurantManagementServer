namespace RestaurantManagementServer.Models.Dto.Add
{
    public class AddCustomerDto
    {
        public string CustomerName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;
    }
}
