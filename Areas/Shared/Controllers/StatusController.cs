using AutoMapper;
using Hope.BackendServices.API.SharedApiModel;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Shared.Controllers
{
    [Route("api/Shared/[controller]")]
    [ApiController]
    [Authorize]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;

        public StatusController(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StatusDetails statusDetails)
        {
            var status = _mapper.Map<ReferenceDataStatus>(statusDetails);

            var createdStatus = await _statusService.Create(status);

            return Ok(_mapper.Map<StatusDetails>(createdStatus));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StatusDetails statusDetails)
        {
            var status = _mapper.Map<ReferenceDataStatus>(statusDetails);

            var updatedStatus = await _statusService.Update(status);

            return Ok(_mapper.Map<StatusDetails>(updatedStatus));
        }



        [HttpGet]
        public async Task<IActionResult> GetStaffStatuses()
        {
            var statuses = await _statusService.GetAllStatuses();

            return Ok(_mapper.Map<IEnumerable<StatusDetails>>(statuses));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffStatus(int id)
        {
            var status = await _statusService.GetStatus(id);

            return status != null ? Ok(_mapper.Map<StatusDetails>(status)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffStatus(int id)
        {
            var status = await _statusService.DeleteStatus(id);

            return status != null ? Ok("Deleted") : NotFound();
        }



    }
}
