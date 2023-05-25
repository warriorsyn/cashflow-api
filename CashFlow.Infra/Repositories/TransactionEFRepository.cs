using CashFlow.Domain;
using CashFlow.Domain.Enums;
using CashFlow.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infra.Repositories;

public class TransactionEFRepository: ITransactionRepository
{
    private readonly DataContext _context;

    public TransactionEFRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> GetAllAsync() =>
        await _context.Transactions.ToListAsync();

    public async Task<List<Transaction>> GetTransactionsByDate(DateTime date)
    {
       return await _context.Transactions.Where(w => w.Date.Date == date.Date).ToListAsync();
    }

    public async Task<decimal> GetTotalBalanceByDate(DateTime date)
    {
        return await _context.Transactions
            .Where(t => t.Date.Date == date.Date)
            .SumAsync(t => t.Type == TransactionTypeEnum.Debit ? -t.Value : t.Value);
    }


    public async Task<Transaction> GetByIdAsync(int id) =>
        await _context.Transactions.FirstOrDefaultAsync(l => l.Id == id);

    public async Task CreateAsync(Transaction lancamento)
    {
        _context.Transactions.Add(lancamento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction lancamento)
    {
        _context.Transactions.Update(lancamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var transaction = await _context.Transactions.FirstOrDefaultAsync(l => l.Id == id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
