using AutoMapper;
using FantasyAuction.Server.Entities;
using FantasyAuction.Shared;

namespace FantasyAuction.Server.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EndpointPlayer, Player>();
            CreateMap<EndpointTeam, Team>();
        }
    }
}
