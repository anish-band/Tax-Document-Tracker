using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.API.Interfaces;

public interface ITaxFormFacade
{
  Task<IEnumerable<TaxForm>> GetAllAsync(CancellationToken cancellationToken = default);
  Task<TaxForm?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
  Task<TaxForm> CreateAsync(TaxForm taxForm, CancellationToken cancellationToken = default);
  Task<TaxForm> UpdateAsync(TaxForm taxForm, CancellationToken cancellationToken = default);
  Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}