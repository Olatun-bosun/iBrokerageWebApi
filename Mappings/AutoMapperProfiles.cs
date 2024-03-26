using AutoMapper;
using iBrokerageWebApi.Model.Domain;
using iBrokerageWebApi.Model.DTO;

namespace iBrokerageWebApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Policy, PolicyDto>().ReverseMap();
            CreateMap<AddPolicyRequestDto, Policy>().ReverseMap();
        }

    }
}
