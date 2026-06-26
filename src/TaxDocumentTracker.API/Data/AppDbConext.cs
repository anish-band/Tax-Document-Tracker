using Microsoft.EntityFrameworkCore;
using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.API.Data;



public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<TaxForm> TaxForms { get; set; }
  public DbSet<Fact> Facts { get; set; }

}