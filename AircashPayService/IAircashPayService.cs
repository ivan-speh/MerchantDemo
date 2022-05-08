using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AircashPay
{
    public interface IAircashPayService
    {
        Task GeneratePartnerCode(string partnerID, decimal amount, int currencyID, string partnerTransactionID, string description, string codeLink, int? validForPeriod, string locationID);
        Task ConfirmTransaction(string partnerID, string partnerTransactionID, decimal amount, int currencyID, string aircashTransactionID);
        Task CancelTransaction(string partnerID, string partnerTransactionID);
    }
}
