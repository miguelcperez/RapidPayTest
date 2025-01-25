using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RapidPay.Persistence;
using RapidPay.Persistence.Models;
using RapidPay.Services.Dtos;
using RapidPay.Services.Interfaces;

namespace RapidPay.Services.Implementations
{
    public class CardService : ICardService
    {
        private readonly RapidPayDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UFEService _ufeService;
        public CardService(RapidPayDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _ufeService = UFEService.Instance;
        }
        public async Task Create(CardCreateDto cardDto)
        {
            var existingCard = await _dbContext.Cards.FirstOrDefaultAsync(c => c.Number == cardDto.Number);
            if (existingCard != null)
            {
                throw new InvalidOperationException("Card with this number already exists.");
            }

            var card = _mapper.Map<Card>(cardDto);
            card.Status = true;

            _dbContext.Cards.Add(card);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CardBalanceDto> GetCardBalance(string number)
        {
            var card = await _dbContext.Cards.FirstOrDefaultAsync(c => c.Number == number);
            if (card == null)
            {
                throw new ArgumentNullException("Card not found");
            }

            return _mapper.Map<CardBalanceDto>(card);
        }

        public async Task<CardBalanceDto> Pay(string number, decimal amount)
        {
            var card = await _dbContext.Cards.FirstOrDefaultAsync(c => c.Number == number);
            if (card == null)
            {
                throw new ArgumentNullException("Card not found");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            var amountWithFee = _ufeService.ApplyFee(amount);

            if (card.Balance < amountWithFee)
            {
                throw new InvalidOperationException("Insufficient balance");
            }

            card.Balance = card.Balance - amountWithFee;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CardBalanceDto>(card);
        }
    }
}
