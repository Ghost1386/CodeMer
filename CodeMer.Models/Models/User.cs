﻿using System.ComponentModel.DataAnnotations;

namespace CodeMer.Models.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Town { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public int Role { get; set; }
    
    public List<ProblemFinish> ProblemFinishes { get; set; }
    
    public Decision Decision { get; set; }
}