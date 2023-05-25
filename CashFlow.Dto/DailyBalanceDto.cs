namespace CashFlow.Dto;

public class DailyBalanceDto
{
    public DailyBalanceDto()
    {

    }

    public DailyBalanceDto(decimal balance)
    {
        Balance = balance;
    }

    public decimal Balance { get; set; }
}
