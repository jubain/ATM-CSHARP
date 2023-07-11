﻿using AutoMapper;
using Hope.BackendServices.API.Areas.Fashion.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Controllers
{
    [Route("api/Fashion/[controller]")]
    [ApiController]
    [Authorize]
    public class ColourAvailableSystemController : ReferenceDataControllerBase<ColourAvailableSystem, ColourAvailableSystemDetails>
    {
        //private readonly IReferenceDataService<ColourAvailableSystem> _colourAvailableSystemService;
        //private readonly IMapper _mapper;

        public ColourAvailableSystemController(IReferenceDataService<ColourAvailableSystem> colourAvailableSystemService, IMapper mapper)
        : base(colourAvailableSystemService, mapper)
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ColourAvailableSystemDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ColourAvailableSystemDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColourAvailableSystem(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColourAvailableSystem(int id)
        {
            return await DeleteEntity(id);
        }


        
       

       
       

       


    }
}
