using AutoMapper;
using TranspotationTicketBooking.Models;
using TranspotationTicketBooking.Models.Users;

namespace TranspotationTicketBooking
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>()
               .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<UserRegistrationModel, Passenger>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.Tp, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               ;

            CreateMap<UserRegistrationModel, BusInfo>();

        }
    }
}
