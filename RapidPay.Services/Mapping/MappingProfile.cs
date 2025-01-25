using AutoMapper;
using RapidPay.Persistence.Models;
using RapidPay.Services.Dtos;

namespace RapidPay.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CardCreateDto, Card>();
            CreateMap<Card, CardBalanceDto>();
        }
    }
}
