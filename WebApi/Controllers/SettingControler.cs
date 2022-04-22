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


        public SettingControler(ISettingService settingService)
        {
            _settingsService = settingService;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetSettings()
        {
            return Ok(_settingsService.GetSettings());

        }

        [HttpGet]
        public async Task<IActionResult> RefreshSettings()
        {
            await _settingsService.RefreshSettings();
            return Ok();
        }
    }

}
