namespace RestaurantManagementServer.Models.Dto.Update
{
    public class UpdateCustomerDto
    {
        public string CustomerName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;
    }
}
