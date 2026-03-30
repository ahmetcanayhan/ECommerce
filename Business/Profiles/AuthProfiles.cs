using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Business.Profiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            // RegisterDto(Kaynak) -> Customer(Hedef)
            CreateMap<RegisterDto, Customer>();
        }
    }
}
