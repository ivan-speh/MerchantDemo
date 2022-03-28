using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private AircashSimulatorContext AircasSimulatorContext;
        public TransactionService(AircashSimulatorContext aircashSimulatorContext)
        {
            AircasSimulatorContext = aircashSimulatorContext;

        }

        public Task<List<TransactionDto>> GetTransactions()
        {
            var transaction = AircasSimulatorContext.TransactionDto.Select(x => new TransactionDto()
            {
                Id = x.Id,
                Amount = x.Amount,
                IsoCurrencyCode = x.IsoCurrencyCode,
                TransactionId = x.TransactionId,
                AircashTransactionId = x.AircashTransactionId,
                DateTimeUTC = x.DateTimeUTC
            }).ToListAsync();

            return transaction;
           // throw new NotImplementedException();
        }

        public Task GetAllTransactionsAsync()
        {
            throw new NotImplementedException();
        }
    }

  
}
