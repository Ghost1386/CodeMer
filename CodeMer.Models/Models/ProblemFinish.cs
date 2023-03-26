using System.ComponentModel.DataAnnotations;

namespace CodeMer.Models.Models;

public class ProblemFinish
{
    [Key]
    public int Id { get; set; }
    
    public string DateTime { get; set; }
    
    public string UserEmail { get; set; }
    
    public List<User> Users { get; set; }
    
    public int ProblemId { get; set; }
    
    public List<Problem> Problems { get; set; }
    
    public int DecisionsId { get; set; }
    
    public List<Decision> Decisions { get; set; }
}