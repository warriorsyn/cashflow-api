using CashFlow.Dto;

namespace CashFlow.Services.Report;

public interface IReportService
{
    Task<DailyBalanceDto> GetDailyBalanceAsync(DateTime date);
}

