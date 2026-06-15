using Microsoft.EntityFrameworkCore;
using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.API.Data;



public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }

  public DbSet<TaxForm> TaxForms { get; set; }
  public DbSet<Fact> Facts { get; set; }

}