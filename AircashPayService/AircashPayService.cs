using DataAccess;
using Service.AircashPay;
using System;
using System.Threading.Tasks;


namespace AircashPayService
{
    public class AircashPayService : IAircashPayService
    {

        public async Task GeneratePartnerCode(string CodeLink)
        {
            var generatePartnerCode = new GeneratePartnerCode()
            {
                PartnerID = "PartnerID",
                Amount = 123.45m,
                CurrencyID = 191,
                PartnerTransactionID = "partnerTransactionID1",
                Description = "Invoice 52",
                CodeLink = "https://aircashtest.page.link/?link=https%3a%2f%2faircash.eu%2facpay%3ftype%3d3%26code%3d369564fc-053a-4787-b000-3a28c6607281&apn=com.aircash.aircash.test&ibi=com.aircash.aircash.test&afl=https://aircash.eu/acpay&ifl=https://aircash.eu/acpay"
            };   
        }

        public async Task ConfirmTransaction()
        {
            var confirmTransaction = new ConfirmTransaction()
            {
                PartnerID = "PartnerID",
                PartnerTransactionID = "c1cf13b4-52ce-4b2f-9f9b-9d31cc1f800a",
                Amount = 123.45m,
                CurrencyID = 191,
                Signature = "12345...abc",
                AircashTransactionID = "Aircash transaction id"
            };    
        }

        public async Task CancelTransaction()
        {
            var cancelTransaction = new CancelTransaction()
            {
                PartnerTransactionID = "c1cf13b4-52ce-4b2f-9f9b-9d31cc1f800a",
                PartnerID = "PartnerID",
                Signature = "12345...abc"
            };
        }
    }
}
