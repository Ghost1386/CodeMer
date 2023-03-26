namespace CodeMer.Common.DTO.DecisionDto;

public class CreateDecisionDto
{
    public string Code { get; set; }
    
    public string UserEmail { get; set; }

    public int ProblemId { get; set; }
}