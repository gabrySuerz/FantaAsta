using AutoMapper;
using FantasyAuction.Server.Entities;
using FantasyAuction.Shared;
using System;
using System.Globalization;

namespace FantasyAuction.Server.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EndpointPlayer, Player>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Ruolo))
                .ForMember(dest => dest.SpecificRole, opt => opt.MapFrom(src => src.RuoloMantra))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => Math.Truncate(decimal.Parse(src.Costo, CultureInfo.InvariantCulture))))
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Squadra));
            CreateMap<EndpointTeam, Team>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome));
        }
    }
}
