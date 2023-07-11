using AutoMapper;
using Hope.BackendServices.API.Areas.Fashion.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
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
    public class RangeController : ReferenceDataControllerBase<ApplicationCore.Entities.Range, RangeDetails>
    {
        //private readonly IRangeService _rangeService;
        //private readonly IMapper _mapper;

        public RangeController(IRangeService rangeService, IMapper mapper)
            : base(rangeService, mapper)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RangeDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RangeDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRange(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRange(int id)
        {
            return await DeleteEntity(id);
        }



    }
}
