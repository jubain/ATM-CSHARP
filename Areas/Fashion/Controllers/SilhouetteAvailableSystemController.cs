using AutoMapper;
using Hope.BackendServices.API.Areas.Fashion.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Helpers;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Controllers
{
    [Route("api/Fashion/[controller]")]
    [ApiController]
    [Authorize]
    public class SilhouetteAvailableSystemController : ReferenceDataControllerBase<SilhouetteAvailableSystem, SilhouetteAvailableSystemDetails>
    {
        public SilhouetteAvailableSystemController(IReferenceDataService<SilhouetteAvailableSystem> referenceDataService, IMapper mapper)
            : base(referenceDataService, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SilhouetteAvailableSystemDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SilhouetteAvailableSystemDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

       


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSilhouetteAvailableSystem(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSilhouetteAvailableSystem(int id)
        {
            return await DeleteEntity(id);
        }

    }
}
