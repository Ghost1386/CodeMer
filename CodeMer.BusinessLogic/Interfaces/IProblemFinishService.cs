using CodeMer.Common.DTO.ProblemFinishDto;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IProblemFinishService
{
    void Create(CreateProblemFinishDto createProblemFinishDto);

    List<ProblemFinish> GetAllByUserId(int userId);
}