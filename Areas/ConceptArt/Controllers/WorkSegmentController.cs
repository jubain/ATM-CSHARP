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
    public class WorkSegmentController : ControllerBase
    {
        private readonly IReferenceDataService<WorkSegment> _referenceDataService;
        private readonly IMapper _mapper;

        public WorkSegmentController(IReferenceDataService<WorkSegment> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkSegmentDetails workSegmentDetails)
        {
            var workSegment = _mapper.Map<WorkSegment>(workSegmentDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            workSegment.CreatorId = userId;

            var createdWorkSegment = await _referenceDataService.Create(workSegment);

            return Ok(_mapper.Map<WorkSegmentDetails>(createdWorkSegment));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] WorkSegmentDetails workSegmentDetails)
        {
            var workSegment = _mapper.Map<WorkSegment>(workSegmentDetails);

            var updatedWorkSegment = await _referenceDataService.Update(workSegment);

            return Ok(_mapper.Map<WorkSegmentDetails>(updatedWorkSegment));
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkSegments(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var workSegments = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<WorkSegmentDetails>>(workSegments));

            }
            else if (statusId != null)
            {

                var workSegments = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<WorkSegmentDetails>>(workSegments));

            }
            else
            {
                var workSegments = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<WorkSegmentDetails>>(workSegments));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkSegment(int id)
        {
            var workSegment = await _referenceDataService.Get(id);

            return workSegment != null ? Ok(_mapper.Map<WorkSegmentDetails>(workSegment)) : NotFound();
        }

        [HttpGet("{workDivisionId}")]
        public async Task<IActionResult> GetWorkSegmentByWorkDivision(int workDivisionId)
        {
            var workSegments = await _referenceDataService.Find(e => e.WorkDivisionId.Equals(workDivisionId));
            return Ok(_mapper.Map<IEnumerable<WorkSegmentDetails>>(workSegments));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkSegment(int id)
        {
            var workSegment = await _referenceDataService.Delete(id);

            return workSegment != null ? Ok("Deleted") : NotFound();
        }

    }
}
