using AutoMapper;
using Hope.BackendServices.API.Areas.ConceptArt.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Controllers
{
    [Route("api/ConceptArt/[controller]")]
    [ApiController]
    [Authorize]
    public class TextureTypeController : ControllerBase
    {
        private readonly IReferenceDataService<TextureType> _referenceDataService;
        private readonly IMapper _mapper;

        public TextureTypeController(IReferenceDataService<TextureType> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TextureTypeDetails textureTypeDetails)
        {
            var textureType = _mapper.Map<TextureType>(textureTypeDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            textureType.CreatorId = userId;

            var createdTextureType = await _referenceDataService.Create(textureType);

            return Ok(_mapper.Map<TextureTypeDetails>(createdTextureType));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TextureTypeDetails textureTypeDetails)
        {
            var textureType = _mapper.Map<TextureType>(textureTypeDetails);

            var updatedTextureType = await _referenceDataService.Update(textureType);

            return Ok(_mapper.Map<TextureTypeDetails>(updatedTextureType));
        }

        [HttpGet]
        public async Task<IActionResult> GetTextureTypes(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var textureTypes = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<TextureTypeDetails>>(textureTypes));

            }
            else if (statusId != null)
            {

                var textureTypes = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<TextureTypeDetails>>(textureTypes));

            }
            else
            {
                var textureTypes = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<TextureTypeDetails>>(textureTypes));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTextureType(int id)
        {
            var textureType = await _referenceDataService.Get(id);

            return textureType != null ? Ok(_mapper.Map<TextureTypeDetails>(textureType)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTextureType(int id)
        {
            var textureType = await _referenceDataService.Delete(id);

            return textureType != null ? Ok("Deleted") : NotFound();
        }
    }
}
