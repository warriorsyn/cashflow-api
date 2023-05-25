using CashFlow.Domain;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Exceptions;
using CashFlow.Dto;
using CashFlow.Infra.Repositories;
using CashFlow.Services.Transaction;
using Moq;

namespace CashFlow.Specs.UnitTests;

public class TransactionServiceFixture
{
    private Mock<ITransactionRepository> _transactionRepositoryMock;
    private TransactionService _transactionService;

    [SetUp]
    public void SetUp()
    {
        _transactionRepositoryMock = new Mock<ITransactionRepository>();
        _transactionService = new TransactionService(_transactionRepositoryMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ReturnsCorrectTransactions()
    {
        List< Transaction> transactions = new()
            {
                new Transaction { Id = 1, Date = DateTime.Now, Type = TransactionTypeEnum.Credit, Value = 100 },
                new Transaction { Id = 2, Date = DateTime.Now, Type = TransactionTypeEnum.Debit, Value = 50 }
            };

        _transactionRepositoryMock
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(transactions);

        var result = await _transactionService.GetAllAsync();

        Assert.That(result, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Id, Is.EqualTo(transactions[0].Id));
            Assert.That(result[1].Id, Is.EqualTo(transactions[1].Id));
        });
    }

    [Test]
    public async Task GetByIdAsync_ReturnsCorrectTransaction()
    {
        // Arrange
        Transaction transaction = new() { Id = 1, Date = DateTime.Now, Type = TransactionTypeEnum.Credit, Value = 100 };

        _transactionRepositoryMock
            .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(transaction);

        var result = await _transactionService.GetByIdAsync(transaction.Id);

        Assert.That(result.Id, Is.EqualTo(transaction.Id));
    }

    [Test]
    public void GetByIdAsync_ThrowsExceptionWhenTransactionNotFound()
    {
        _transactionRepositoryMock
            .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Transaction)null);

        Assert.ThrowsAsync<TransactionNotFoundException>(() => _transactionService.GetByIdAsync(1));
    }

    [Test]
    public async Task CreateAsync_CreatesNewTransaction()
    {
        var transactionDto = new TransactionRequestDto { Date = DateTime.Now, Type = TransactionTypeEnum.Credit, Value = 100 };

        _transactionRepositoryMock
            .Setup(repo => repo.CreateAsync(It.IsAny<Transaction>()))
            .Returns(Task.CompletedTask);

        await _transactionService.CreateAsync(transactionDto);

        _transactionRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Transaction>()), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_UpdatesExistingTransaction()
    {
        var transactionDto = new TransactionRequestDto { Date = DateTime.Now, Type = TransactionTypeEnum.Credit, Value = 100 };

        _transactionRepositoryMock
            .Setup(repo => repo.UpdateAsync(It.IsAny<Domain.Transaction>()))
            .Returns(Task.CompletedTask);


        await _transactionService.UpdateAsync(transactionDto, 1);

        _transactionRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Transaction>()), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_DeletesTransaction()
    {
        _transactionRepositoryMock
            .Setup(repo => repo.DeleteAsync(It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        await _transactionService.DeleteAsync(1);

        _transactionRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
    }
}

