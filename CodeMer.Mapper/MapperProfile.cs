using AutoMapper;
using CodeMer.Common.DTO.AuthDto;
using CodeMer.Common.DTO.DecisionDto;
using CodeMer.Common.DTO.ProblemFinishDto;
using CodeMer.Models.Models;

namespace CodeMer.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<RegistrationUserDto, User>();
        CreateMap<CreateDecisionDto, Decision>();
        CreateMap<CreateProblemFinishDto, ProblemFinish>();
    }
}