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
    public class JobTitleController : ControllerBase
    {
        private readonly IReferenceDataService<JobTitle> _referenceDataService;
        private readonly IMapper _mapper;

        public JobTitleController(IReferenceDataService<JobTitle> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobTitleDetails jobTitleDetails)
        {
            var jobTitle = _mapper.Map<JobTitle>(jobTitleDetails);

            var createdJobTitle = await _referenceDataService.Create(jobTitle);

            return Ok(_mapper.Map<JobTitleDetails>(createdJobTitle));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] JobTitleDetails jobTitleDetails)
        {
            var jobTitle = _mapper.Map<JobTitle>(jobTitleDetails);

            var updatedJobTitle = await _referenceDataService.Update(jobTitle);

            return Ok(_mapper.Map<JobTitleDetails>(updatedJobTitle));
        }



       

        [HttpGet]
        public async Task<IActionResult> GetJobTitles(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var jobTitles = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<JobTitleDetails>>(jobTitles));

            }
            else if (statusId != null)
            {

                var jobTitles = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<JobTitleDetails>>(jobTitles));

            }
            else
            {
                var jobTitles = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<JobTitleDetails>>(jobTitles));
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobTitle(int id)
        {
            var jobTitle = await _referenceDataService.Get(id);

            return jobTitle != null ? Ok(_mapper.Map<JobTitleDetails>(jobTitle)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTitle(int id)
        {
            var jobTitle = await _referenceDataService.Delete(id);

            return jobTitle != null ? Ok("Deleted") : NotFound();
        }
    }
}
