using AutoMapper;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Animation.Controllers
{
    public class AnimationAmalgamationPlayBlastController : DomainDataControllerBase<ApplicationCore.Entities.AnimationAmalgamationPlayBlast, AnimationAmalgamationPlayBlastDetails>
    {
        private readonly IAnimationAmalgamationPlayBlastService _animationAmalgamationPlayBlastService;

        public AnimationAmalgamationPlayBlastController(IAnimationAmalgamationPlayBlastService animationAmalgamationPlayBlastService, IMapper mapper)
            : base(animationAmalgamationPlayBlastService, mapper)
        {
            _animationAmalgamationPlayBlastService = animationAmalgamationPlayBlastService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationAmalgamationPlayBlastDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationAmalgamationPlayBlastDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimationAmalgamationPlayBlast(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimationAmalgamationPlayBlast(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/animationAmalgamationPlayBlast")]
        public async Task<IActionResult> UploadAnimationAmalgamationPlayBlast(IFormFile uploadFile, int id)
        {
            var animationAmalgamationPlayBlast = await _animationAmalgamationPlayBlastService.Get(id);
            if (animationAmalgamationPlayBlast != null)
            {
                await _animationAmalgamationPlayBlastService.UploadFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/animationAmalgamationPlayBlast")]
        public async Task<IActionResult> DownloadAnimationAmalgamationPlayBlast(int id)
        {
            var animationAmalgamationPlayBlast = await _animationAmalgamationPlayBlastService.Get(id);
            if (animationAmalgamationPlayBlast != null)
            {
                (Stream responseStream, string mimeType) = await _animationAmalgamationPlayBlastService.DownloadFile(animationAmalgamationPlayBlast.FilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = animationAmalgamationPlayBlast.FilePath
                };
            }
            else
                return NotFound();
        }


    }
}
