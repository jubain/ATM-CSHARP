using AutoMapper;
using Hope.BackendServices.API.Areas.ConceptArt.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Controllers
{
    [Route("api/ConceptArt/[controller]")]
    [ApiController]
    [Authorize]
    public class ConceptArtSystemImageController : ControllerBase
    {
        private readonly IConceptArtSystemImageService _conceptArtSystemImageService;
        private readonly IMapper _mapper;

        public ConceptArtSystemImageController(IConceptArtSystemImageService conceptArtSystemImageService, IMapper mapper)
        {
            _conceptArtSystemImageService = conceptArtSystemImageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConceptArtSystemImageDetails conceptArtSystemImageDetails)
        {
            var conceptArtSystemImage = _mapper.Map<ConceptArtSystemImage>(conceptArtSystemImageDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            conceptArtSystemImage.CreatorId = userId;

            var createdConceptArtSystemImage = await _conceptArtSystemImageService.Create(conceptArtSystemImage);

            return Ok(_mapper.Map<ConceptArtSystemImageDetails>(createdConceptArtSystemImage));
        }

        [HttpGet("{conceptArtSystemImageId}")]
        public async Task<IActionResult> GetConceptArtSystemImage(int conceptArtSystemImageId)
        {
            var conceptArtSystemImage = await _conceptArtSystemImageService.Get(conceptArtSystemImageId);

            return Ok(_mapper.Map<ConceptArtSystemImageDetails>(conceptArtSystemImage));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var conceptArtSystemImageList = await _conceptArtSystemImageService.GetAll();
            return Ok(_mapper.Map<IEnumerable<ConceptArtSystemImageDetails>>(conceptArtSystemImageList));
        }


        [HttpPost("{id}/image")]
        public async Task<IActionResult> UploadImage(IFormFile uploadFile, int id)
        {

            var conceptArtSystemImage = await _conceptArtSystemImageService.Get(id);
            if (conceptArtSystemImage != null)
            {
                await _conceptArtSystemImageService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/image")]
        public async Task<IActionResult> DownloadImage(int id)
        {
            var conceptArtSystemImage = await _conceptArtSystemImageService.Get(id);
            if (conceptArtSystemImage != null)
            {
                (Stream responseStream, string mimeType) = await _conceptArtSystemImageService.DownloadImage(conceptArtSystemImage.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = conceptArtSystemImage.ImagePath
                };
            }
            else
                return NotFound();


        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ConceptArtSystemImageDetails conceptArtSystemImageDetails)
        {
            var conceptArtSystemImage = _mapper.Map<ConceptArtSystemImage>(conceptArtSystemImageDetails);

            var updatedConceptArtSystemImage = await _conceptArtSystemImageService.Update(conceptArtSystemImage);

            return Ok(_mapper.Map<ConceptArtSystemImageDetails>(updatedConceptArtSystemImage));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConceptArtSystemImage(int id)
        {
            var conceptArtSystemImage = await _conceptArtSystemImageService.Delete(id);

            return conceptArtSystemImage != null ? Ok("Deleted") : NotFound();
        }

    }
}
