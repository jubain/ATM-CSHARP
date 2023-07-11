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
    public class HRHiringSourceController : ReferenceDataControllerBase<HRHiringSource, HRHiringSourceDetails>
    {
        public HRHiringSourceController(IReferenceDataService<HRHiringSource> HRHiringSourceService, IMapper mapper)
            : base(HRHiringSourceService, mapper)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HRHiringSourceDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HRHiringSourceDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHRHiringSource(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHRHiringSource(int id)
        {
            return await DeleteEntity(id);
        }

    }
}
