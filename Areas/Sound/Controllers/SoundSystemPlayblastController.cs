using AutoMapper;
using Hope.BackendServices.API.Areas.Sound.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Sound.Controllers
{
    [Route("api/Sound/[controller]")]
    [ApiController]
    [Authorize]
    public class SoundSystemPlayblastController : ControllerBase
    {
        private readonly ISoundSystemPlayblastService _soundSystemPlayblastService;
        private readonly IMapper _mapper;

        public SoundSystemPlayblastController(ISoundSystemPlayblastService soundSystemPlayblastService, IMapper mapper)
        {
            _soundSystemPlayblastService = soundSystemPlayblastService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SoundSystemPlayblastDetails soundSystemPlayblastDetails)
        {
            var soundSystemPlayblast = _mapper.Map<SoundSystemPlayblast>(soundSystemPlayblastDetails);

            var createdSoundSystemPlayblast = await _soundSystemPlayblastService.Create(soundSystemPlayblast);

            return Ok(_mapper.Map<SoundSystemPlayblastDetails>(createdSoundSystemPlayblast));
        }

        [HttpGet("{soundSystemPlayblastId}")]
        public async Task<IActionResult> GetSoundSystemPlayblast(int soundSystemPlayblastId)
        {
            var soundSystemPlayblast = await _soundSystemPlayblastService.Get(soundSystemPlayblastId);

            return Ok(_mapper.Map<SoundSystemPlayblastDetails>(soundSystemPlayblast));
        }

        [HttpGet]
        public async Task<IActionResult> GetSoundSystemPlayblasts()
        {
            var soundSystemPlayblasts = await _soundSystemPlayblastService.GetAll();

            return Ok(_mapper.Map<IEnumerable<SoundSystemPlayblastDetails>>(soundSystemPlayblasts));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SoundSystemPlayblastDetails soundSystemPlayblastDetails)
        {
            var soundSystemPlayblast = _mapper.Map<SoundSystemPlayblast>(soundSystemPlayblastDetails);

            var updatedSoundSystemPlayblast = await _soundSystemPlayblastService.Update(soundSystemPlayblast);

            return Ok(_mapper.Map<SoundSystemPlayblastDetails>(updatedSoundSystemPlayblast));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoundSystemPlayblast(int id)
        {
            var soundSystemPlayblast = await _soundSystemPlayblastService.Delete(id);

            return soundSystemPlayblast != null ? Ok("Deleted") : NotFound();
        }

        [HttpPost("{id}/sound")]
        public async Task<IActionResult> UploadSound(IFormFile uploadFile, int id)
        {

            var soundSystemPlayblastFile = await _soundSystemPlayblastService.Get(id);
            if (soundSystemPlayblastFile != null)
            {
                await _soundSystemPlayblastService.UploadSound(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/sound")]
        public async Task<IActionResult> DownloadSound(int id)
        {
            var soundSystemPlayblastFile = await _soundSystemPlayblastService.Get(id);
            if (soundSystemPlayblastFile != null)
            {
                (Stream responseStream, string mimeType) = await _soundSystemPlayblastService.DownloadSound(soundSystemPlayblastFile.FilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = soundSystemPlayblastFile.FilePath
                };
            }
            else
                return NotFound();


        }

    }
}
