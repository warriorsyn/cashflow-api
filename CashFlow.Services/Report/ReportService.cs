using CashFlow.Dto;
using CashFlow.Infra.Repositories;

namespace CashFlow.Services.Report;

public class ReportService: IReportService
{

    private readonly ITransactionRepository _repository;

    public ReportService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<DailyBalanceDto> GetDailyBalanceAsync(DateTime date)
    {
        decimal totalBalance = await _repository.GetTotalBalanceByDate(date);

        return new DailyBalanceDto(totalBalance);
    }
}
