using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Persistence.Models;
using RapidPay.Services.Dtos;
using RapidPay.Services.Interfaces;

namespace RapidPay.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CardCreateDto card)
        {
            if (card == null) return BadRequest(new { error = "Invalid Card" });

            try
            {
                await _cardService.Create(card);
                return CreatedAtAction(nameof(GetCardBalance), new { id = card.Number }, card);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error has occured during card creation: {ex.Message}");
            }
        }

        [HttpPost("balance/{number}")]
        public async Task<IActionResult> GetCardBalance(string number)
        {
            return Ok(await _cardService.GetCardBalance(number));
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay(CardPaymentDto payment)
        {
            return Ok(await _cardService.Pay(payment.Number, payment.Amount));
        }

    }
}
