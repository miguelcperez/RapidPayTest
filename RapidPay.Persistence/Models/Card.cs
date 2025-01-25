
using System.ComponentModel.DataAnnotations;

namespace RapidPay.Persistence.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Card Number is required.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Card number length must be 15.")]
        public required string Number { get; set; }

        [Required(ErrorMessage = "Balance is required.")]
        public decimal Balance { get; set; }
        public bool Status { get; set; }
    }
}
