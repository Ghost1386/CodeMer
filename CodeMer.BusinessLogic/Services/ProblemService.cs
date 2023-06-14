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
    private readonly IProblemFinishService _problemFinishService;

    public ProblemService(ApplicationContext applicationContext, 
        IProblemFinishService problemFinishService)
    {
        _applicationContext = applicationContext;
        _problemFinishService = problemFinishService;
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
            Tags = (int)createProblemDto.Tags
        };

        _applicationContext.Problems.Add(problem);

        var problemDetails = new ProblemDetails
        {
            Likes = 0,
            DisLikes = 0,
            Text = createProblemDto.Text,
            InputEx1 = createProblemDto.InputEx1,
            OutputEx1 = createProblemDto.OutputEx1,
            InputEx2 = createProblemDto.InputEx2,
            OutputEx2 = createProblemDto.OutputEx2,
            InputEx3 = createProblemDto.InputEx3,
            OutputEx3 = createProblemDto.OutputEx3,
            ProblemId = problem.ProblemId
        };

        _applicationContext.ProblemDetails.Add(problemDetails);

        _applicationContext.SaveChanges();
    }

    public List<GetAllProblemDto> GetAll(int userId)
    {
        var problems = _applicationContext.Problems.Include(problem =>
            problem.ProblemFinishes).ToList();

        var problemFinish = _problemFinishService.GetAllByUserId(userId).AsQueryable();

        var getAllProblemDto = problems.Select(problem => new GetAllProblemDto
        {
            Id = problem.ProblemId,
            Title = problem.Title,
            Complexity = (ProblemComplexity)problem.Complexity,
            PartOfCollection = problem.PartOfCollection,
            TimeComplete = problem.TimeComplete,
            Rating = problem.Rating,
            TimesComplete = problem.TimesComplete,
            Tags = (Tags) problem.Tags,
            Сompleteness = GetEnumOfComplete(problemFinish, problem.ProblemId)
        }).ToList();

        return getAllProblemDto;
    }

    private static Сompleteness GetEnumOfComplete(IQueryable<ProblemFinish> problemFinish, int problemId)
    {
        if (problemFinish.Any(p => p.ProblemFinishId == problemId))
        {
            return Сompleteness.Finished;
        }
        
        return Сompleteness.Performed;
    }

    public GetProblemDto Get(int id)
    {
        var problemWithDetails = _applicationContext.Problems.Include(problem => 
            problem.ProblemDetails).FirstOrDefault(problem => problem.ProblemId == id);

        if (problemWithDetails != null)
        {
            var getProblemDto = new GetProblemDto
            {
                Id = problemWithDetails.ProblemId,
                Title = problemWithDetails.Title,
                ProblemComplexity = (ProblemComplexity)problemWithDetails.Complexity,
                Text = problemWithDetails.ProblemDetails.Text,
                InputEx1 = problemWithDetails.ProblemDetails.InputEx1,
                OutputEx1 = problemWithDetails.ProblemDetails.OutputEx1,
                InputEx2 = problemWithDetails.ProblemDetails.InputEx2,
                OutputEx2 = problemWithDetails.ProblemDetails.OutputEx2,
                InputEx3 = problemWithDetails.ProblemDetails.InputEx3,
                OutputEx3 = problemWithDetails.ProblemDetails.OutputEx3
            };

            return getProblemDto;
        }

        return new GetProblemDto();
    }

    public void Update(UpdateProblemDto updateProblemDto)
    {
        var problem = _applicationContext.Problems.FirstOrDefault(problem => 
            problem.ProblemId == updateProblemDto.Id);

        if (problem != null)
        {
            problem.Title = updateProblemDto.Title;
            problem.Complexity = (int)updateProblemDto.Complexity;
            problem.PartOfCollection = updateProblemDto.PartOfCollection;
            problem.TimeComplete = updateProblemDto.TimeComplete;
            problem.TimesComplete = updateProblemDto.TimesComplete;
            problem.Tags = (int)updateProblemDto.Tags;
            
            _applicationContext.Problems.Update(problem);

            var problemDetails = _applicationContext.ProblemDetails.FirstOrDefault(problemDetails => 
                problemDetails.ProblemDetailsId == updateProblemDto.Id);
        
            if (problemDetails != null)
            {
                problemDetails.Text = updateProblemDto.Text;
                problemDetails.InputEx1 = updateProblemDto.InputEx1;
                problemDetails.OutputEx1 = updateProblemDto.OutputEx1;
                problemDetails.InputEx2 = updateProblemDto.InputEx2;
                problemDetails.OutputEx2 = updateProblemDto.OutputEx2;
                problemDetails.InputEx3 = updateProblemDto.InputEx3;
                problemDetails.OutputEx3 = updateProblemDto.OutputEx3;

                _applicationContext.ProblemDetails.Update(problemDetails);
                _applicationContext.SaveChanges();
            }
        }
    }

    public void Delete(int id)
    {
        var problem = _applicationContext.Problems.FirstOrDefault(problem => 
            problem.ProblemId == id);

        if (problem != null)
        {
            _applicationContext.Problems.Remove(problem);

            var problemDetails = _applicationContext.ProblemDetails.FirstOrDefault(problemDetails => 
                problemDetails.ProblemDetailsId == id);
            
            if (problemDetails != null)
            {
                _applicationContext.ProblemDetails.Remove(problemDetails);
                _applicationContext.SaveChanges();
            }
        }
    }

    public void Evaluation(EvaluationProblemDto evaluationProblemDto)
    {
        var problemDetails = _applicationContext.ProblemDetails.FirstOrDefault(problemDetails => 
            problemDetails.ProblemDetailsId == evaluationProblemDto.Id);
        
        if (problemDetails != null)
        {
            if (evaluationProblemDto.Evaluation == EvaluationType.Like)
            {
                problemDetails.Likes += 1;
            }
            else
            {
                problemDetails.DisLikes += 1;
            }
            
            _applicationContext.ProblemDetails.Update(problemDetails);

            var problem = _applicationContext.Problems.FirstOrDefault(problem => 
                problem.ProblemId == evaluationProblemDto.Id);
            
            if (problem != null)
            {
                problem.Rating = problemDetails.Likes / problemDetails.DisLikes;
                
                _applicationContext.Problems.Update(problem);
                _applicationContext.SaveChanges();
            }
        }
    }
}