using CodeMer.Common.Enums;

namespace CodeMer.Common.DTO.CompilerDto;

public class RequestCompilerDto
{
    public ProgramLanguages ProgramLanguages { get; set; }
    
    public string Code { get; set; }
}