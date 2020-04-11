using AutoMapper;

namespace articleApp.Api.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile() : this("MapperProfileMappings")
        {
        }
        public MapperProfile(string profileName) : base(profileName)
        {
        }
    }
}