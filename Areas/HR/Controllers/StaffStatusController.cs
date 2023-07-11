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
    public class StaffStatusController : ControllerBase
    {
        private readonly IStaffStatusService _staffStatusService;
        private readonly IMapper _mapper;

        public StaffStatusController(IStaffStatusService staffStatusService, IMapper mapper)
        {
            _staffStatusService = staffStatusService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StaffStatusDetails staffStatusDetails)
        {
            var staffStatus = _mapper.Map<StaffStatus>(staffStatusDetails);

            var createdStaffStatus = await _staffStatusService.Create(staffStatus);

            return Ok(_mapper.Map<StaffStatusDetails>(createdStaffStatus));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StaffStatusDetails staffStatusDetails)
        {
            var staffStatus = _mapper.Map<StaffStatus>(staffStatusDetails);

            var updatedStaffStatus = await _staffStatusService.Update(staffStatus);

            return Ok(_mapper.Map<StaffStatusDetails>(updatedStaffStatus));
        }

            

        [HttpGet]
        public async Task<IActionResult> GetStaffStatuses()
        {
            var statuses = await _staffStatusService.GetAllStaffStatuses();

            return Ok(_mapper.Map<IEnumerable<StaffStatusDetails>>(statuses));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffStatus(int id)
        {
            var status = await _staffStatusService.GetStaffStatus(id);

            return status != null ? Ok(_mapper.Map<StaffStatusDetails>(status)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffStatus(int id)
        {
            var staffStatus = await _staffStatusService.DeleteStaffStatus(id);

            return staffStatus != null ? Ok("Deleted") : NotFound();
        }



    }
}
