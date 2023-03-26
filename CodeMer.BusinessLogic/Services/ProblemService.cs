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
            Rating = problem.Rating,
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
                Id = problemWithDetails.Id,
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

    public void Update(UpdateProblemDto updateProblemDto)
    {
        var problem = _applicationContext.Problems.FirstOrDefault(problem => 
            problem.Id == updateProblemDto.Id);

        if (problem != null)
        {
            problem.Title = updateProblemDto.Title;
            problem.Complexity = (int)updateProblemDto.Complexity;
            problem.PartOfCollection = updateProblemDto.PartOfCollection;
            problem.TimeComplete = updateProblemDto.TimeComplete;
            problem.TimesComplete = updateProblemDto.TimesComplete;
            problem.Tags = updateProblemDto.Tags.Select(tag => (int)tag).ToList();
            
            _applicationContext.Problems.Update(problem);
            _applicationContext.SaveChanges();
            
            var problemDetails = _applicationContext.ProblemDetails.FirstOrDefault(problemDetails => 
                problemDetails.Id == updateProblemDto.Id);
        
            if (problemDetails != null)
            {
                problemDetails.Text = updateProblemDto.Text;
                problemDetails.Example1 = updateProblemDto.Example1;
                problemDetails.Example2 = updateProblemDto.Example2;

                _applicationContext.ProblemDetails.Update(problemDetails);
                _applicationContext.SaveChanges();
            }
        }
    }

    public void Delete(int id)
    {
        var problem = _applicationContext.Problems.FirstOrDefault(problem => 
            problem.Id == id);

        if (problem != null)
        {
            _applicationContext.Problems.Remove(problem);
            _applicationContext.SaveChanges();
            
            var problemDetails = _applicationContext.ProblemDetails.FirstOrDefault(problemDetails => 
                problemDetails.Id == id);
            
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
            problemDetails.Id == evaluationProblemDto.Id);
        
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
            _applicationContext.SaveChanges();
            
            var problem = _applicationContext.Problems.FirstOrDefault(problem => 
                problem.Id == evaluationProblemDto.Id);
            
            if (problem != null)
            {
                problem.Rating = problemDetails.Likes / problemDetails.DisLikes;
                
                _applicationContext.Problems.Update(problem);
                _applicationContext.SaveChanges();
            }
        }
    }
}