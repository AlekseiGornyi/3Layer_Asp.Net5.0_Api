using _3layerproject.Models.Specification;
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
    public class SpecificationController : ControllerBase
    {
        private ISpecification_Service _specification_service;

        public SpecificationController(ISpecification_Service specification_service)
        {
            _specification_service = specification_service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddSingleSpecification(Specification_Pass_Object specification)
        {
            var result = await _specification_service.AddSingleSpecification(specification.type, specification.size,
                specification.color, specification.isGaming);
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
        public async Task<IActionResult> GetSpecificationById(long id)
        {
            var result = await _specification_service.GetSpecificationById(id);
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
        public async Task<IActionResult> UpdateSpecification(SpecificationUpdate_Pass_Object specification)
        {
            var result = await _specification_service.UpdateSpecification(specification.id, specification.type, specification.size,
                specification.color, specification.isGaming);
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
