using CashFlow.Domain;

namespace CashFlow.Infra.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction> GetByIdAsync(int id);
        Task CreateAsync(Transaction lancamento);
        Task UpdateAsync(Transaction lancamento);
        Task DeleteAsync(int id);
    }
}
