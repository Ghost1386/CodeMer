using CodeMer.Common.DTO.ProblemFinishDto;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IProblemFinishService
{
    void Create(CreateProblemFinishDto createProblemFinishDto);
}