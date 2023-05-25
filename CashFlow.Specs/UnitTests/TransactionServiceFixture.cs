using CashFlow.Domain;
using CashFlow.Infra.Repositories;
using CashFlow.Services.Transaction;
using Moq;

namespace CashFlow.Specs.UnitTests;

public class TransactionServiceFixture
{

    private Mock<ITransactionRepository> _repositoryMock;
    private TransactionService _service;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<ITransactionRepository>();
        _service = new TransactionService(_repositoryMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllLancamentos()
    {
        // Arrange
        _repositoryMock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Transaction>
            {
            new Transaction { Id = 1, Value = 10m, Type = TransactionType.Credit, Date = DateTime.Today },
            new Transaction { Id = 2, Value = 5m, Type = TransactionType.Debit, Date = DateTime.Today },
            });

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));
    }
}