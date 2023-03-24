using System.ComponentModel.DataAnnotations;
using CodeMer.Common.Enums;

namespace CodeMer.Models.Models;

public class Problem
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public ProblemComplexity Complexity { get; set; }
    
    public int PartOfCollection { get; set; }
    
    public double TimeComplete { get; set; }
    
    public int Rating { get; set; }
    
    public int TimesComplete { get; set; }
    
    public List<ProgramLanguages> ProgramLanguages { get; set; }
    
    public List<Tags> Tags { get; set; }
    
    public ProblemDetails Details { get; set; }
}