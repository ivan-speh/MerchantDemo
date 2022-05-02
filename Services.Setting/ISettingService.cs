using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Setting
{
    public interface ISettingService
    {
        Dictionary<string, string> GetSettings();
        Task RefreshSettings();

        string PrivateKeyPath { get; }
        string PrivateKeyPass { get; }
        string PartnerID { get; }
    }
}
