using RapidPay.Persistence.Models;
using RapidPay.Services.Dtos;

namespace RapidPay.Services.Interfaces
{
    public interface ICardService
    {
        Task Create(CardCreateDto card);
        Task<CardBalanceDto> GetCardBalance(string number);
        Task<CardBalanceDto> Pay(string number, decimal amount);
    }
}
