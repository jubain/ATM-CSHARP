using AutoMapper;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Animation.Controllers
{
    [Route("api/Animation/[controller]")]
    [ApiController]
    [Authorize]
    public class IdlePoseController : ReferenceDataControllerBase<IdlePose, IdlePoseDetails>
    {
        private readonly IIdlePoseService _idlePoseService;

        public IdlePoseController(IIdlePoseService idlePoseService, IMapper mapper)
            : base(idlePoseService, mapper)
        {
            this._idlePoseService = idlePoseService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IdlePoseDetails details)
        {
            return await CreateEntity(details);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IdlePoseDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? characterNameId)
        {
            if (characterNameId != null)
            {
                return await FindEntities(e => e.CharacterNameId.Equals(characterNameId));
            }
            else
            {
                return await GetEntities();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdlePose(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdlePose(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/idlePose")]
        public async Task<IActionResult> UploadIdlePoseFile(IFormFile uploadFile, int id)
        {
            var idlePose = await _idlePoseService.Get(id);
            if (idlePose != null)
            {
                await _idlePoseService.UploadFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/idlePose")]
        public async Task<IActionResult> DownloadIdlePoseFile(int id)
        {
            var idlePose = await _idlePoseService.Get(id);
            if (idlePose != null)
            {
                (Stream responseStream, string mimeType) = await _idlePoseService.DownloadFile(idlePose.IdleFilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = idlePose.IdleFilePath
                };
            }
            else
                return NotFound();
        }
    }
}
