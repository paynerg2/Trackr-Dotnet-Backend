using AutoMapper;
using Trackr.Data;
using Trackr.Models;

namespace Trackr.Configurations
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
