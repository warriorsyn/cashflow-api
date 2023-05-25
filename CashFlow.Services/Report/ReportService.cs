using CashFlow.Infra.Repositories;

namespace CashFlow.Services.Report
{
    public class ReportService: IReportService
    {

        private readonly ITransactionRepository _repository;

        public ReportService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> GetDailyBalanceAsync(DateTime date)
        {
            var transactions = await _repository.GetTransactionsByDate(date);
            decimal total = 0m;
            foreach (var transaction in transactions)
            {
                total += transaction.Type == Domain.TransactionType.Debit ? -transaction.Value : transaction.Value;
            }
            return total;
        }
    }
}
