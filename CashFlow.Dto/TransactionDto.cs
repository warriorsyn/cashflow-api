using CashFlow.Domain;
using CashFlow.Domain.Enums;

namespace CashFlow.Dto;

public class TransactionDto
{

    #region privates

    private static string GetTypeDesciptionByTypeEnum(TransactionTypeEnum type)
    {
        return type == TransactionTypeEnum.Credit ? "Credit" : "Debit";
    }
 
    #endregion

    public TransactionDto()
    {

    }
    
    public TransactionDto(Transaction transaction)
    {
        Id = transaction.Id;
        Value = transaction.Value;
        Date = transaction.Date;
        Type = transaction.Type;
        TypeDescription = GetTypeDesciptionByTypeEnum(transaction.Type);

    }

    public int Id { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public TransactionTypeEnum Type { get; set; }
    public string? TypeDescription { get; set; }
}


