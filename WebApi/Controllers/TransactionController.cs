using Microsoft.AspNetCore.Mvc;
using Services.Transactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ITransactionService _transactionService1;

        public TransactionController(ITransactionService transactionService, ITransactionService transactionService1)
        {
            _transactionService = transactionService;
            _transactionService1 = transactionService1;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            return Ok(await _transactionService.GetTransactions());
           
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactions([FromBody] TransactionDto transactionDto)
        {
            var id = await _transactionService.AddTransactions(transactionDto);
            return CreatedAtAction(nameof(GetTransactions), new { id = id, controller = "Transaction" }, id);
        }
    }
}
