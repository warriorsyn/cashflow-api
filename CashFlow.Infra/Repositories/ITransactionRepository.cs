using CashFlow.Domain;

namespace CashFlow.Infra.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();
        Task<List<Transaction>> GetTransactionsByDate(DateTime date);
        Task<decimal> GetTotalBalanceByDate(DateTime date);
        Task<Transaction> GetByIdAsync(int id);
        Task CreateAsync(Transaction lancamento);
        Task UpdateAsync(Transaction lancamento);
        Task DeleteAsync(int id);
    }
}
