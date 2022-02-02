using DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Dummy> Dummies { get; set; }
    public DbSet<DummyDetails> DummyDetails { get; set; }
    public DbSet<DummyImage> DummyImages { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
}
