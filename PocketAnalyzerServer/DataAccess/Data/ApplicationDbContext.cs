using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Dummy> Dummies { get; set; }
    public DbSet<DummyDetails> DummyDetails { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
}
