using System.Diagnostics;
using System.Text;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.BusinessLogicTests;
using CodeMer.Common.DTO.CompilerDto;
using CodeMer.Common.DTO.ProblemFinishDto;
using Exception = System.Exception;

namespace CodeMer.BusinessLogic.Services;

public class CompilerService : ICompilerService
{
    private const string Path = "C:/Users/egor5/OneDrive/Рабочий стол/CodeMer/CodeMer.ProblemMainFiles/";
    private const int ConstantToConvert = 1000;

    private readonly IProblemFinishService _problemFinishService;
    private readonly IUserService _userService;
    private readonly Tests _tests;

    public CompilerService(Tests tests, IProblemFinishService problemFinishService, IUserService userService)
    {
        _problemFinishService = problemFinishService;
        _userService = userService;
        _tests = tests;
    }
    
    public ResponseCompilerDto Compiler(RequestCompilerDto requestCompilerDto)
    {
        var responseCompilerDto = new ResponseCompilerDto();
        
        try
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var filePath = Path + $"Task{requestCompilerDto.ProblemId}.cs";

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                var buffer = Encoding.Default.GetBytes(requestCompilerDto.Code);

                fileStream.WriteAsync(buffer, 0, buffer.Length);
            }
            
            stopwatch.Stop();
            
            Thread.Sleep(5000);

            CheckingTasksOnTests(requestCompilerDto.ProblemId);

            responseCompilerDto.Message = "Success";
            responseCompilerDto.StatusCode = 200;
        }
        catch (Exception ex)
        {
            responseCompilerDto.Message = ex.Message;
            responseCompilerDto.StatusCode = 500;
        }
        
        if (responseCompilerDto.Message == "Success")
        {
            CreateProblemFinish(requestCompilerDto);
        }

        return responseCompilerDto;
    }

    private void CheckingTasksOnTests(int problemId)
    {
        switch (problemId)
        {
            case 1:
                _tests.TestForTask_1(5, 2, 7);
                _tests.TestForTask_1(2, 24, 26);
                _tests.TestForTask_1(0, 2321, 2321);
                break;
            default:
                break;
        }
    }

    private void CreateProblemFinish(RequestCompilerDto requestCompilerDto)
    {
        var createProblemFinishDto = new CreateProblemFinishDto
        {
            UserId = _userService.Get(requestCompilerDto.UserEmail).UserId,
            ProblemId = requestCompilerDto.ProblemId
        };
        
        _problemFinishService.Create(createProblemFinishDto);
    }
}