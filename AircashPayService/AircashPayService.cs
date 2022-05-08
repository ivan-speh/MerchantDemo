using DataAccess;
using Domain.Entities;
using Service.AircashPay;
using Services.Setting;
using Services.Signature;
using System;
using System.Threading.Tasks;


namespace AircashPayService
{
    public class AircashPayService : IAircashPayService
    {
        private readonly ISettingService _settingService1;

        public AircashPayService(ISettingService settingService)
        {
            _settingService1 = settingService;
        }

        public async Task GeneratePartnerCode(string partnerID, decimal amount, int currencyID, string partnerTransactionID, string description, string codeLink, int? validForPeriod, string locationID)
        {
            var generatePartnerCode = new GeneratePartnerCode()
            {

                PartnerID = partnerID,
                Amount = amount,
                CurrencyID = currencyID,
                PartnerTransactionID = partnerTransactionID,
                Description = description,
                CodeLink = codeLink,
                ValidForPeriod = validForPeriod,
                LocationID = locationID,
                
            };
           var dataToString = SignatureService.ConvertObjectToString(generatePartnerCode);
           var signature = SignatureService.GenerateSignature(dataToString, _settingService1.PrivateKeyPath, _settingService1.PrivateKeyPass);
           generatePartnerCode.Signature = signature;
        }
        
        public async Task ConfirmTransaction(string partnerID, string partnerTransactionID, decimal amount, int currencyID, string aircashTransactionID)
        {
            var confirmTransaction = new ConfirmTransaction()
            {
                PartnerID = partnerID,
                PartnerTransactionID = partnerTransactionID,
                Amount = amount,
                CurrencyID = currencyID,
                AircashTransactionID = aircashTransactionID,
            };
            var dataToString = SignatureService.ConvertObjectToString(confirmTransaction);
            var signature = SignatureService.GenerateSignature(dataToString, _settingService1.PrivateKeyPath, _settingService1.PrivateKeyPass);
            confirmTransaction.Signature = signature;

        }

        public async Task CancelTransaction(string partnerID, string partnerTransactionID)
        {
            var cancelTransaction = new CancelTransaction()
            {
                PartnerTransactionID = partnerTransactionID,
                PartnerID = partnerID,
            };
            var dataToString = SignatureService.ConvertObjectToString(cancelTransaction);
            var signature = SignatureService.GenerateSignature(dataToString, _settingService1.PrivateKeyPath, _settingService1.PrivateKeyPass);
            cancelTransaction.Signature = signature;

         
        }
    }
}
