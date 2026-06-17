using TaxDocumentTracker.API.Interfaces;
using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.API.Services;

public class TaxFormService : ITaxFormService
{

  private readonly ITaxFormRepository _repository;
  public TaxFormService(ITaxFormRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<TaxForm>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _repository.GetAllAsync(cancellationToken);
  }
  
  public async Task<TaxForm?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
  {
    return await _repository.GetByIdAsync(id, cancellationToken);
  }

  public async Task<TaxForm> CreateAsync(TaxForm taxForm, CancellationToken cancellationToken = default)
  {
    return await _repository.CreateAsync(taxForm, cancellationToken);
  }

  public async Task<TaxForm> UpdateAsync(TaxForm taxForm, CancellationToken cancellationToken = default)
  {
    return await _repository.UpdateAsync(taxForm, cancellationToken);
  }

  public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
  {
    await _repository.DeleteAsync(id, cancellationToken);
  }

  
}