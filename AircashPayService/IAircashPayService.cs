using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AircashPay
{
    public interface IAircashPayService
    {
        Task GeneratePartnerCode(string CodeLink);
        Task ConfirmTransaction();
        Task CancelTransaction();
    }
}
