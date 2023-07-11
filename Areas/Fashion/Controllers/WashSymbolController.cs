using AutoMapper;
using Hope.BackendServices.API.Areas.Fashion.Models;
using Hope.BackendServices.API.Areas.Shared.Controllers;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.Fashion.Controllers
{
    [Route("api/Fashion/[controller]")]
    [ApiController]
    [Authorize]
    public class WashSymbolController : ReferenceDataControllerBase<WashSymbol, WashSymbolDetails>
    {
        private readonly IWashSymbolService _washSymbolService;
        //private readonly IMapper _mapper;

        public WashSymbolController(IWashSymbolService washSymbolService, IMapper mapper)
           : base(washSymbolService, mapper)
        {
            _washSymbolService = washSymbolService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WashSymbolDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] WashSymbolDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWashSymbol(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWashSymbol(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/washSymbol")]
        public async Task<IActionResult> UploadWashSymbol(IFormFile uploadFile, int id)
        {
            var washSymbol = await _washSymbolService.Get(id);
            if (washSymbol != null)
            {
                await _washSymbolService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/washSymbol")]
        public async Task<IActionResult> DownloadWashSymbol(int id)
        {
            var washSymbol = await _washSymbolService.Get(id);
            if (washSymbol != null)
            {
                (Stream responseStream, string mimeType) = await _washSymbolService.DownloadImage(washSymbol.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = washSymbol.ImagePath
                };
            }
            else
                return NotFound();
        }


    }
}
