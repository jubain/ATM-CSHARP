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
    public class AnimationToProductLinkController : ReferenceDataControllerBase<ApplicationCore.Entities.AnimationToProductLink, AnimationToProductLinkDetails>
    {

        public AnimationToProductLinkController(IReferenceDataService<ApplicationCore.Entities.AnimationToProductLink> referenceDataService, IMapper mapper)
            : base(referenceDataService, mapper)
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimationToProductLinkDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AnimationToProductLinkDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimationToProductLink(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimationToProductLink(int id)
        {
            return await DeleteEntity(id);
        }


    }
}
