using AutoMapper;
using CodeMer.Common.DTO.AuthDto;
using CodeMer.Models.Models;

namespace CodeMer.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<RegistrationUserDto, User>();
    }
}