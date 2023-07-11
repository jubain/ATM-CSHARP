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
    public class SoundFileController : ControllerBase
    {
        private readonly ISoundFileService _soundFileService;
        private readonly IMapper _mapper;

        public SoundFileController(ISoundFileService soundFileService, IMapper mapper)
        {
            _soundFileService = soundFileService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SoundFileDetails soundFileDetails)
        {
            var soundFile = _mapper.Map<SoundFile>(soundFileDetails);

            var createdSoundFile = await _soundFileService.Create(soundFile);

            return Ok(_mapper.Map<SoundFileDetails>(createdSoundFile));

        }

        [HttpGet("{soundFileId}")]
        public async Task<IActionResult> GetSoundFile(int soundFileId)
        {
            var soundFile = await _soundFileService.Get(soundFileId);

            return Ok(_mapper.Map<SoundFileDetails>(soundFile));

        }

        [HttpGet]
        public async Task<IActionResult> GetSoundFiles()
        {
            var soundFiles = await _soundFileService.GetAll();

            return Ok(_mapper.Map<IEnumerable<SoundFileDetails>>(soundFiles));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SoundFileDetails soundFileDetails)
        {
            var soundFile = _mapper.Map<SoundFile>(soundFileDetails);

            var updatedSoundFile = await _soundFileService.Update(soundFile);

            return Ok(_mapper.Map<SoundFileDetails>(updatedSoundFile));

        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSoundFile(int id)
        {
            var soundFile = await _soundFileService.Delete(id);

            return soundFile != null ? Ok("Deleted") : NotFound();
        }

        [HttpPost("{id}/sound")]
        public async Task<IActionResult> UploadSound(IFormFile uploadFile, int id)
        {

            var soundFile = await _soundFileService.Get(id);
            if (soundFile != null)
            {
                await _soundFileService.UploadSound(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/sound")]
        public async Task<IActionResult> DownloadSound(int id)
        {
            var soundFile = await _soundFileService.Get(id);
            if (soundFile != null)
            {
                (Stream responseStream, string mimeType) = await _soundFileService.DownloadSound(soundFile.FilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = soundFile.FilePath
                };
            }
            else
                return NotFound();


        }

    }
}
