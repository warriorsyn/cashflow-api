using CashFlow.Dto;
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

        public async Task<DailyBalanceDto> GetDailyBalanceAsync(DateTime date)
        {
            var transactions = await _repository.GetTransactionsByDate(date);
            decimal totalBalance = 0m;
            foreach (var transaction in transactions)
            {
                totalBalance += transaction.Type == Domain.TransactionType.Debit ? -transaction.Value : transaction.Value;
            }

            return new DailyBalanceDto(totalBalance);
        }
    }
}
