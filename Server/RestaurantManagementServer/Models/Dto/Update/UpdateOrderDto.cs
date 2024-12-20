namespace RestaurantManagementServer.Models.Dto.Update
{
    public class UpdateOrderDto
    {
        public string Status { get; set; } = null!;

        public string Isship { get; set; } = null!;

        public string Ispayment { get; set; } = null!;

        public string PaymentMethod { get; set; } = null!;
    }
}
