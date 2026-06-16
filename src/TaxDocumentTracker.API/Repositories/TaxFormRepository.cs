using TaxDocumentTracker.API.Entities;
using TaxDocumentTracker.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaxDocumentTracker.API.Data;

namespace TaxDocumentTracker.API.Repositories;

public class TaxFormRepository : ITaxFormRepository
{
  private readonly ApplicationDbContext _context;

  public TaxFormRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<TaxForm>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _context.TaxForms.ToListAsync(cancellationToken);
  }

  public async Task<TaxForm?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
  {
    return await _context.TaxForms.FindAsync(id, cancellationToken);
  }

  public async Task<TaxForm> CreateAsync(TaxForm taxForm, CancellationToken cancellationToken = default)
  {
    _context.Add(taxForm);
    await _context.SaveChangesAsync(cancellationToken);
    return taxForm;
  }

  public async Task<TaxForm> UpdateAsync(TaxForm taxForm, CancellationToken cancellationToken = default)
  {
    _context.Update(taxForm);
    await _context.SaveChangesAsync(cancellationToken);
    return taxForm;
  }

  public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
  {
    var taxForm = await _context.TaxForms.FindAsync(id, cancellationToken);
    _context.Remove(taxForm);
    await _context.SaveChangesAsync(cancellationToken);
    
  }
}