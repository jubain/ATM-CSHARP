using AutoMapper;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Hope.BackendServices.ApplicationCore.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace Hope.BackendServices.API.Areas.Animation.Controllers
{
    [Route("api/Animation/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimationExpressionController : ReferenceDataControllerBase<AnimationExpression, AnimationExpressionDetails>
    {
        private readonly IAnimationExpressionService _animationExpressionService;

        public AnimationExpressionController(IAnimationExpressionService animationExpressionService, IMapper mapper)
            : base(animationExpressionService, mapper)
        {
            _animationExpressionService = animationExpressionService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationExpressionDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationExpressionDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? characterNameId, [FromQuery] int? bodyPartId)
        {
            
            var filterExpression = PredicateBuilder.Create<AnimationExpression>();
            if (characterNameId != null) filterExpression = filterExpression.And(e => e.CharacterNameId.Equals(characterNameId));
            if (bodyPartId != null) filterExpression = filterExpression.And(e => e.BodyPartId.Equals(bodyPartId));

            if (filterExpression.Any())
            {
                return await FindEntities(filterExpression);
            }
            else
            {
                return await GetEntities();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimationExpression(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimationExpression(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/animationExpression")]
        public async Task<IActionResult> UploadAnimationExpression(IFormFile uploadFile, int id)
        {
            var animationExpression = await _animationExpressionService.Get(id);
            if (animationExpression != null)
            {
                await _animationExpressionService.UploadFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/animationExpression")]
        public async Task<IActionResult> DownloadAnimationExpression(int id)
        {
            var animationExpression = await _animationExpressionService.Get(id);
            if (animationExpression != null)
            {
                (Stream responseStream, string mimeType) = await _animationExpressionService.DownloadFile(animationExpression.AnimationExpressionFilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = animationExpression.AnimationExpressionFilePath
                };
            }
            else
                return NotFound();
        }
    }
}
