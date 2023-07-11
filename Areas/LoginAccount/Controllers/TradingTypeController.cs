using AutoMapper;
using Hope.BackendServices.API.Areas.LoginAccount.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.LoginAccount.Controllers
{
    public class TradingTypeController : ReferenceDataControllerBase<TradingType, TradingTypeDetails>
    {
        public TradingTypeController(IReferenceDataService<TradingType> referenceDataService, IMapper mapper)
            : base(referenceDataService, mapper)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TradingTypeDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TradingTypeDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTradingType(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradingType(int id)
        {
            return await DeleteEntity(id);
        }


    }
}
