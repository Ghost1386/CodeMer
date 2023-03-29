using System.ComponentModel.DataAnnotations.Schema;

namespace CodeMer.Models.Models;

public class Admin
{
    public int AdminId { get; set; }
    
    public string Key { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }

    public int Role { get; set; }
}