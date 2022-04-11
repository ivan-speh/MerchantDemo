using Microsoft.AspNetCore.Mvc;
using Services.Setting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SettingControler : Controller
    {
        private readonly ISettingService _settingsService;
        private readonly ISettingService _settingsService1;

        public SettingControler(ISettingService settingService, ISettingService settingService1)
        {
            _settingsService = settingService;
            _settingsService1 = settingService1;
        }

        [HttpGet]
        public Dictionary<string, string> GetSettings()
        {
            return Ok(_settingsService.GetSettings());

        }

        [HttpGet]
        public async Task<IActionResult> RefreshSettings()
        {
            return Ok(await _settingsService1.RefreshSettings());
        }
    }
}
