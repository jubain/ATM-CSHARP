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
    public class ProductSymbolController : ReferenceDataControllerBase<ProductSymbol, ProductSymbolDetails>
    {
        private readonly IProductSymbolService _productSymbolService;
        //private readonly IMapper _mapper;

        public ProductSymbolController(IProductSymbolService productSymbolService, IMapper mapper)
           : base(productSymbolService, mapper)
        {
            _productSymbolService = productSymbolService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductSymbolDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductSymbolDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductSymbol(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSymbol(int id)
        {
            return await DeleteEntity(id);
        }
        [HttpPost("{id}/productSymbol")]
        public async Task<IActionResult> UploadProductSymbol(IFormFile uploadFile, int id)
        {
            var productSymbol = await _productSymbolService.Get(id);
            if (productSymbol != null)
            {
                await _productSymbolService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/productSymbol")]
        public async Task<IActionResult> DownloadProductSymbol(int id)
        {
            var productSymbol = await _productSymbolService.Get(id);
            if (productSymbol != null)
            {
                (Stream responseStream, string mimeType) = await _productSymbolService.DownloadImage(productSymbol.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = productSymbol.ImagePath
                };
            }
            else
                return NotFound();
        }

    }
}
