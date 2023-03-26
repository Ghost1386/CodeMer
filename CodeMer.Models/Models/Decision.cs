using System.ComponentModel.DataAnnotations;

namespace CodeMer.Models.Models;

public class Decision
{
    [Key]
    public int Id { get; set; }
    
    public string Code { get; set; }
    
    public string UserEmail { get; set; }
    
    public List<User> User { get; set; }
    
    public int ProblemId { get; set; }

    public List<Problem> Problem { get; set; }
    
    public int ProblemFinishesId { get; set; }
    
    public List<ProblemFinish> ProblemFinishes { get; set; }
}