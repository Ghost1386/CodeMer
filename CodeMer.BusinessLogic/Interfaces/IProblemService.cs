using CodeMer.Common.DTO.ProblemDto;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IProblemService
{
    void Create(CreateProblemDto createProblemDto);

    List<GetAllProblemDto> GetAll();

    GetProblemDto Get(int id);

    void Delete(int id);

    void Evaluation(EvaluationProblemDto evaluationProblemDto);
}