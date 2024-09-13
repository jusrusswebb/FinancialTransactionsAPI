using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinancialTransactionsAPI.Data;
using FinancialTransactionsAPI.Models;

namespace FinancialTransactionsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialTransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinancialTransactionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialTransaction>>> GetFinancialTransactions()
        {
            return await _context.FinancialTransactions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialTransaction>> GetFinancialTransaction(int id)
        {
            var transaction = await _context.FinancialTransactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        [HttpPost]
        public async Task<ActionResult<FinancialTransaction>> PostFinancialTransaction(FinancialTransaction transaction)
        {
            _context.FinancialTransactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFinancialTransaction), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialTransaction(int id, FinancialTransaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialTransaction(int id)
        {
            var transaction = await _context.FinancialTransactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.FinancialTransactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
