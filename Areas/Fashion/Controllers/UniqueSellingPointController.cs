using AutoMapper;
using Hope.BackendServices.API.Areas.Fashion.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
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

namespace Hope.BackendServices.API.Areas.Fashion.Controllers
{
    [Route("api/Fashion/[controller]")]
    [ApiController]
    [Authorize]
    public class UniqueSellingPointController : ReferenceDataControllerBase<UniqueSellingPoint, UniqueSellingPointDetails>
    {
        private readonly IUniqueSellingPointService _uniqueSellingPointService;
        //private readonly IMapper _mapper;

        public UniqueSellingPointController(IUniqueSellingPointService uniqueSellingPointService, IMapper mapper)
            : base(uniqueSellingPointService, mapper)
        {
            _uniqueSellingPointService = uniqueSellingPointService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UniqueSellingPointDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UniqueSellingPointDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUniqueSellingPoint(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniqueSellingPoint(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/uniqueSellingPoint")]
        public async Task<IActionResult> UploadUniqueSellingPoint(IFormFile uploadFile, int id)
        {
            var uniqueSellingPoint = await _uniqueSellingPointService.Get(id);
            if (uniqueSellingPoint != null)
            {
                await _uniqueSellingPointService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/uniqueSellingPoint")]
        public async Task<IActionResult> DownloadUniqueSellingPoint(int id)
        {
            var uniqueSellingPointIcon = await _uniqueSellingPointService.Get(id);
            if (uniqueSellingPointIcon != null)
            {
                (Stream responseStream, string mimeType) = await _uniqueSellingPointService.DownloadImage(uniqueSellingPointIcon.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = uniqueSellingPointIcon.ImagePath
                };
            }
            else
                return NotFound();
        }

    }
}
