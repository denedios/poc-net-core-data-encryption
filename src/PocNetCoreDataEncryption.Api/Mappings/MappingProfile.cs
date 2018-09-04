using AutoMapper;
using PocNetCoreDataEncryption.Domain.DTOs;
using PocNetCoreDataEncryption.Domain.Entities;

namespace PocNetCoreDataEncryption.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Patient, PatientDto>().ReverseMap();
        }
    }
}
