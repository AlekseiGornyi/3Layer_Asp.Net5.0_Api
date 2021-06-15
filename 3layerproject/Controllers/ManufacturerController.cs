using _3layerproject.Models.Manufacturer;
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
    public class ManufacturerController : ControllerBase
    {
        // Инициализируем экземпляр интерфейса
        private IManufacturer_Service _manufacturer_service;

        // Конструктор ManufacturerController которые принимает в себя экземпляр типа IManufacturer_Service
        public ManufacturerController(IManufacturer_Service manufacturer_service)
        {
            _manufacturer_service = manufacturer_service;
        }

        [HttpPost]
        [Route("[action]")]
        // Метод добавления запили AddManufacturer принимает объект manufacturer типа Manufacturer_Pass_Object
        // и возвращает статус код благодаря типу IActionResult
        // переменная result обращается к экземпляру интерфейса IManufacturer_Service и вызывает метод AddSingleManufacturer
        // передавая в него необходимые аргументы. Далее вызывает switch в зависимости от result.success 
        public async Task<IActionResult> AddManufacturer(Manufacturer_Pass_Object manufacturer)
        {
            var result = await _manufacturer_service.AddSingleManufacturer(manufacturer.name, manufacturer.description);
            switch(result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetManufacturerById(long manufacturer_id)
        {
            var result = await _manufacturer_service.GetManufacturerById(manufacturer_id);
            switch(result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateManufacturer(ManufacturerUpdate_Pass_Object manufacturer)
        {
            var result = await _manufacturer_service.UpdateManufacturer(manufacturer.id, manufacturer.name, manufacturer.description);
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
