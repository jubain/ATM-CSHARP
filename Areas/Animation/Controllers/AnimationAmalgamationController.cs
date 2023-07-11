using AutoMapper;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Animation.Controllers
{
    public class AnimationAmalgamationController : ReferenceDataControllerBase<ApplicationCore.Entities.AnimationAmalgamation, AnimationAmalgamationDetails>
    {
        public AnimationAmalgamationController(IReferenceDataService<ApplicationCore.Entities.AnimationAmalgamation> referenceDataService, IMapper mapper)
            : base(referenceDataService, mapper)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationAmalgamationDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationAmalgamationDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimationAmalgamation(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimationAmalgamation(int id)
        {
            return await DeleteEntity(id);
        }


    }
}
