using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Controllers
{
    [Route("api/hr/[controller]")]
    [ApiController]
    [Authorize]
    public class HierarchyController : ControllerBase
    {
        private readonly IReferenceDataService<Hierarchy> _referenceDataService;
        private readonly IMapper _mapper;

        public HierarchyController(IReferenceDataService<Hierarchy> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HierarchyDetails hierarchyDetails)
        {
            var hierarchy = _mapper.Map<Hierarchy>(hierarchyDetails);

            var createdHierarchy = await _referenceDataService.Create(hierarchy);

            return Ok(_mapper.Map<HierarchyDetails>(createdHierarchy));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HierarchyDetails hierarchyDetails)
        {
            var hierarchy = _mapper.Map<Hierarchy>(hierarchyDetails);

            var updatedHierarchy = await _referenceDataService.Update(hierarchy);

            return Ok(_mapper.Map<HierarchyDetails>(updatedHierarchy));
        }


       

        [HttpGet]
        public async Task<IActionResult> GetHierarchies(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var hierarchies = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<HierarchyDetails>>(hierarchies));

            }
            else if (statusId != null)
            {

                var hierarchies = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<HierarchyDetails>>(hierarchies));

            }
            else
            {
                var hierarchies = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<HierarchyDetails>>(hierarchies));
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetHierarchy(int id)
        {
            var hierarchy = await _referenceDataService.Get(id);

            return hierarchy != null ? Ok(_mapper.Map<HierarchyDetails>(hierarchy)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHierarchy(int id)
        {
            var hierarchy = await _referenceDataService.Delete(id);

            return hierarchy != null ? Ok("Deleted") : NotFound();
        }


    }
}
