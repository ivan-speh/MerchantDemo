using Microsoft.AspNetCore.Mvc;
using Services.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactionDto = await _transactionService.GetAllTransactionsAsync();
            return Ok(transactionDto);
        }
    }
}
