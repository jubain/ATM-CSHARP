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
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.FX.Controllers
{
    [Route("api/FX/[controller]")]
    [ApiController]
    [Authorize]
    public class FXSystemPlayblastController : ControllerBase
    {
        private readonly IFXSystemPlayblastService _fxSystemPlayblastService;
        private readonly IMapper _mapper;
        public FXSystemPlayblastController(IFXSystemPlayblastService fxSystemPlayblastService, IMapper mapper)
        {
            _fxSystemPlayblastService = fxSystemPlayblastService;
            _mapper = mapper;                

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FXSystemPlayblastDetails fxSystemPlayblastDetails)
        {
            var fxSystemPlayblast = _mapper.Map<FXSystemPlayblast>(fxSystemPlayblastDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            fxSystemPlayblast.CreatorId = userId;

            var createdFXSystemPlayblast = await _fxSystemPlayblastService.Create(fxSystemPlayblast);

            return Ok(_mapper.Map<FXSystemPlayblastDetails>(createdFXSystemPlayblast));
        }

        [HttpGet("fxSystemPlayblastId")]
        public async Task<IActionResult> GetFXSystemPlayblast(int fxSystemPlayblastId)
        {
            var fxSystemPlayblast = await _fxSystemPlayblastService.Get(fxSystemPlayblastId);

            return Ok(_mapper.Map<FXSystemPlayblastDetails>(fxSystemPlayblast));
        }

        [HttpGet]
        public async Task<IActionResult> GetFXSystemPlayblasts()
        {
            var fxSystemPlayblasts = await _fxSystemPlayblastService.GetAll();

            return Ok(_mapper.Map<IEnumerable<FXSystemPlayblast>>(fxSystemPlayblasts));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FXSystemPlayblastDetails fxSystemPlayblastDetails)
        {
            var fxSystemPlayblast = _mapper.Map<FXSystemPlayblast>(fxSystemPlayblastDetails);

            var updatedFXSystemPlayblast = await _fxSystemPlayblastService.Update(fxSystemPlayblast);

            return Ok(_mapper.Map<FXSystemPlayblastDetails>(updatedFXSystemPlayblast));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFXSystemPlayblast(int id)
        {
            var fxSystemPlayblast = await _fxSystemPlayblastService.Delete(id);

            return fxSystemPlayblast != null ? Ok("Deleted") : NotFound();
        }

        [HttpPost("{id}/fx")]
        public async Task<IActionResult> UploadSound(IFormFile uploadFile, int id)
        {

            var fxSystemPlayblastFile = await _fxSystemPlayblastService.Get(id);
            if (fxSystemPlayblastFile != null)
            {
                await _fxSystemPlayblastService.UploadFX(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/fx")]
        public async Task<IActionResult> DownloadFX(int id)
        {
            var fxSystemPlayblastFile = await _fxSystemPlayblastService.Get(id);
            if (fxSystemPlayblastFile != null)
            {
                (Stream responseStream, string mimeType) = await _fxSystemPlayblastService.DownloadFX(fxSystemPlayblastFile.FilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = fxSystemPlayblastFile.FilePath
                };
            }
            else
                return NotFound();


        }




    }
}
