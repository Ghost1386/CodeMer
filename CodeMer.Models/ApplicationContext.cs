using CodeMer.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeMer.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; }
}