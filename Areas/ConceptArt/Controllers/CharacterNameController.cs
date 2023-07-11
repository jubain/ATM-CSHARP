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
    public class CharacterNameController : ControllerBase
    {
        private readonly IReferenceDataService<CharacterName> _referenceDataService;
        private readonly IMapper _mapper;

        public CharacterNameController(IReferenceDataService<CharacterName> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterNameDetails characterNamesDetails)
        {
            var characterName = _mapper.Map<CharacterName>(characterNamesDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            characterName.CreatorId = userId;

            var createdCharacterName = await _referenceDataService.Create(characterName);

            return Ok(_mapper.Map<CharacterNameDetails>(createdCharacterName));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CharacterNameDetails characterNameDetails)
        {
            var characterName = _mapper.Map<CharacterName>(characterNameDetails);

            var updatedCharacterName = await _referenceDataService.Update(characterName);

            return Ok(_mapper.Map<CharacterNameDetails>(updatedCharacterName));
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacterNames(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var characterNames = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<CharacterNameDetails>>(characterNames));

            }
            else if (statusId != null)
            {

                var characterNames = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<CharacterNameDetails>>(characterNames));

            }
            else
            {
                var characterNames = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<CharacterNameDetails>>(characterNames));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterName(int id)
        {
            var characterName = await _referenceDataService.Get(id);

            return characterName != null ? Ok(_mapper.Map<CharacterNameDetails>(characterName)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterName(int id)
        {
            var characterName = await _referenceDataService.Delete(id);

            return characterName != null ? Ok("Deleted") : NotFound();
        }
    }
}
