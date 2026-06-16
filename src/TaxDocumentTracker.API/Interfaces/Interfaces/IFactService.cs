using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.API.Interfaces;

public interface IFactService
{
  Task<IEnumerable<Fact>> GetAllAsync(CancellationToken cancellationToken = default);
  Task<Fact?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
  Task<Fact> CreateAsync(Fact fact, CancellationToken cancellationToken = default);
  Task<Fact> UpdateAsync(Fact fact, CancellationToken cancellationToken = default);
  Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}