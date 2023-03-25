using CodeMer.Common.DTO.ProblemDto;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IProblemService
{
    void Create(CreateProblemDto createProblemDto);

    void GetAll();

    void Get();

    void Update();
    
    void Delete();
}