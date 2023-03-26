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

    private readonly IDecisionService _decisionService;
    private readonly IProblemFinishService _problemFinishService;
    private readonly ResponseCompilerDto _responseCompilerDto;
    private readonly FileSystemWatcher _fileSystemWatcher;
    private readonly Tests _tests;

    public CompilerService(FileSystemWatcher fileSystemWatcher, Tests tests, ResponseCompilerDto responseCompilerDto, 
        IDecisionService decisionService, IProblemFinishService problemFinishService)
    {
        _responseCompilerDto = responseCompilerDto;
        _decisionService = decisionService;
        _problemFinishService = problemFinishService;
        _tests = tests;
        
        _fileSystemWatcher = fileSystemWatcher;
        _fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
        _fileSystemWatcher.Changed += OnChanged;
    }
    
    public ResponseCompilerDto Compiler(RequestCompilerDto requestCompilerDto)
    {
        var responseCompilerDto = new ResponseCompilerDto();
        
        try
        {
            var decisionId = CreateDecision(requestCompilerDto);
            
            var filePath = Path + $"Task{requestCompilerDto.ProblemId}.cs";

            _problemId = requestCompilerDto.ProblemId;

            _fileSystemWatcher.Path = filePath;
            
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                var buffer = Encoding.Default.GetBytes(requestCompilerDto.Code);

                fileStream.WriteAsync(buffer, 0, buffer.Length);
            }

            responseCompilerDto = _responseCompilerDto;

            if (responseCompilerDto.Message == "Success")
            {
                CreateProblemFinish(requestCompilerDto, decisionId);
            }

        }
        catch (Exception ex)
        {
            responseCompilerDto.Message = ex.Message;
            responseCompilerDto.StatusCode = 500;
        }

        return responseCompilerDto;
    }
    
    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        try
        {
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

            _responseCompilerDto.Message = "Success";
            _responseCompilerDto.StatusCode = 200;
        }
        catch (NUnit.Framework.AssertionException ex)
        {
            _responseCompilerDto.Message = ex.Message;
            _responseCompilerDto.StatusCode = 200;
        }
        catch (Exception ex)
        {
            _responseCompilerDto.Message = ex.Message;
            _responseCompilerDto.StatusCode = 500;
        }
    }

    private int CreateDecision(RequestCompilerDto requestCompilerDto)
    {
        var createDecisionDto = new CreateDecisionDto
        {
            Code = requestCompilerDto.Code,
            UserEmail = requestCompilerDto.UserEmail,
            ProblemId = requestCompilerDto.ProblemId
        };
                
        return _decisionService.Create(createDecisionDto);
    }

    private void CreateProblemFinish(RequestCompilerDto requestCompilerDto, int decisionId)
    {
        var createProblemFinishDto = new CreateProblemFinishDto
        {
            DateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture),
            UserEmail = requestCompilerDto.UserEmail,
            ProblemId = requestCompilerDto.ProblemId,
            DecisionsId = decisionId
        };
        
        _problemFinishService.Create(createProblemFinishDto);
    }
}