using AutoMapper;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.DecisionDto;
using CodeMer.Models;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Services;

public class DecisionService : IDecisionService
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public DecisionService(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public int Create(CreateDecisionDto createDecisionDto)
    {
        var decision = _mapper.Map<CreateDecisionDto, Decision>(createDecisionDto);
        
        _applicationContext.Decisions.Add(decision);
        _applicationContext.SaveChanges();

        var decisionId = _applicationContext.Decisions.Count();

        return decisionId;
    }
}