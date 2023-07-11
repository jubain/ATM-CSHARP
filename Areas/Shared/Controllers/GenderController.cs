using AutoMapper;
using Hope.BackendServices.API.Areas.Shared.Models;
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
    public class GenderController : ReferenceDataControllerBase<Gender, GenderDetails>
    {
        public GenderController(IReferenceDataService<Gender> referenceDataService, IMapper mapper)
           : base(referenceDataService, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenderDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GenderDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGender(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            return await DeleteEntity(id);
        }

    }
}
