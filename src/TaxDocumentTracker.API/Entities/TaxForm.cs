namespace TaxDocumentTracker.API.Entities;

public class TaxForm
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int Year { get; set; }
  public string Jurisdiction { get; set; } = string.Empty;
  public bool IsLocked { get; set; }
  public string CreatedBy { get; set; } = string.Empty;
  public string ModifiedBy { get; set; } = string.Empty;
  public DateTime ModifiedDate { get; set; }

  public ICollection<Fact> Facts { get; set; } = new List<Fact>();

}