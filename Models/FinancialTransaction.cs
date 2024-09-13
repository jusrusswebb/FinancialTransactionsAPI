using System;

namespace FinancialTransactionsAPI.Models
{
    public class FinancialTransaction
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}