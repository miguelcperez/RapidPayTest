
namespace RapidPay.Services.Dtos
{
    public class CardCreateDto
    {
        public required string Number { get; set; }
        public decimal Balance { get; set; }
    }
}
