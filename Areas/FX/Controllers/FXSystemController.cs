using AutoMapper;
using Hope.BackendServices.API.Areas.FX.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.FX.Controllers
{
    [Route("api/FX/[controller]")]
    [ApiController]
    [Authorize]
    public class FXSystemController : ControllerBase
    {
        private readonly IFXSystemService _fxSystemService;
        private readonly IMapper _mapper;

        public FXSystemController(IFXSystemService fxSystemService, IMapper mapper)
        {
            _fxSystemService = fxSystemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FXSystemDetails fxSystemDetails)
        {
            var fxSystem = _mapper.Map<FXSystem>(fxSystemDetails);
            
            var createdFXSystem = await _fxSystemService.Create(fxSystem);

            return Ok(_mapper.Map<FXSystemDetails>(createdFXSystem));
        }

        [HttpGet("{fxSystemId}")]
        public async Task<IActionResult> GetFXSystem(int fxSystemId)
        {
            var fxSystem = await _fxSystemService.Get(fxSystemId);

            return Ok(_mapper.Map<FXSystemDetails>(fxSystem));
        }

        [HttpGet]
        public async Task<IActionResult> GetFXSystems()
        {
            var fxSystems = await _fxSystemService.GetAll();

            return Ok(_mapper.Map<IEnumerable<FXSystemDetails>>(fxSystems));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FXSystemDetails fxSystemDetails)
        {
            var fxSystem = _mapper.Map<FXSystem>(fxSystemDetails);

            var updatedFXSystem = await _fxSystemService.Update(fxSystem);

            return Ok(_mapper.Map<FXSystemDetails>(updatedFXSystem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFXSystem(int id)
        {
            var fxSystem = await _fxSystemService.Delete(id);

            return fxSystem != null ? Ok("Deleted") : NotFound();
        }

    }
}
