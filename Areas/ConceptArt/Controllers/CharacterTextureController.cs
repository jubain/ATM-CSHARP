using AutoMapper;
using Hope.BackendServices.API.Areas.Animation.Controllers;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Controllers
{
    [Route("api/Animation/[controller]")]
    [ApiController]
    [Authorize]
    public class CharacterTextureController : ReferenceDataControllerBase<CharacterTexture, CharacterTextureDetails>
    {
        public CharacterTextureController(IReferenceDataService<CharacterTexture> referenceDataService, IMapper mapper)
            : base(referenceDataService, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CharacterTextureDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CharacterTextureDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterTexture(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterTexture(int id)
        {
            return await DeleteEntity(id);
        }
    }
}
