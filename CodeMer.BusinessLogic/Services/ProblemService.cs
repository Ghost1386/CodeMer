using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.ProblemDto;
using CodeMer.Common.Enums;
using CodeMer.Models;
using CodeMer.Models.Models;
using Microsoft.EntityFrameworkCore;

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

    public List<GetAllProblemDto> GetAll()
    {
        var problems = _applicationContext.Problems.ToList();

        var getAllProblemDto = problems.Select(problem => new GetAllProblemDto
        {
            Id = problem.Id,
            Title = problem.Title,
            Complexity = (ProblemComplexity)problem.Complexity,
            PartOfCollection = problem.PartOfCollection,
            TimeComplete = problem.TimeComplete,
            TimesComplete = problem.TimesComplete,
            Tags = problem.Tags.Select(tag => (Tags)tag).ToList()
        }).ToList();

        return getAllProblemDto;
    }

    public GetProblemDto Get(int id)
    {
        var problemWithDetails = _applicationContext.Problems.Include(problem => 
            problem.ProblemDetail).FirstOrDefault(problem => problem.Id == id);

        if (problemWithDetails != null)
        {
            var getProblemDto = new GetProblemDto
            {
                Title = problemWithDetails.Title,
                Complexity = (ProblemComplexity)problemWithDetails.Complexity,
                PartOfCollection = problemWithDetails.PartOfCollection,
                TimeComplete = problemWithDetails.TimeComplete,
                TimesComplete = problemWithDetails.TimesComplete,
                Tags = problemWithDetails.Tags.Select(tag => (Tags)tag).ToList()
            };

            return getProblemDto;
        }

        return new GetProblemDto();
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