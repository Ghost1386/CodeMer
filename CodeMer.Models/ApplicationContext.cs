using CodeMer.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeMer.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Decision> Decisions { get; set; }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<ProblemDetails> ProblemDetails { get; set; }
    public DbSet<ProblemFinish> ProblemFinishes { get; set; }
    public DbSet<User> Users { get; set; }
}