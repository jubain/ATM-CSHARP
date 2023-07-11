using AutoMapper;
using Hope.BackendServices.API.Areas.ConceptArt.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Controllers
{
    [Route("api/ConceptArt/[controller]")]
    [ApiController]
    [Authorize]
    public class ScreenController : ControllerBase
    {
        private readonly IReferenceDataService<Screen> _referenceDataService;
        private readonly IMapper _mapper;

        public ScreenController(IReferenceDataService<Screen> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScreenDetails screenDetails)
        {
            var screen = _mapper.Map<Screen>(screenDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            screen.CreatorId = userId;

            var createdScreen = await _referenceDataService.Create(screen);

            return Ok(_mapper.Map<ScreenDetails>(createdScreen));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ScreenDetails screenDetails)
        {
            var screen = _mapper.Map<Screen>(screenDetails);

            var updatedScreen = await _referenceDataService.Update(screen);

            return Ok(_mapper.Map<ScreenDetails>(updatedScreen));
        }

        [HttpGet]
        public async Task<IActionResult> GetScreens(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var screens = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<ScreenDetails>>(screens));

            }
            else if (statusId != null)
            {

                var screens = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<ScreenDetails>>(screens));

            }
            else
            {
                var screens = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<ScreenDetails>>(screens));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreen(int id)
        {
            var screen = await _referenceDataService.Get(id);

            return screen != null ? Ok(_mapper.Map<ScreenDetails>(screen)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen(int id)
        {
            var screen = await _referenceDataService.Delete(id);

            return screen != null ? Ok("Deleted") : NotFound();
        }
    }
}
