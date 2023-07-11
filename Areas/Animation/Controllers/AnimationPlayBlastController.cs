using AutoMapper;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;


namespace Hope.BackendServices.API.Areas.Animation.Controllers
{
    [Route("api/Animation/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimationPlayBlastController : ReferenceDataControllerBase<AnimationPlayBlast, AnimationPlayBlastDetails>
    {
        private readonly IAnimationPlayBlastService _animationPlayBlastService;

        public AnimationPlayBlastController(IAnimationPlayBlastService animationPlayBlastService, IMapper mapper)
            : base(animationPlayBlastService, mapper)
        {
            this._animationPlayBlastService = animationPlayBlastService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationPlayBlastDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationPlayBlastDetails details)
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
        public async Task<IActionResult> GetPlayBlast(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayBlast(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/animationPlayBlast")]
        public async Task<IActionResult> UploadPlayBlastFile(IFormFile uploadFile, int id)
        {
            var entity = await _animationPlayBlastService.Get(id);
            if (entity != null)
            {
                await _animationPlayBlastService.UploadFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost("{id}/animationPlayBlastFBX")]
        public async Task<IActionResult> UploadFbxFile(IFormFile uploadFile, int id)
        {
            var entity = await _animationPlayBlastService.Get(id);
            if (entity != null)
            {
                await _animationPlayBlastService.UploadFbxFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost("{id}/animationPlayBlastMaya")]
        public async Task<IActionResult> UploadMayaFile(IFormFile uploadFile, int id)
        {
            var entity = await _animationPlayBlastService.Get(id);
            if (entity != null)
            {
                await _animationPlayBlastService.UploadMayaFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/animationPlayBlast")]
        public async Task<IActionResult> DownloadPlayBlastFile(int id)
        {
            var animationPlayBlast = await _animationPlayBlastService.Get(id);
            if (animationPlayBlast != null)
            {
                return await DownloadFile(animationPlayBlast.PlayBlastFilePath);
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/animationPlayBlastFBX")]
        public async Task<IActionResult> DownloadFbxFile(int id)
        {
            var animationPlayBlast = await _animationPlayBlastService.Get(id);
            if (animationPlayBlast != null)
            {
                return await DownloadFile(animationPlayBlast.FBXFilePath);
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/animationPlayBlastMaya")]
        public async Task<IActionResult> DownloadMayaFile(int id)
        {
            var animationPlayBlast = await _animationPlayBlastService.Get(id);
            if (animationPlayBlast != null)
            {
                return await DownloadFile(animationPlayBlast.MayaFilePath);
            }
            else
                return NotFound();
        }

        private async Task<IActionResult> DownloadFile(string filename)
        {
            (Stream responseStream, string mimeType) = await _animationPlayBlastService.DownloadFile(filename);
            return new FileStreamResult(responseStream, mimeType)
            {
                FileDownloadName = filename
            };
        }
    }
}
