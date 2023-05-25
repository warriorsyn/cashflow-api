namespace CashFlow.Services.Report;

public interface IReportService
{
    Task<decimal> GetDailyBalanceAsync(DateTime date);
}

