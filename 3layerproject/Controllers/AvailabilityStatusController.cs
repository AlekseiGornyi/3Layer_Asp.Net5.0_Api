using _3layerproject.Models.AvailabilityStatus;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3layerproject.Controllers
{
    //[EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityStatusController : ControllerBase
    {
        private IAvailabilityStatus_Service _availabilitystatus_service;

        public AvailabilityStatusController(IAvailabilityStatus_Service availabilitystatus_service)
        {
            _availabilitystatus_service = availabilitystatus_service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddSingleAvailabilityStatus(string name)
        {
            var result = await _availabilitystatus_service.AddSingleAvailabilityStatus(name);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAvailabilityStatusId(long id)
        {
            var result = await _availabilitystatus_service.GetAvailabilityStatusId(id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAvailabilityStatus(AvailabilityStatusUpdate_Pass_Object status)
        {
            var result = await _availabilitystatus_service.UpdateAvailabilityStatus(status.id, status.name);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
