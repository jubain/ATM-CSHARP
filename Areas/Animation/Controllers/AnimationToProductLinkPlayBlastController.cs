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
    public class AnimationToProductLinkPlayBlastController : DomainDataControllerBase<ApplicationCore.Entities.AnimationToProductLinkPlayBlast, AnimationToProductLinkPlayBlastDetails>
    {
        private readonly IAnimationToProductLinkPlayBlastService _animationToProductLinkPlayBlastService;

        public AnimationToProductLinkPlayBlastController(IAnimationToProductLinkPlayBlastService animationToProductLinkPlayBlastService, IMapper mapper)
            : base(animationToProductLinkPlayBlastService, mapper)
            {
                _animationToProductLinkPlayBlastService = animationToProductLinkPlayBlastService;
            }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationToProductLinkPlayBlastDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationToProductLinkPlayBlastDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimationToProductLinkPlayBlast(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimationToProductLinkPlayBlast(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/animationToProductLinkPlayBlast")]
        public async Task<IActionResult> UploadAnimationToProductLinkPlayBlast(IFormFile uploadFile, int id)
        {
            var animationToProductLinkPlayBlast = await _animationToProductLinkPlayBlastService.Get(id);
            if (animationToProductLinkPlayBlast != null)
            {
                await _animationToProductLinkPlayBlastService.UploadFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/animationToProductLinkPlayBlast")]
        public async Task<IActionResult> DownloadAnimationToProductLinkPlayBlast(int id)
        {
            var animationToProductLinkPlayBlast = await _animationToProductLinkPlayBlastService.Get(id);
            if (animationToProductLinkPlayBlast != null)
            {
                (Stream responseStream, string mimeType) = await _animationToProductLinkPlayBlastService.DownloadFile(animationToProductLinkPlayBlast.FilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = animationToProductLinkPlayBlast.FilePath
                };
            }
            else
                return NotFound();
        }



    }
}
