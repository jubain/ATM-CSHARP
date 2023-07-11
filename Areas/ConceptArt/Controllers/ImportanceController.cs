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
    public class ImportanceController : ControllerBase
    {
        private readonly IReferenceDataService<Importance> _referenceDataService;
        private readonly IMapper _mapper;

        public ImportanceController(IReferenceDataService<Importance> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImportanceDetails importanceDetails)
        {
            var importance = _mapper.Map<Importance>(importanceDetails);
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            importance.CreatorId = userId;
            var createdImportance = await _referenceDataService.Create(importance);
            return Ok(_mapper.Map<ImportanceDetails>(createdImportance));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ImportanceDetails importanceDetails)
        {
            var importance = _mapper.Map<Importance>(importanceDetails);
            var updatedImportance = await _referenceDataService.Update(importance);
            return Ok(_mapper.Map<ImportanceDetails>(updatedImportance));
        }

        [HttpGet]
        public async Task<IActionResult> GetImportances(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                var importance = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<ImportanceDetails>>(importance));
            }
            else if(statusId != null)
            {
                var importance = await _referenceDataService.Find(e => e.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<ImportanceDetails>>(importance));
            }
            else
            {
                var importance = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<ImportanceDetails>>(importance));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImportance(int id)
        {
            var importance = await _referenceDataService.Get(id);

            return importance != null ? Ok(_mapper.Map<ImportanceDetails>(importance)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImportance(int id)
        {
            var importance = await _referenceDataService.Delete(id);

            return importance != null ? Ok("Deleted") : NotFound();
        }
    }
}
