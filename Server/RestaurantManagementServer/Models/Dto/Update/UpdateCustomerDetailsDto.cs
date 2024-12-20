namespace RestaurantManagementServer.Models.Dto.Update
{
    public class UpdateCustomerDetailsDto
    {
        public int? CustomerId { get; set; }

        public decimal CustomerBudget { get; set; }

        public string Status { get; set; } = null!;
    }
}
