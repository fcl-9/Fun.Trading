using AutoMapper;
using Fun.Trading.StaticData.Api.Model;
using Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel;

namespace Fun.Trading.StaticData.Api.Mapper
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TickerRequest, Ticker>(); 
            CreateMap<Ticker, TickerResponse>();
        }
    }
}
