using System;

namespace Domain.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string IsoCurrencyCode { get; set; }
        public string TransactionId { get; set; }
        public string AircashTransactionId { get; set; }
        public DateTime DateTimeUTC { get; set; }
    }
}
