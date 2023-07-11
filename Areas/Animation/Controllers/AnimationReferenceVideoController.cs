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
    public class AnimationReferenceVideoController : ReferenceDataControllerBase<AnimationReferenceVideo, AnimationReferenceVideoDetails>
    {
        private readonly IAnimationReferenceVideoService _animationReferenceVideoService;

        public AnimationReferenceVideoController(IAnimationReferenceVideoService animationReferenceVideoService, IMapper mapper)
            : base(animationReferenceVideoService, mapper)
        {
            _animationReferenceVideoService = animationReferenceVideoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationReferenceVideoDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationReferenceVideoDetails details)
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
        public async Task<IActionResult> GetAnimationReferenceVideo(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimationReferenceVideo(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/animationReferenceVideo")]
        public async Task<IActionResult> UploadAnimationReferenceVideo(IFormFile uploadFile, int id)
        {
            var animationReferenceVideo = await _animationReferenceVideoService.Get(id);
            if (animationReferenceVideo != null)
            {
                await _animationReferenceVideoService.UploadFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/animationReferenceVideo")]
        public async Task<IActionResult> DownloadAnimationReferenceVideo(int id)
        {
            var animationReferenceVideo = await _animationReferenceVideoService.Get(id);
            if (animationReferenceVideo != null)
            {
                (Stream responseStream, string mimeType) = await _animationReferenceVideoService.DownloadFile(animationReferenceVideo.AnimationReferenceVideoFilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = animationReferenceVideo.AnimationReferenceVideoFilePath
                };
            }
            else
                return NotFound();
        }
    }
}
