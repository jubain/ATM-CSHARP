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
    public class ColourAvailableSystemImageController : DomainDataControllerBase<ColourAvailableSystemImage, ColourAvailableSystemImageDetails>
    {
        private readonly IColourAvailableSystemImageService _colourAvailableSystemImageService;
        //private readonly IMapper _mapper;

        public ColourAvailableSystemImageController(IColourAvailableSystemImageService colourAvailableSystemImageService, IMapper mapper)
        : base(colourAvailableSystemImageService, mapper)
        {
            _colourAvailableSystemImageService = colourAvailableSystemImageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ColourAvailableSystemImageDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ColourAvailableSystemImageDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColourAvailableSystemImage(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColourAvailableSystemImage(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/colourAvailableSystemImage")]
        public async Task<IActionResult> UploadColourAvailableSystemImage(IFormFile uploadFile, int id)
        {
            var colourAvailableSystemImage = await _colourAvailableSystemImageService.Get(id);
            if (colourAvailableSystemImage != null)
            {
                await _colourAvailableSystemImageService.UploadFile(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/colourAvailableSystemImage")]
        public async Task<IActionResult> DownloadColourAvailableSystemImage(int id)
        {
            var colourAvailableSystemImage = await _colourAvailableSystemImageService.Get(id);
            if (colourAvailableSystemImage != null)
            {
                (Stream responseStream, string mimeType) = await _colourAvailableSystemImageService.DownloadFile(colourAvailableSystemImage.FilePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = colourAvailableSystemImage.FilePath
                };
            }
            else
                return NotFound();
        }



    }
}
