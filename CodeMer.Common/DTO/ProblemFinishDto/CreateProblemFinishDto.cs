namespace CodeMer.Common.DTO.ProblemFinishDto;

public class CreateProblemFinishDto
{
    public string DateTime { get; set; }
    
    public string UserEmail { get; set; }

    public int ProblemId { get; set; }
}