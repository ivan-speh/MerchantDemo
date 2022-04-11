using System;

namespace Services.Transactions
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string IsoCurrencyCode { get; set; }
        public Guid TransactionId { get; set; }
        public Guid AircashTransactionId { get; set; }
        public DateTime DateTimeUTC { get; set; }
    }
}