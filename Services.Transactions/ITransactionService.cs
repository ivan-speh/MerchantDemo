using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Transactions
{
    public interface ITransactionService
    {
        Task<List<TransactionDto>> GetTransactions();
        Task<int> AddTransactions(TransactionDto transactionDto);
    }
}
