using CodeMer.Common.DTO.DecisionDto;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IDecisionService
{
    int Create(CreateDecisionDto createDecisionDto);
}