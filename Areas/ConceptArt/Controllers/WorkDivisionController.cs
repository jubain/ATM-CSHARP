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
    public class WorkDivisionController : ControllerBase
    {
        private readonly IReferenceDataService<WorkDivision> _referenceDataService;
        private readonly IMapper _mapper;

        public WorkDivisionController(IReferenceDataService<WorkDivision> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkDivisionDetails workDivisionDetails)
        {
            var workDivision = _mapper.Map<WorkDivision>(workDivisionDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            workDivision.CreatorId = userId;

            var createdWorkDivision = await _referenceDataService.Create(workDivision);

            return Ok(_mapper.Map<WorkDivisionDetails>(createdWorkDivision));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] WorkDivisionDetails workDivisionDetails)
        {
            var workDivision = _mapper.Map<WorkDivision>(workDivisionDetails);

            var updatedWorkDivision = await _referenceDataService.Update(workDivision);

            return Ok(_mapper.Map<WorkDivisionDetails>(updatedWorkDivision));
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkDivisions(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var workDivisions = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<WorkDivisionDetails>>(workDivisions));

            }
            else if (statusId != null)
            {

                var workDivisions = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<WorkDivisionDetails>>(workDivisions));

            }

            else
            {
                var workDivisions = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<WorkDivisionDetails>>(workDivisions));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkDivision(int id)
        {
            var workDivision = await _referenceDataService.Get(id);

            return workDivision != null ? Ok(_mapper.Map<WorkDivisionDetails>(workDivision)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkDivision(int id)
        {
            var workDivision = await _referenceDataService.Delete(id);

            return workDivision != null ? Ok("Deleted") : NotFound();
        }





    }
}
