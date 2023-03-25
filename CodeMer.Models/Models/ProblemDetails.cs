namespace CodeMer.Models.Models;

public class ProblemDetails
{
    public int Id { get; set; }
    
    public int Likes { get; set; }
    
    public int DisLikes { get; set; }
    
    public string Text { get; set; }
    
    public string Example1 { get; set; }
    
    public string Example2 { get; set; }
    
    public int ProblemId { get; set; }
    
    public Problem Problem { get; set; }
    
    public List<ProblemFinish> ProblemFinishes { get; set; }
}