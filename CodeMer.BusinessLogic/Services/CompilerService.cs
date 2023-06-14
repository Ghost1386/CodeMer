using System.Globalization;
using System.Text;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.BusinessLogicTests;
using CodeMer.Common.DTO.CompilerDto;
using CodeMer.Common.DTO.DecisionDto;
using CodeMer.Common.DTO.ProblemFinishDto;
using Exception = System.Exception;

namespace CodeMer.BusinessLogic.Services;

public class CompilerService : ICompilerService
{
    private const string Path = "C:/Users/egor5/OneDrive/Рабочий стол/CodeMer/CodeMer.ProblemMainFiles/";
    private int _problemId;
    
    private readonly IProblemFinishService _problemFinishService;
    private readonly Tests _tests;

    public CompilerService(Tests tests, IProblemFinishService problemFinishService)
    {
        _problemFinishService = problemFinishService;
        _tests = tests;
    }
    
    public ResponseCompilerDto Compiler(RequestCompilerDto requestCompilerDto)
    {
        var responseCompilerDto = new ResponseCompilerDto();
        
        try
        {
            var filePath = Path + $"Task{requestCompilerDto.ProblemId}.cs";

            _problemId = requestCompilerDto.ProblemId;

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                var buffer = Encoding.Default.GetBytes(requestCompilerDto.Code);

                fileStream.WriteAsync(buffer, 0, buffer.Length);
            }

            if (responseCompilerDto.Message == "Success")
            {
                CreateProblemFinish(requestCompilerDto);
            }
            
            switch (_problemId)
            {
                case 1:
                    _tests.TestForTask_1(5, 2, 7);
                    _tests.TestForTask_1(2, 24, 26);
                    _tests.TestForTask_1(0, 2321, 2321);
                    break;
                default:
                    break;
            }

            responseCompilerDto.Message = "Success";
            responseCompilerDto.StatusCode = 200;
        }
        catch (Exception ex)
        {
            responseCompilerDto.Message = ex.Message;
            responseCompilerDto.StatusCode = 500;
        }

        return responseCompilerDto;
    }

    private void CreateProblemFinish(RequestCompilerDto requestCompilerDto)
    {
        var createProblemFinishDto = new CreateProblemFinishDto
        {
            DateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture),
            UserEmail = requestCompilerDto.UserEmail,
            ProblemId = requestCompilerDto.ProblemId,
        };
        
        _problemFinishService.Create(createProblemFinishDto);
    }
}