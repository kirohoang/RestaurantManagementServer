namespace RestaurantManagementServer.Models.Dto.Add
{
    public class AddCustomerDetailsDto
    {
        public int? CustomerId { get; set; }

        public decimal CustomerBudget { get; set; }

        public string Status { get; set; } = null!;
    }
}
