namespace CashFlow.Services.Transaction;

public interface ITransactionService
{
    Task<List<Dto.TransactionDto>> GetAllAsync();
    Task<Dto.TransactionDto> GetByIdAsync(int id);
    Task CreateAsync(Dto.TransactionRequestDto transactionDto);
    Task UpdateAsync(Dto.TransactionRequestDto transactionDto, int id);
    Task DeleteAsync(int id);
}
