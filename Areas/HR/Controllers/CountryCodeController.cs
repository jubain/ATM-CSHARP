using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
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
    public class CountryCodeController : ControllerBase
    {
        private readonly IReferenceDataService<CountryCode> _referenceDataService;
        private readonly IMapper _mapper;

        public CountryCodeController(IReferenceDataService<CountryCode> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryCodeDetails countryCodeDetails)
        {
            var countryCode = _mapper.Map<CountryCode>(countryCodeDetails);

            var createdCountryCode = await _referenceDataService.Create(countryCode);

            return Ok(_mapper.Map<CountryCodeDetails>(createdCountryCode));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CountryCodeDetails countryCodeDetails)
        {
            var countryCode = _mapper.Map<CountryCode>(countryCodeDetails);

            var updatedCountryCode = await _referenceDataService.Update(countryCode);

            return Ok(_mapper.Map<CountryCodeDetails>(updatedCountryCode));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCountryCodes()
        {
            var countryCodes = await _referenceDataService.GetAll();

            return Ok(_mapper.Map<IEnumerable<CountryCodeDetails>>(countryCodes)); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryCode(int id)
        {
            var countryCode = await _referenceDataService.Get(id);

            return countryCode != null ? Ok(_mapper.Map<CountryCodeDetails>(countryCode)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryCode(int id)
        {
            var countryCode = await _referenceDataService.Delete(id);

            return countryCode != null ? Ok("Deleted") : NotFound();
        }






    }
}
