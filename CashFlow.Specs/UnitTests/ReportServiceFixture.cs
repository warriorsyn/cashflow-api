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
    public async Task GetDailyBalanceAsync_ReturnsCorrectBalance()
    {
        var date = new DateTime(2023, 6, 20);
        var expectedBalance = 100m;

        _repositoryMock
            .Setup(repo => repo.GetTotalBalanceByDate(It.IsAny<DateTime>()))
            .ReturnsAsync(expectedBalance);


        var dailyBalance = await _service.GetDailyBalanceAsync(date);

        Assert.That(dailyBalance.Balance, Is.EqualTo(expectedBalance));
    }
}
