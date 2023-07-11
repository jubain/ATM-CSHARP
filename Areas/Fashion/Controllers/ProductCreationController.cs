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
    public class ProductCreationController : ReferenceDataControllerBase<ProductCreation, ProductCreationDetails>
    {
        private readonly IProductCreationService _productCreationService;
        public ProductCreationController(IProductCreationService productCreationService, IMapper mapper)
            : base(productCreationService, mapper)
        {
            _productCreationService = productCreationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreationDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductCreationDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            return await GetEntities();
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCreation(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCreation(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/productCreationImage")]
        public async Task<IActionResult> UploadProductCreation(IFormFile uploadFile, int id)
        {
            var productCreation = await _productCreationService.Get(id);
            if (productCreation != null)
            {
                await _productCreationService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/productCreationImage")]
        public async Task<IActionResult> DownloadProductCreation(int id)
        {
            var productCreation = await _productCreationService.Get(id);
            if (productCreation != null)
            {
                (Stream responseStream, string mimeType) = await _productCreationService.DownloadImage(productCreation.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = productCreation.ImagePath
                };
            }
            else
                return NotFound();
        }


    }
}
