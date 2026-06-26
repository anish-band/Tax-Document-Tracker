using TaxDocumentTracker.API.Entities;
using TaxDocumentTracker.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaxDocumentTracker.API.Data;

namespace TaxDocumentTracker.API.Repositories;

public class FactRepository : IFactRepository
{
  private readonly AppDbContext _context;

  public FactRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Fact>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _context.Facts.ToListAsync(cancellationToken);
  }

  public async Task<Fact?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
  {
    return await _context.Facts.FindAsync(id, cancellationToken);
  }

  public async Task<Fact> CreateAsync(Fact fact, CancellationToken cancellationToken = default)
  {
    _context.Add(fact);
    await _context.SaveChangesAsync(cancellationToken);
    return fact;
  }

  public async Task<Fact> UpdateAsync(Fact fact, CancellationToken cancellationToken = default)
  {
    _context.Update(fact);
    await _context.SaveChangesAsync(cancellationToken);
    return fact;
  }

  public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
  {
    var fact = await _context.Facts.FindAsync(id, cancellationToken);
    if (fact is null) return;
    _context.Remove(fact);
    await _context.SaveChangesAsync(cancellationToken);
    
  }
}