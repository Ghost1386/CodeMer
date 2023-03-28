using System.ComponentModel.DataAnnotations;
namespace CodeMer.Models.Models;

public class Admin
{
    [Key]
    public int Id { get; set; }
    
    public string Key { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }

    public int Role { get; set; }
}