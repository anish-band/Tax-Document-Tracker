using Microsoft.AspNetCore.Mvc;
using TaxDocumentTracker.API.Entities;
using TaxDocumentTracker.API.Interfaces;

namespace TaxDocumentTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaxFormController : ControllerBase
{

  private readonly ITaxFormFacade _facade;
  public TaxFormController(ITaxFormFacade facade)
  {
    _facade = facade;
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
  {
    var taxForms = await _facade.GetAllAsync(cancellationToken);

    return Ok(taxForms);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
  {
    var taxForm = await _facade.GetByIdAsync(id, cancellationToken);
    if (taxForm is null) return NotFound();

    return Ok(taxForm);
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  public async Task<IActionResult> CreateAsync([FromBody] TaxForm taxForm, CancellationToken cancellationToken)
  {
    if (taxForm is null) return BadRequest();

    var createdForm = await _facade.CreateAsync(taxForm, cancellationToken);
    return CreatedAtAction(nameof(GetByIdAsync), new { id = createdForm.Id }, createdForm);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> UpdateAsync(int id, [FromBody] TaxForm taxForm, CancellationToken cancellationToken)
  {
    if (taxForm is null) return BadRequest();

    var updatedForm = await _facade.UpdateAsync(taxForm, cancellationToken);
    return Ok(updatedForm);
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
  {
    var form = await _facade.GetByIdAsync(id, cancellationToken);
    if (form is null) return NotFound();

    await _facade.DeleteAsync(id, cancellationToken);
    return NoContent();
  }

}