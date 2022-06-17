using Services.Setting;
using Services.Signature;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Service.AircashPay
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

        public async Task GeneratePartnerCode()
        {
        }
    }
}
