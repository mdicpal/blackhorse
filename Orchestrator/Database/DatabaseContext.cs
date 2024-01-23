namespace Orchestrator.Database;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlAuthenticationProvider.SetProvider(
            SqlAuthenticationMethod.ActiveDirectoryManagedIdentity,
            new CustomAzureSqlAuthProvider());
        optionsBuilder.UseSqlServer();
    }
        
    public virtual DbSet<InstanceToPoll> InstancesToPoll { get; set; }
}