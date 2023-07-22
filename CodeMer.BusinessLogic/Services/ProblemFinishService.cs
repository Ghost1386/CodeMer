using AutoMapper;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.ProblemFinishDto;
using CodeMer.Models;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Services;

public class ProblemFinishService : IProblemFinishService
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public ProblemFinishService(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public void Create(CreateProblemFinishDto createProblemFinishDto)
    {
        var problemFinish = _mapper.Map<CreateProblemFinishDto, ProblemFinish>(createProblemFinishDto);

        _applicationContext.ProblemFinishes.Add(problemFinish);
        _applicationContext.SaveChanges();
    }

    public List<ProblemFinish> GetAllByUserId(int userId)
    {
        var problemFinishes = _applicationContext.ProblemFinishes.Where(problemFinishes 
            => problemFinishes.UserId == userId).ToList();
        
        return problemFinishes;
    }
}