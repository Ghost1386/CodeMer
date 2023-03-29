using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeMer.Models.Models;

public class ProblemDetails
{
    [Key]
    public int ProblemDetailsId { get; set; }
    
    public int Likes { get; set; }
    
    public int DisLikes { get; set; }
    
    public string Text { get; set; }
    
    public string Example1 { get; set; }
    
    public string Example2 { get; set; }
    
    [ForeignKey("ProblemId")]
    public int ProblemId { get; set; }
    
    public Problem Problem { get; set; }

    public List<ProblemFinish> ProblemFinishes { get; set; }
}