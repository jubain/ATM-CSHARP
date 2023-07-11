using AutoMapper;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Hope.BackendServices.API.Areas.Animation.Controllers
{
    [Route("api/Animation/[controller]")]
    [ApiController]
    [Authorize]
    public class AnimationController : ReferenceDataControllerBase<ApplicationCore.Entities.Animation, AnimationDetails>
    {
        private readonly IServiceProvider serviceProvider;
        public AnimationController(IReferenceDataService<ApplicationCore.Entities.Animation> referenceDataService, IMapper mapper)
            : base(referenceDataService, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? characterNameId)
        {
            if (characterNameId != null)
            {
                return await FindEntities(e => e.CharacterTexture.CharacterNameId.Equals(characterNameId));
            }
            else
            {
                return await GetEntities();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimation(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimation(int id)
        {
            return await DeleteEntity(id);
        }

    }
}
