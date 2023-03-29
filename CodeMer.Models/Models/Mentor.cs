namespace CodeMer.Models.Models;

public class Mentor
{
    public int MentorId { get; set; }
    
    public string Key { get; set; }
    
    public int UserId { get; set; }

    public User User { get; set; }
    
    public int Role { get; set; }
}