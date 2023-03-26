using CodeMer.Common.Enums;

namespace CodeMer.Common.DTO.CompilerDto;

public class RequestCompilerDto
{
    public string UserEmail { get; set; }
    
    public ProgramLanguages ProgramLanguages { get; set; }
    
    public int ProblemId { get; set; }
    
    public string Code { get; set; }
}