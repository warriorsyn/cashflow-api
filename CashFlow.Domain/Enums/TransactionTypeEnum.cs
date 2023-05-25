using System.ComponentModel;
 
namespace CashFlow.Domain.Enums;

public enum TransactionTypeEnum
{
    [Description("Credit operation")]
    Credit,
    [Description("Debit operation")]
    Debit
}
