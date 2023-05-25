using CashFlow.Domain;
using CashFlow.Dto;
using CashFlow.Infra.Repositories;
using CashFlow.Services.Transaction;
using Moq;

namespace CashFlow.Specs.UnitTests;

public class TransactionServiceFixture
{
    private Mock<ITransactionRepository> _repositoryMock;
    private TransactionService _service;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<ITransactionRepository>();
        _service = new TransactionService(_repositoryMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ReturnsAllTransactions()
    {
        List<Transaction> transactions = new()
            {
                new Transaction { Id = 1, Date = DateTime.Now, Type = TransactionType.Credit, Value = 100 },
                new Transaction { Id = 2, Date = DateTime.Now, Type = TransactionType.Debit, Value = 50 },
            };

        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(transactions);

        var result = await _service.GetAllAsync();

        Assert.That(result, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task GetByIdAsync_ReturnsCorrectTransaction()
    {
        Transaction transaction = new() { Id = 1, Date = DateTime.Now, Type = TransactionType.Credit, Value = 100 };

        _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(transaction);


        var result = await _service.GetByIdAsync(1);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(transaction.Id));
            Assert.That(result.Date, Is.EqualTo(transaction.Date));
            Assert.That(result.Type, Is.EqualTo(transaction.Type));
            Assert.That(result.Value, Is.EqualTo(transaction.Value));
        });
    }

    [Test]
    public async Task CreateAsync_CreatesNewTransaction()
    {
        TransactionDto transactionDto = new() { Date = DateTime.Now, Type = TransactionType.Credit, Value = 100 };

        await _service.CreateAsync(transactionDto);

        _repositoryMock.Verify(r => r.CreateAsync(It.Is<Transaction>(t => t.Date == transactionDto.Date && t.Type == transactionDto.Type && t.Value == transactionDto.Value)), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_UpdatesExistingTransaction()
    {
        TransactionDto transactionDto = new() { Id = 1, Date = DateTime.Now, Type = TransactionType.Credit, Value = 100 };

        await _service.UpdateAsync(transactionDto);

        _repositoryMock.Verify(r => r.UpdateAsync(It.Is<Transaction>(t => t.Id == transactionDto.Id && t.Date == transactionDto.Date && t.Type == transactionDto.Type && t.Value == transactionDto.Value)), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_DeletesTransaction()
    {
        var id = 1;

        await _service.DeleteAsync(id);

        _repositoryMock.Verify(r => r.DeleteAsync(id), Times.Once);
    }
}
