using AutoMapper;
using Hope.BackendServices.API.Areas.Art3D.Models;
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

namespace Hope.BackendServices.API.Areas.Art3D.Controllers
{
    [Route("api/Art3DSystem/[controller]")]
    [ApiController]
    [Authorize]
    public class Art3DSystemImageController : ControllerBase
    {
        private readonly IArt3DSystemImageService _art3DSystemImageService;
        private readonly IMapper _mapper;

        public Art3DSystemImageController(IArt3DSystemImageService art3DSystemImageService, IMapper mapper)
        {
            _art3DSystemImageService = art3DSystemImageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Art3DSystemImageDetails art3DSystemImageDetails)
        {
            var art3DSystemImage = _mapper.Map<Art3DSystemImage>(art3DSystemImageDetails);

            var createdArt3DSystemImage = await _art3DSystemImageService.Create(art3DSystemImage);

            return Ok(_mapper.Map<Art3DSystemImageDetails>(createdArt3DSystemImage));
        }

        [HttpGet("{art3DSystemImageId}")]
        public async Task<IActionResult> GetArt3DSystemImage(int art3DSystemImageId)
        {
            var art3DSystemImage = await _art3DSystemImageService.Get(art3DSystemImageId);

            return Ok(_mapper.Map<Art3DSystemImageDetails>(art3DSystemImage));
        }

        [HttpPost("{id}/image")]
        public async Task<IActionResult> UploadImage(IFormFile uploadFile, int id)
        {

            var art3DSystemImage = await _art3DSystemImageService.Get(id);
            if (art3DSystemImage != null)
            {
                await _art3DSystemImageService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/image")]
        public async Task<IActionResult> DownloadImage(int id)
        {
            var art3DSystemImage = await _art3DSystemImageService.Get(id);
            if (art3DSystemImage != null)
            {
                (Stream responseStream, string mimeType) = await _art3DSystemImageService.DownloadImage(art3DSystemImage.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = art3DSystemImage.ImagePath
                };
            }
            else
                return NotFound();


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var art3DSystemImageList = await _art3DSystemImageService.GetAll();
            return Ok(_mapper.Map<IEnumerable<Art3DSystemImageDetails>>(art3DSystemImageList));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Art3DSystemImageDetails art3DSystemImageDetails)
        {
            var art3DSystemImage = _mapper.Map<Art3DSystemImage>(art3DSystemImageDetails);

            var updatedArt3DSystemImage = await _art3DSystemImageService.Update(art3DSystemImage);

            return Ok(_mapper.Map<Art3DSystemImageDetails>(updatedArt3DSystemImage));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArt3DSystem(int id)
        {
            var art3DSystemImage = await _art3DSystemImageService.Delete(id);

            return art3DSystemImage != null ? Ok("Deleted") : NotFound();
        }

    }
}
