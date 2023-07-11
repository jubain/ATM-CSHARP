using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
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
    public class HRVisaStatusController : ReferenceDataControllerBase<HRVisaStatus, HRVisaStatusDetails>
    {
        public HRVisaStatusController(IReferenceDataService<HRVisaStatus> HRVisaStatusService, IMapper mapper)
            : base(HRVisaStatusService, mapper)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HRVisaStatusDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HRVisaStatusDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHRVisaStatus(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHRVisaStatus(int id)
        {
            return await DeleteEntity(id);
        }

    }


}