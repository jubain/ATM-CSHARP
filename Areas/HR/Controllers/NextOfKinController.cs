using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.ApplicationCore.DTOs;
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

    public class NextOfKinController : ControllerBase
    {
        
        private readonly INextOfKinService _nextOfKinService;
        private readonly IMapper _mapper;

        public NextOfKinController(INextOfKinService nextOfKinService, IMapper mapper)
        {
            _nextOfKinService = nextOfKinService;
            
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNextOfKins()
        {
            var nextOfKins = await _nextOfKinService.GetAllNextOfKins();

            return Ok(_mapper.Map<IEnumerable<NextOfKinDetails>>(nextOfKins));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNextOfKin(int id)
        {
            var nextOfKin = await _nextOfKinService.GetNextOfKin(id);

            return nextOfKin != null ? Ok(_mapper.Map<NextOfKinDetails>(nextOfKin)) : NotFound();
        }


        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] NextOfKinDetails nextOfKin)
        {
            var nextOfKinRegistration = _mapper.Map<NextOfKin>(nextOfKin);

            var registeredNextOfKin = await _nextOfKinService.Create(nextOfKinRegistration);
            return Ok(registeredNextOfKin);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] NextOfKinDetails nextOfKinDetails)
        {
            var nextOfKin = _mapper.Map<NextOfKin>(nextOfKinDetails);

            var updatedNextOfKin = await _nextOfKinService.Update(nextOfKin);

            return Ok(_mapper.Map<NextOfKinDetails>(updatedNextOfKin));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNextOfKin(int id)
        {
            var nextOfKin = await _nextOfKinService.DeleteNextOfKin(id);

            return nextOfKin != null ? Ok("Deleted") : NotFound();
        }

    }
}
