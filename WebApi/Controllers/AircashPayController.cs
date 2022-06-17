﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GeneratePartnerCode()
        {
            await _aircashPayService.GeneratePartnerCode();
            return Ok();
        }
    }
}
