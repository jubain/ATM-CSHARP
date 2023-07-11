using AutoMapper;
using Hope.BackendServices.API.Areas.Sound.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Sound.Controllers
{
    [Route("api/Sound/[controller]")]
    [ApiController]
    [Authorize]
    public class SoundTimeIntervalController : ControllerBase
    {
        private readonly ISoundTimeIntervalService _soundTimeIntervalService;
        private readonly IMapper _mapper;

        public SoundTimeIntervalController(ISoundTimeIntervalService soundTimeIntervalService, IMapper mapper)
        {
            _soundTimeIntervalService = soundTimeIntervalService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SoundTimeIntervalDetails soundTimeIntervalDetails)
        {
            var soundTimeInterval = _mapper.Map<SoundTimeInterval>(soundTimeIntervalDetails);

            var createdSoundTimeInterval = await _soundTimeIntervalService.Create(soundTimeInterval);

            return Ok(_mapper.Map<SoundTimeIntervalDetails>(createdSoundTimeInterval));

        }

        [HttpGet("{soundTimeIntervalId}")]
        public async Task<IActionResult> GetSoundTimeInterval(int soundTimeIntervalId)
        {
            var soundTimeInterval = await _soundTimeIntervalService.Get(soundTimeIntervalId);

            return Ok(_mapper.Map<SoundTimeIntervalDetails>(soundTimeInterval));
        }

        [HttpGet]
        public async Task<IActionResult> GetSoundTimeIntervals()
        {
            var soundTimeIntervals = await _soundTimeIntervalService.GetAll();

            return Ok(_mapper.Map<IEnumerable<SoundTimeIntervalDetails>>(soundTimeIntervals));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SoundTimeIntervalDetails soundTimeIntervalDetails)
        {
            var soundTimeInterval = _mapper.Map<SoundTimeInterval>(soundTimeIntervalDetails);

            var updatedSoundTimeInterval = await _soundTimeIntervalService.Update(soundTimeInterval);

            return Ok(_mapper.Map<SoundTimeIntervalDetails>(updatedSoundTimeInterval));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoundTimeInterval(int id)
        {
            var soundTimeInterval = await _soundTimeIntervalService.Delete(id);

            return soundTimeInterval != null ? Ok("Deleted") : NotFound();
        }


    }
}
