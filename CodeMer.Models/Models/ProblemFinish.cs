using CodeMer.Common.Enums;

namespace CodeMer.Models.Models;

public class ProblemFinish
{
    public int Id { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public ProblemComplete Complete { get; set; }

    public List<User> Users { get; set; }
    
    public List<Problem> Problems { get; set; }
}