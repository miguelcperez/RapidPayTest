
namespace RapidPay.Services.Dtos
{
    public class CardBalanceDto
    {
        public required string Number { get; set; }
        public decimal Balance { get; set; }
    }
}
