using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeMer.Models.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Town { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public int Role { get; set; }
    
    [ForeignKey("ProblemFinishesId")]
    public List<ProblemFinish> ProblemFinishes { get; set; }
}