using CodeMer.Common.Enums;

namespace CodeMer.Common.DTO.ProblemDto;

public class UpdateProblemDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public ProblemComplexity Complexity { get; set; }
    
    public int PartOfCollection { get; set; }
    
    public double TimeComplete { get; set; }

    public int TimesComplete { get; set; }

    public Tags Tags { get; set; }
    
    public string Text { get; set; }
    
    public string InputEx1 { get; set; }
    
    public string OutputEx1 { get; set; }
    
    public string InputEx2 { get; set; }
    
    public string OutputEx2 { get; set; }
    
    public string InputEx3 { get; set; }
    
    public string OutputEx3 { get; set; }
    
    public string DefaultCode { get; set; }
}