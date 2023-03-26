using CodeMer.Common.Enums;

namespace CodeMer.Common.DTO.ProblemDto;

public class EvaluationProblemDto
{
    public int Id { get; set; }
    
    public EvaluationType Evaluation { get; set; }
    
    public int Digit { get; set; }
}