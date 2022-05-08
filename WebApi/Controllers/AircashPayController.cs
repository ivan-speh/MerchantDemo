using Microsoft.AspNetCore.Mvc;
using Service.AircashPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AircashPayController : Controller
    {
        private readonly IAircashPayService _aircashPayService;

        public AircashPayController(IAircashPayService aircashPayService)
        {
            _aircashPayService = aircashPayService;
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePartnerCode(GeneratePartnerCode generatePartnerCode)
        {
            await _aircashPayService.GeneratePartnerCode(generatePartnerCode.PartnerID, generatePartnerCode.Amount, generatePartnerCode.CurrencyID, generatePartnerCode.PartnerTransactionID, generatePartnerCode.Description, generatePartnerCode.CodeLink, generatePartnerCode.ValidForPeriod, generatePartnerCode.LocationID);
            return Ok(generatePartnerCode);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmTransaction(ConfirmTransaction confirmTransaction)
        {
            await _aircashPayService.ConfirmTransaction(confirmTransaction.PartnerID, confirmTransaction.PartnerTransactionID, confirmTransaction.Amount, confirmTransaction.CurrencyID, confirmTransaction.AircashTransactionID);
            return Ok(confirmTransaction);

        }

        [HttpPost]
        public async Task<IActionResult> CancelTransaction(CancelTransaction cancelTransaction)
        {
            await _aircashPayService.CancelTransaction(cancelTransaction.PartnerID, cancelTransaction.PartnerTransactionID);
            return Ok(cancelTransaction);
        }
    }
}
