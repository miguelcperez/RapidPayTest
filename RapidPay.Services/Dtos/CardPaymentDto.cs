
namespace RapidPay.Services.Dtos
{
    public class CardPaymentDto
    {
        public required string Number { get; set; }
        public decimal Amount { get; set; }
    }
}
