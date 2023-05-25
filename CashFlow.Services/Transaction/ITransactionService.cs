using CashFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services.Transaction;

public interface ITransactionService
{
    Task<List<Domain.Transaction>> GetAllAsync();
    Task<Domain.Transaction> GetByIdAsync(int id);
    Task CreateAsync(Domain.Transaction lancamento);
    Task UpdateAsync(Domain.Transaction lancamento);
    Task DeleteAsync(int id);
}