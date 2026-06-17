using TaxDocumentTracker.API.Interfaces;
using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.API.Facades;

public class TaxFormFacade : ITaxFormFacade
{

  private readonly ITaxFormService _service;
  public TaxFormFacade(ITaxFormService service)
  {
    _service = service;
  }

  public async Task<IEnumerable<TaxForm>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _service.GetAllAsync(cancellationToken);
  }
  
  public async Task<TaxForm?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
  {
    return await _service.GetByIdAsync(id, cancellationToken);
  }

  public async Task<TaxForm> CreateAsync(TaxForm taxForm, CancellationToken cancellationToken = default)
  {
    return await _service.CreateAsync(taxForm, cancellationToken);
  }

  public async Task<TaxForm> UpdateAsync(TaxForm taxForm, CancellationToken cancellationToken = default)
  {
    return await _service.UpdateAsync(taxForm, cancellationToken);
  }

  public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
  {
    await _service.DeleteAsync(id, cancellationToken);
  }

}