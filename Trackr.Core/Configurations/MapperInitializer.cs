using AutoMapper;
using Trackr.Core.DTOs;
using Trackr.Data;

namespace Trackr.Core.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Application, ApplicationDTO>().ReverseMap();
            CreateMap<Interview, InterviewDTO>().ReverseMap();
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Settings, SettingsDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
