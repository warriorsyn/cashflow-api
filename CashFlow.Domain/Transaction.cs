﻿using CashFlow.Domain.Enums;

namespace CashFlow.Domain;

public class Transaction
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public TransactionTypeEnum Type { get; set; }
}

