using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public Decimal Amount { get; set; }
        public string IsoCurrencyCode { get; set; }
        public Guid TransactionId { get; set; }
        public Guid AircashTransactionId { get; set; }
        public DateTime DateTimeUTC { get; set; }
    }
}
