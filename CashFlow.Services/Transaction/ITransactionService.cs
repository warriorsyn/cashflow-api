namespace CashFlow.Services.Transaction;

public interface ITransactionService
{
    Task<List<Dto.TransactionDto>> GetAllAsync();
    Task<Dto.TransactionDto> GetByIdAsync(int id);
    Task CreateAsync(Dto.TransactionDto transactionDto);
    Task UpdateAsync(Dto.TransactionDto transactionDto);
    Task DeleteAsync(int id);
}
