using AutoMapper;
using RR.Models;
using RR.ViewModels;

namespace RR.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantViewModel>().ForSourceMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
