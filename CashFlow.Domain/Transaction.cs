namespace CashFlow.Domain;

public class Transaction
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public TransactionType Tipo { get; set; }
}

public enum TransactionType
{
    Credit,
    Debit
}