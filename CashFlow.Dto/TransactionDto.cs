using CashFlow.Domain;

namespace CashFlow.Dto;

public class TransactionDto
{

    #region privates

    private static string GetTypeDesciptionByTypeEnum(TransactionType type)
    {
        return type == TransactionType.Credit ? "Credit" : "Debit";
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
    public TransactionType Type { get; set; }
    public string? TypeDescription { get; set; }
}


