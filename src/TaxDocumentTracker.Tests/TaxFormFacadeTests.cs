using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using TaxDocumentTracker.API.Facades;
using TaxDocumentTracker.API.Interfaces;
using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.Tests;

[TestClass]
public class TaxFormFacadeTests
{
  private ITaxFormService _fakeService;
  private TaxFormFacade _facade;

  [TestInitialize]
  public void Setup()
  {
    _fakeService = A.Fake<ITaxFormService>();
    _facade = new TaxFormFacade(_fakeService);
  }

  [TestMethod]
  public async Task GetAllAsync_ReturnsAllForms()
  {
    var fakeForms = new List<TaxForm>
    {
      new TaxForm {Id = 1, Name = "W-2", Year = 2026},
      new TaxForm {Id = 2, Name = "K-1", Year = 2026}
    };
    A.CallTo(() => _fakeService.GetAllAsync(A<CancellationToken>._))
      .Returns(fakeForms);

    var result = await _facade.GetAllAsync(CancellationToken.None);

    Assert.AreEqual(2, result.Count());
  }

  [TestMethod]
  public async Task GetByIdAsync_ReturnsIdForForm()
  {
    var form = new TaxForm {Id = 1, Name = "W-2", Year = 2026};
    A.CallTo(() => _fakeService.GetByIdAsync(1, A<CancellationToken>._))
      .Returns(form);

    var result = await _facade.GetByIdAsync(1, CancellationToken.None);

    Assert.AreEqual(1, result.Id);
    Assert.AreEqual("W-2", result.Name);
  }

  [TestMethod]
  public async Task CreateAsync_ReturnsForm()
  {
    var form = new TaxForm {Id = 1, Name = "W-2", Year = 2026};
    A.CallTo(() => _fakeService.CreateAsync(form, A<CancellationToken>._))
      .Returns(form);

    var result = await _facade.CreateAsync(form, CancellationToken.None);

    Assert.AreEqual(1, result.Id);
    Assert.AreEqual("W-2", result.Name);
  }

  [TestMethod]
  public async Task DeleteAsync_DeletesForm()
  {
    await _facade.DeleteAsync(1, CancellationToken.None);
    
    A.CallTo(() => _fakeService.DeleteAsync(1, A<CancellationToken>._))
      .MustHaveHappenedOnceExactly();
  }
}