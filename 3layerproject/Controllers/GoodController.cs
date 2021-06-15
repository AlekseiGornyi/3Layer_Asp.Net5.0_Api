using _3layerproject.Models.Good;
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
    public class GoodController : ControllerBase
    {

        private IGood_Service _good_service;
        public GoodController(IGood_Service good_service)
        {
            _good_service = good_service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddSingleGood(Good_Pass_Object good)
        {
            var result = await _good_service.AddSingleGood(/*good.availablilityStatus_ID = */1 , good.manufacturer_ID, good.specification_ID, good.name, good.description);

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
        public async Task<IActionResult> UpdateGood(GoodUpdate_Pass_Object good)
        {
            var result = await _good_service.UpdateGood(good.id, good.availablilityStatus_ID, good.manufacturer_ID,
                good.specification_ID, good.name, good.description);

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
        public async Task<IActionResult> GetGoodById(long id)
        {
            var result = await _good_service.GetGoodById(id);

            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        /*[HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetGoodsByManufacturerId(long id)
        {
            var result = await _good_service.GetGoodsByManufacturerId(id);

            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }*/
    }
}
