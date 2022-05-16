using DataAccess;
using Domain.Entities;
using Service.AircashPay;
using Services.Setting;
using Services.Signature;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace AircashPayService
{
    public class AircashPayService : IAircashPayService
    {
        private readonly ISettingService _settingService;
        private readonly ISignatureService _signatureService;

        
        public AircashPayService(ISettingService settingService, ISignatureService signatureService)
        {
            _settingService = settingService;
            _signatureService = signatureService;
        }

        public async Task GeneratePartnerCode(decimal amount, int currencyID,  string description)
        {
            var partnerTransactionID = Guid.NewGuid();
            var partnerID = _settingService.PartnerID;

            var generatePartnerCode = new GeneratePartnerCode()
            {
                PartnerID = partnerID,
                Amount = amount,
                CurrencyID = currencyID,
                PartnerTransactionID = partnerTransactionID.ToString(),
                Description = description,
                LocationID = null,
                
            };

           var dataToString = SignatureService.ConvertObjectToString(generatePartnerCode);
           var signature = SignatureService.GenerateSignature(dataToString, _settingService.PrivateKeyPath, _settingService.PrivateKeyPass);
           generatePartnerCode.Signature = signature;
        }
        
        
        public async Task ConfirmTransaction(decimal amount, int currencyID, string aircashTransactionID)
        {
            var partnerTransactionID = Guid.NewGuid();
            var partnerID = _settingService.PartnerID;

            var confirmTransaction = new ConfirmTransaction()
            {
                PartnerID = partnerID,
                PartnerTransactionID = partnerTransactionID.ToString(),
                Amount = amount,
                CurrencyID = currencyID,
                AircashTransactionID = aircashTransactionID,
            };
            var dataToString = SignatureService.ConvertObjectToString(confirmTransaction);
            var signature = SignatureService.GenerateSignature(dataToString, _settingService.PrivateKeyPath, _settingService.PrivateKeyPass);
            confirmTransaction.Signature = signature;

        }

        public async Task CancelTransaction()
        {
            var partnerTransactionID = Guid.NewGuid();
            var partnerID = _settingService.PartnerID;

            var cancelTransaction = new CancelTransaction()
            {
                PartnerTransactionID = partnerTransactionID.ToString(),
                PartnerID = partnerID,
            };
            var dataToString = SignatureService.ConvertObjectToString(cancelTransaction);
            var signature = SignatureService.GenerateSignature(dataToString, _settingService.PrivateKeyPath, _settingService.PrivateKeyPass);
            cancelTransaction.Signature = signature;

         
        }
    }
}
