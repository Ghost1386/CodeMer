using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeMer.Models.Models;

public class Problem
{
    [Key]
    public int ProblemId { get; set; }
    
    public string Title { get; set; }
    
    public int Complexity { get; set; }
    
    public int PartOfCollection { get; set; }
    
    public double TimeComplete { get; set; }
    
    public int Rating { get; set; }
    
    public int TimesComplete { get; set; }

    public int Tags { get; set; }
    
    [ForeignKey("ProblemDetailsId")]
    public int ProblemDetailsId { get; set; }
    
    public ProblemDetails ProblemDetails { get; set; }

    public List<ProblemFinish> ProblemFinishes { get; set; }
}