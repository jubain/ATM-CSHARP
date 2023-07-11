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
    public class SoundSystemController : ControllerBase
    {
        private readonly ISoundSystemService _soundSystemService;
        private readonly IMapper _mapper;

        public SoundSystemController(ISoundSystemService soundSystemService, IMapper mapper)
        {
            _soundSystemService = soundSystemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SoundSystemDetails soundSystemDetails)
        {
            var soundSystem = _mapper.Map<SoundSystem>(soundSystemDetails);

            var createdSoundSystem = await _soundSystemService.Create(soundSystem);

            return Ok(_mapper.Map<SoundSystemDetails>(createdSoundSystem));
        }

        [HttpGet("{soundSystemId}")]
        public async Task<IActionResult> GetSoundSystem(int soundSystemId)
        {
            var soundSystem = await _soundSystemService.Get(soundSystemId);

            return Ok(_mapper.Map<SoundSystemDetails>(soundSystem));
        }

        [HttpGet]
        public async Task<IActionResult> GetSoundSystems()
        {
            var soundSystems = await _soundSystemService.GetAll();

            return Ok(_mapper.Map<IEnumerable<SoundSystemDetails>>(soundSystems));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SoundSystemDetails soundSystemDetails)
        {
            var soundSystem = _mapper.Map<SoundSystem>(soundSystemDetails);

            var updatedSoundSystem = await _soundSystemService.Update(soundSystem);

            return Ok(_mapper.Map<SoundSystemDetails>(updatedSoundSystem));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoundSystem(int id)
        {
            var soundSystem = await _soundSystemService.Delete(id);

            return soundSystem != null ? Ok("Deleted") : NotFound();
        }

    }
}
