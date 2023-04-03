using CodeMer.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeMer.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Problem>()
            .HasOne(a => a.ProblemDetails)
            .WithOne(a => a.Problem)
            .HasForeignKey<ProblemDetails>(c => c.ProblemId);
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<ProblemDetails> ProblemDetails { get; set; }
    public DbSet<ProblemFinish> ProblemFinishes { get; set; }
    public DbSet<User> Users { get; set; }
}