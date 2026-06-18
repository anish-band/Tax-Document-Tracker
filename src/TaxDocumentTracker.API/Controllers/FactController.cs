using Microsoft.AspNetCore.Mvc;
using TaxDocumentTracker.API.Entities;
using TaxDocumentTracker.API.Interfaces;

namespace TaxDocumentTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FactController : ControllerBase
{

  private readonly IFactFacade _facade;
  public FactController(IFactFacade facade)
  {
    _facade = facade;
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
  {
    var facts = await _facade.GetAllAsync(cancellationToken);

    return Ok(facts);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
  {
    var fact = await _facade.GetByIdAsync(id, cancellationToken);
    if (fact is null) return NotFound();

    return Ok(fact);
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  public async Task<IActionResult> CreateAsync([FromBody] Fact fact, CancellationToken cancellationToken)
  {
    if (fact is null) return BadRequest();

    var createdFact = await _facade.CreateAsync(fact, cancellationToken);
    return CreatedAtAction(nameof(GetByIdAsync), new { id = createdFact.Id }, createdFact);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> UpdateAsync(int id, [FromBody] Fact fact, CancellationToken cancellationToken)
  {
    if (fact is null) return BadRequest();

    var updatedFact = await _facade.UpdateAsync(fact, cancellationToken);
    return Ok(updatedFact);
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
  {
    var fact = await _facade.GetByIdAsync(id, cancellationToken);
    if (fact is null) return NotFound();

    await _facade.DeleteAsync(id, cancellationToken);
    return NoContent();
  }

}