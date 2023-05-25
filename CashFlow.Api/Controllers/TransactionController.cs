using CashFlow.Services.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Dto.TransactionDto>>> GetAllAsync() =>
        await _transactionService.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Dto.TransactionDto>> GetByIdAsync(int id)
    {
        var lancamento = await _transactionService.GetByIdAsync(id);
        if (lancamento == null)
        {
            return NotFound();
        }
        return lancamento;
    }

    [HttpPost]
    public async Task<ActionResult<Domain.Transaction>> CreateAsync([FromBody] Dto.TransactionDto transaction)
    {
        await _transactionService.CreateAsync(transaction);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] Dto.TransactionDto transaction)
    {
        if (id != transaction.Id)
        {
            return BadRequest();
        }
        await _transactionService.UpdateAsync(transaction);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _transactionService.DeleteAsync(id);
        return NoContent();
    }
}
