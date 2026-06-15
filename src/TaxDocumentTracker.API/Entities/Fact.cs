namespace TaxDocumentTracker.API.Entities;

public class Fact
{
  public int Id { get; set; }
  public int FormId { get; set; }
  public string FactCode { get; set; } = string.Empty;
  public string Value { get; set; } = string.Empty;
  public string DataType { get; set; } = string.Empty;
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }

  public TaxForm TaxForm {get; set; } = null!;

}