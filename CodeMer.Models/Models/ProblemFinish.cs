using System.ComponentModel.DataAnnotations.Schema;

namespace CodeMer.Models.Models;

public class ProblemFinish
{
    public int ProblemFinishId { get; set; }
    
    public string DateTime { get; set; }
    
    public string UserEmail { get; set; }

    [ForeignKey("UserId")]
    public List<User> Users { get; set; }

    [ForeignKey("ProblemId")]
    public List<Problem> Problems { get; set; }
    
    [ForeignKey("DecisionId")]
    public List<Decision> Decisions { get; set; }
}