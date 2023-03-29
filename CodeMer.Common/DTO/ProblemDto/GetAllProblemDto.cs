using CodeMer.Common.Enums;

namespace CodeMer.Common.DTO.ProblemDto;

public class GetAllProblemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public ProblemComplexity Complexity { get; set; }
    
    public int PartOfCollection { get; set; }
    
    public double TimeComplete { get; set; }
    
    public int Rating { get; set; }

    public int TimesComplete { get; set; }

    public Tags Tags { get; set; }
}