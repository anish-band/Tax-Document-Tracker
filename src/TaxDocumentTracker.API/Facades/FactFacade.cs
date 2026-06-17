using TaxDocumentTracker.API.Interfaces;
using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.API.Facades;

public class FactFacade : IFactFacade
{

  private readonly IFactService _service;
  public FactFacade(IFactService service)
  {
    _service = service;
  }

  public async Task<IEnumerable<Fact>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    return await _service.GetAllAsync(cancellationToken);
  }
  
  public async Task<Fact?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
  {
    return await _service.GetByIdAsync(id, cancellationToken);
  }

  public async Task<Fact> CreateAsync(Fact fact, CancellationToken cancellationToken = default)
  {
    return await _service.CreateAsync(fact, cancellationToken);
  }

  public async Task<Fact> UpdateAsync(Fact fact, CancellationToken cancellationToken = default)
  {
    return await _service.UpdateAsync(fact, cancellationToken);
  }

  public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
  {
    await _service.DeleteAsync(id, cancellationToken);
  }

}