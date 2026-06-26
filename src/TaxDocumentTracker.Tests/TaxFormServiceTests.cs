using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using TaxDocumentTracker.API.Services;
using TaxDocumentTracker.API.Interfaces;
using TaxDocumentTracker.API.Entities;

namespace TaxDocumentTracker.Tests;

[TestClass]
public class TaxFormServiceTests
{
    private ITaxFormRepository _fakeRepository;
    private TaxFormService _service;

    [TestInitialize]
    public void Setup()
    {
        _fakeRepository = A.Fake<ITaxFormRepository>();
        _service = new TaxFormService(_fakeRepository);
    }

    [TestMethod]
    public async Task GetAllAsync_ReturnsAllForms()
    {
        var fakeForms = new List<TaxForm>
        {
            new TaxForm { Id = 1, Name = "W-2", Year = 2026 },
            new TaxForm { Id = 2, Name = "K-1", Year = 2026 }
        };
        A.CallTo(() => _fakeRepository.GetAllAsync(A<CancellationToken>._))
            .Returns(fakeForms);

        var result = await _service.GetAllAsync(CancellationToken.None);

        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public async Task GetByIdAsync_ReturnsForm()
    {
        var form = new TaxForm { Id = 1, Name = "W-2", Year = 2026 };
        A.CallTo(() => _fakeRepository.GetByIdAsync(1, A<CancellationToken>._))
            .Returns(form);

        var result = await _service.GetByIdAsync(1, CancellationToken.None);

        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("W-2", result.Name);
    }

    [TestMethod]
    public async Task CreateAsync_ReturnsCreatedForm()
    {
        var form = new TaxForm { Id = 1, Name = "W-2", Year = 2026 };
        A.CallTo(() => _fakeRepository.CreateAsync(form, A<CancellationToken>._))
            .Returns(form);

        var result = await _service.CreateAsync(form, CancellationToken.None);

        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("W-2", result.Name);
    }

    [TestMethod]
    public async Task DeleteAsync_DeletesForm()
    {
        await _service.DeleteAsync(1, CancellationToken.None);

        A.CallTo(() => _fakeRepository.DeleteAsync(1, A<CancellationToken>._))
            .MustHaveHappenedOnceExactly();
    }
}