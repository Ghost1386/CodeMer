using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeMer.Models.Models;

public class Decision
{
    public int DecisionId { get; set; }
    
    public string Code { get; set; }
    
    public string UserEmail { get; set; }

    [ForeignKey("ProblemId")]
    public List<Problem> Problem { get; set; }
    
    [ForeignKey("ProblemFinishesId")]
    public List<ProblemFinish> ProblemFinishes { get; set; }
}