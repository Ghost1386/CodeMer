using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.ProblemDto;
using CodeMer.Models;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Services;

public class ProblemService : IProblemService
{
    private readonly ApplicationContext _applicationContext;

    public ProblemService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Create(CreateProblemDto createProblemDto)
    {
        var problem = new Problem
        {
            Title = createProblemDto.Title,
            Complexity = (int)createProblemDto.Complexity,
            PartOfCollection = createProblemDto.PartOfCollection,
            TimeComplete = createProblemDto.TimeComplete,
            Rating = 0,
            TimesComplete = createProblemDto.TimesComplete,
            ProgramLanguages = createProblemDto.ProgramLanguages.Select(programLanguages => 
                (int)programLanguages).ToList(),
            Tags = createProblemDto.Tags.Select(tag => (int)tag).ToList()
        };

        _applicationContext.Problems.Add(problem);

        var problemDetails = new ProblemDetails
        {
            Likes = 0,
            DisLikes = 0,
            Text = createProblemDto.Text,
            Example1 = createProblemDto.Example1,
            Example2 = createProblemDto.Example2
        };

        _applicationContext.ProblemDetails.Add(problemDetails);

        _applicationContext.SaveChanges();
    }

    public void GetAll()
    {
        throw new NotImplementedException();
    }

    public void Get()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }
}