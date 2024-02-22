using AutoMapper;
using ShopifySharp.Identity.Application.Commands.Users.Create;
using ShopifySharp.Identity.Domain.Entities;

namespace ShopifySharp.Identity.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserCommand>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName)).ReverseMap();

        }
    }
}
