using TaxDocumentTracker.API.Interfaces;
using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.API.Services;

public class FactService : IFactRepository
{

  private readonly IFactRepository _repository;
  public FactService(IFactRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<Fact>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _repository.GetAllAsync(cancellationToken);
  }
  
  public async Task<Fact?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
  {
    return await _repository.GetByIdAsync(id, cancellationToken);
  }

  public async Task<Fact> CreateAsync(Fact fact, CancellationToken cancellationToken = default)
  {
    return await _repository.CreateAsync(fact, cancellationToken);
  }

  public async Task<Fact> UpdateAsync(Fact fact, CancellationToken cancellationToken = default)
  {
    return await _repository.UpdateAsync(fact, cancellationToken);
  }

  public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
  {
    await _repository.DeleteAsync(id, cancellationToken);
  }

  
}