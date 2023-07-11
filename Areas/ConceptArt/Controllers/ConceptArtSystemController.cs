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
    public class ConceptArtSystemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReferenceDataService<ConceptArtSystem> _referenceDataService;

        public ConceptArtSystemController(IReferenceDataService<ConceptArtSystem> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConceptArtSystemDetails conceptArtSystemDetails)
        {
            var conceptArtSystem = _mapper.Map<ConceptArtSystem>(conceptArtSystemDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            conceptArtSystem.CreatorId = userId;

            var createdConceptArtSystem = await _referenceDataService.Create(conceptArtSystem);

            return Ok(_mapper.Map<ConceptArtSystemDetails>(createdConceptArtSystem));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ConceptArtSystemDetails conceptArtSystemDetails)
        {
            var conceptArtSystem = _mapper.Map<ConceptArtSystem>(conceptArtSystemDetails);

            var updatedConceptArtSystem = await _referenceDataService.Update(conceptArtSystem);

            return Ok(_mapper.Map<ConceptArtSystemDetails>(updatedConceptArtSystem));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var conceptArtSystemList = await _referenceDataService.GetAll();
            return Ok(_mapper.Map<IEnumerable<ConceptArtSystemDetails>>(conceptArtSystemList));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConceptArtSystem(int id)
        {
            var conceptArtSystem = await _referenceDataService.Get(id);

            return conceptArtSystem != null ? Ok(_mapper.Map<ConceptArtSystemDetails>(conceptArtSystem)) : NotFound();
        }

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConceptArtSystem(int id)
        {
            var conceptArtSystem = await _referenceDataService.Delete(id);

            return conceptArtSystem != null ? Ok("Deleted") : NotFound();
        }
    }
}
