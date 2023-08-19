using Microsoft.EntityFrameworkCore;
using OnionTemplate.Domain;


namespace OnionTemplate.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<ExampleEntity>? ExampleEntities { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
    {

    }
}
