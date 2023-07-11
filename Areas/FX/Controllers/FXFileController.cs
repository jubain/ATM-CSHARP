using AutoMapper;
using Hope.BackendServices.API.Areas.FX.Models;
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

namespace Hope.BackendServices.API.Areas.FX.Controllers
{
    [Route("api/FX/[controller]")]
    [ApiController]
    [Authorize]
    public class FXFileController : ControllerBase
    {
        private readonly IFXFileService _fxFileService;
        private readonly IMapper _mapper;

        public FXFileController(IFXFileService fxFileService, IMapper mapper)
        {
            _fxFileService = fxFileService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FXFileDetails fxFileDetails)
        {
            var fxFile = _mapper.Map<FXFile>(fxFileDetails);

            var createdFXFile = await _fxFileService.Create(fxFile);

            return Ok(_mapper.Map<FXFileDetails>(createdFXFile));

        }

        [HttpGet("{fxFileId}")]
        public async Task<IActionResult> GetFXFile(int fxFileId)
        {
            var fxFile = await _fxFileService.Get(fxFileId);

            return Ok(_mapper.Map<FXFileDetails>(fxFile));

        }

        [HttpGet]
        public async Task<IActionResult> GetFXFiles()
        {
            var fxFiles = await _fxFileService.GetAll();

            return Ok(_mapper.Map<IEnumerable<FXFileDetails>>(fxFiles));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FXFileDetails fxFileDetails)
        {
            var fxFile = _mapper.Map<FXFile>(fxFileDetails);

            var updatedFXFile = await _fxFileService.Update(fxFile);

            return Ok(_mapper.Map<FXFileDetails>(updatedFXFile));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFXFile(int id)
        {
            var fxFile = await _fxFileService.Delete(id);

            return fxFile != null ? Ok("Deleted") : NotFound();
        }

        [HttpPost("{id}/fx")]
        public async Task<IActionResult> UploadFX(IFormFile uploadFile, int id)
        {

            var fxFile = await _fxFileService.Get(id);
            if (fxFile != null)
            {
                await _fxFileService.UploadFX(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/fx")]
        public async Task<IActionResult> DownloadFX(int id)
        {
            var fxFile = await _fxFileService.Get(id);
            if (fxFile != null)
            {
                (Stream responseStream, string mimeType) = await _fxFileService.DownloadFX(fxFile.FilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = fxFile.FilePath
                };
            }
            else
                return NotFound();


        }

    }
}
