using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Controllers
{
    [Route("api/hr/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly IReferenceDataService<Country> _referenceDataService;
        private readonly IMapper _mapper;

        public CountryController(IReferenceDataService<Country> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryDetails countryDetails)
        {
            var country = _mapper.Map<Country>(countryDetails);
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            country.CreatorId = userId;

            var createdCountry = await _referenceDataService.Create(country);

            return Ok(_mapper.Map<CountryDetails>(createdCountry));

        }


        [HttpPut]

        public async Task<IActionResult> Put([FromBody] CountryDetails countryDetails)
        {
            var country = _mapper.Map<Country>(countryDetails);

            var updatedCountry = await _referenceDataService.Update(country);

            return Ok(_mapper.Map<CountryDetails>(updatedCountry));
        }


        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await _referenceDataService.Get(id);

            return country != null ? Ok(_mapper.Map<CountryDetails>(country)) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var countries = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<CountryDetails>>(countries));

            }
            else if (statusId != null){

                var countries = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<CountryDetails>>(countries));

            }
            else
            {
                var countries = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<CountryDetails>>(countries));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _referenceDataService.Delete(id);

            return country != null ? Ok("Deleted") : NotFound();
        }





    }
}
