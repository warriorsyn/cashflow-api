using CashFlow.Infra.Repositories;

namespace CashFlow.Services.Transaction
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Transaction>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Domain.Transaction> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateAsync(Domain.Transaction lancamento)
        {
            await _repository.CreateAsync(lancamento);
        }

        public async Task UpdateAsync(Domain.Transaction lancamento)
        {
            await _repository.UpdateAsync(lancamento);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
