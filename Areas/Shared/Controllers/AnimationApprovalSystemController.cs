using AutoMapper;
using Hope.BackendServices.API.Areas.Shared.Models;
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

namespace Hope.BackendServices.API.Areas.Shared.Controllers
{
    [Route("api/Shared/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimationApprovalSystemController : ControllerBase
    {
        private readonly IAnimationApprovalSystemService _animationApprovalSystemService;
        private readonly IMapper _mapper;

        public AnimationApprovalSystemController(IAnimationApprovalSystemService animationApprovalSystemService, IMapper mapper)
        {
            _animationApprovalSystemService = animationApprovalSystemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationApprovalSystemDetails animationApprovalSystemDetails)
        {
            var animationApprovalSystem = _mapper.Map<AnimationApprovalSystem>(animationApprovalSystemDetails);
            
            var createdAnimationApprovalSystem = await _animationApprovalSystemService.Create(animationApprovalSystem);

            return Ok(_mapper.Map<AnimationApprovalSystemDetails>(createdAnimationApprovalSystem));
        }

        [HttpGet("{animationApprovalSystemId}")]
        public async Task<IActionResult> GetAnimationApprovalSystem(int animationApprovalSystemId)
        {
            var animationApprovalSystem = await _animationApprovalSystemService.Get(animationApprovalSystemId);

            return Ok(_mapper.Map<AnimationApprovalSystemDetails>(animationApprovalSystem));
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimationApprovalSystems(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var animationApprovalSystems = await _animationApprovalSystemService.Find(e => e.CharacterName.Contains(word));
                return Ok(_mapper.Map<IEnumerable<AnimationApprovalSystemDetails>>(animationApprovalSystems));

            }
            else if (statusId != null)
            {

                var animationApprovalSystems = await _animationApprovalSystemService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<AnimationApprovalSystemDetails>>(animationApprovalSystems));

            }
            else
            {
                var animationApprovalSystems = await _animationApprovalSystemService.GetAll();
                return Ok(_mapper.Map<IEnumerable<AnimationApprovalSystemDetails>>(animationApprovalSystems));
            }

            
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationApprovalSystemDetails animationApprovalSystemDetails)
        {
            var animationApprovalSystem = _mapper.Map<AnimationApprovalSystem>(animationApprovalSystemDetails);

            var updatedAnimationApprovalSystem = await _animationApprovalSystemService.Update(animationApprovalSystem);

            return Ok(_mapper.Map<AnimationApprovalSystemDetails>(updatedAnimationApprovalSystem));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnimationApprovalSystem(int id)
        {
            var animationApprovalSystem = await _animationApprovalSystemService.Delete(id);

            return animationApprovalSystem != null ? Ok("Deleted") : NotFound();
        }

        [HttpPost("{id}/approval")]
        public async Task<IActionResult> UploadFbx(IFormFile uploadFile, int id)
        {

            var animationApprovalSystemPlayblastFile = await _animationApprovalSystemService.Get(id);
            if (animationApprovalSystemPlayblastFile != null)
            {
                await _animationApprovalSystemService.UploadFbx(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/approval")]
        public async Task<IActionResult> DownloadFbx(int id)
        {
            var animationApprovalSystemPlayblastFile = await _animationApprovalSystemService.Get(id);
            if (animationApprovalSystemPlayblastFile != null)
            {
                (Stream responseStream, string mimeType) = await _animationApprovalSystemService.DownloadFbx(animationApprovalSystemPlayblastFile.FilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = animationApprovalSystemPlayblastFile.FilePath
                };
            }
            else
                return NotFound();


        }
    }
}
