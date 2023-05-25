using CashFlow.Domain;
using CashFlow.Dto;
using CashFlow.Infra.Repositories;
using CashFlow.Services.Report;
using Moq;

namespace CashFlow.Specs.UnitTests;

public class ReportServiceTests
{
    private Mock<ITransactionRepository> _repositoryMock;
    private ReportService _service;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<ITransactionRepository>();
        _service = new ReportService(_repositoryMock.Object);
    }

    [Test]
    public async Task GetDailyBalanceAsync_ReturnsCorrectBalance_WhenThereAreTransactions()
    {
        var date = new DateTime(2023, 5, 24);
        var transactions = new List<Transaction>
            {
                new Transaction { Type = TransactionType.Credit, Value = 100 },
                new Transaction { Type = TransactionType.Debit, Value = 50 },
                new Transaction { Type = TransactionType.Credit, Value = 3.50m },
                new Transaction { Type = TransactionType.Debit, Value = 1.25m },
            };

        _repositoryMock.Setup(r => r.GetTransactionsByDate(date)).ReturnsAsync(transactions);

 
        var result = await _service.GetDailyBalanceAsync(date);

        Assert.That(result, Is.InstanceOf<DailyBalanceDto>());
        Assert.That(result.Balance, Is.EqualTo(52.25m));
    }

    [Test]
    public async Task GetDailyBalanceAsync_ReturnsZeroBalance_WhenThereAreNoTransactions()
    {
        var date = new DateTime(2023, 5, 24);
        var transactions = new List<Transaction>();

        _repositoryMock.Setup(r => r.GetTransactionsByDate(date)).ReturnsAsync(transactions);

        var result = await _service.GetDailyBalanceAsync(date);

        Assert.That(result, Is.InstanceOf<DailyBalanceDto>());
        Assert.That(result.Balance, Is.EqualTo(0));
    }
}
