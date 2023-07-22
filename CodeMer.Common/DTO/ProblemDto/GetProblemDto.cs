using CodeMer.Common.DTO.CompilerDto;
using CodeMer.Common.Enums;

namespace CodeMer.Common.DTO.ProblemDto;

public class GetProblemDto : RequestCompilerDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public ProblemComplexity ProblemComplexity { get; set; }
    
    public int Likes { get; set; }
    
    public int DisLikes { get; set; }
    
    public string Text { get; set; }
    
    public string InputEx1 { get; set; }
    
    public string OutputEx1 { get; set; }
    
    public string InputEx2 { get; set; }
    
    public string OutputEx2 { get; set; }
    
    public string InputEx3 { get; set; }
    
    public string OutputEx3 { get; set; }
    
    public string DefaultCode { get; set; }
}