using System.ComponentModel.DataAnnotations;

namespace CodeMer.Models.Models;

public class Problem
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public int Complexity { get; set; }
    
    public int PartOfCollection { get; set; }
    
    public double TimeComplete { get; set; }
    
    public int Rating { get; set; }
    
    public int TimesComplete { get; set; }

    public int Tags { get; set; }
    
    public ProblemDetails ProblemDetail { get; set; }
    
    public List<ProblemFinish> ProblemFinishes { get; set; }
}