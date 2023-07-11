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
    public class FXTimeIntervalController : ControllerBase
    {
        private readonly IFXTimeIntervalService _fxTimeIntervalService;
        private readonly IMapper _mapper;

        public FXTimeIntervalController(IFXTimeIntervalService fxTimeIntervalService, IMapper mapper)
        {
            _fxTimeIntervalService = fxTimeIntervalService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FXTimeIntervalDetails fxTimeIntervalDetails)
        {
            var fxTimeInterval = _mapper.Map<FXTimeInterval>(fxTimeIntervalDetails);

            var createdFXTimeInterval = await _fxTimeIntervalService.Create(fxTimeInterval);

            return Ok(_mapper.Map<FXTimeIntervalDetails>(createdFXTimeInterval));
        }

        [HttpGet("{fxTimeIntervalId}")]
        public async Task<IActionResult> GetFXTimeInterval(int fxTimeIntervalId)
        {
            var fxTimeInterval = await _fxTimeIntervalService.Get(fxTimeIntervalId);

            return Ok(_mapper.Map<FXTimeIntervalDetails>(fxTimeInterval));
        }

        [HttpGet]
        public async Task<IActionResult> GetFXTimeIntervals()
        {
            var fxTimeIntervals = await _fxTimeIntervalService.GetAll();

            return Ok(_mapper.Map<IEnumerable<FXTimeInterval>>(fxTimeIntervals));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FXTimeIntervalDetails fxTimeIntervalDetails)
        {
            var fxTimeInterval = _mapper.Map<FXTimeInterval>(fxTimeIntervalDetails);

            var updatedFXTimeInterval = await _fxTimeIntervalService.Update(fxTimeInterval);

            return Ok(_mapper.Map<FXTimeIntervalDetails>(updatedFXTimeInterval));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFXTimeInterval(int id)
        {
            var fxTimeInterval = await _fxTimeIntervalService.Delete(id);

            return fxTimeInterval != null ? Ok("Deleted") : NotFound();
        }

    }
}
