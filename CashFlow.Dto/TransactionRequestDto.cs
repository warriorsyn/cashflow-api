using CashFlow.Domain;
using CashFlow.Domain.Enums;

namespace CashFlow.Dto;

public class TransactionRequestDto
{
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public TransactionTypeEnum Type { get; set; }
}


