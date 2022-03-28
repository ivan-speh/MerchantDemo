namespace Services.Transactions
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string IsoCurrencyCode { get; set; }
        public string TransactionId { get; set; }
        public string AircashTransactionId { get; set; }
        public string DateTimeUTC { get; set; }
    }
}