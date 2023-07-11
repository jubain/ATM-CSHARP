using AutoMapper;
using Hope.BackendServices.API.Areas.Icons.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hope.BackendServices.API.Areas.Icons.Controllers
{
    [Route("api/icons/[controller]")]
    [ApiController]
    [Authorize]
    public class ColourController : ControllerBase
    {
        private readonly IReferenceDataService<Colour> _referenceDataService;
        private readonly IMapper _mapper;

        public ColourController(IReferenceDataService<Colour> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ColourDetails colourDetails)
        {
            var colour = _mapper.Map<Colour>(colourDetails);
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            colour.CreatorId = userId;
            var createdColour = await _referenceDataService.Create(colour);

            return Ok(_mapper.Map<ColourDetails>(createdColour));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ColourDetails colourDetails)
        {
            var colour = _mapper.Map<Colour>(colourDetails);

            var updatedColour = await _referenceDataService.Update(colour);

            return Ok(_mapper.Map<ColourDetails>(updatedColour));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colours = await _referenceDataService.GetAll();

            return Ok(_mapper.Map<IEnumerable<ColourDetails>>(colours));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var colour = await _referenceDataService.Get(id);

            return colour != null ? Ok(_mapper.Map<ColourDetails>(colour)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var colour = await _referenceDataService.Delete(id);

            return colour != null ? Ok("Inactive") : NotFound();
        }
    }
}
