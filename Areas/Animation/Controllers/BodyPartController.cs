using AutoMapper;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Hope.BackendServices.API.Areas.Animation.Controllers
{
    [Route("api/Animation/[controller]")]
    [ApiController]
    [Authorize]
    public class BodyPartController : ReferenceDataControllerBase<BodyPart, BodyPartDetails>
    {
        public BodyPartController(IReferenceDataService<BodyPart> referenceDataService, IMapper mapper)
            : base(referenceDataService, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BodyPartDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BodyPartDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await GetEntities();
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
