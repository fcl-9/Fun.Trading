using AutoMapper;
using Fun.Trading.StaticData.Api.Model;
using Fun.Trading.StaticData.Infrastructure.Database.DatabaseModel;

namespace Fun.Trading.StaticData.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TickerRequest, Ticker>(); 
            CreateMap<Ticker, TickerResponse>();
        }
    }
}
