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
    public class ProductReferenceImageController : DomainDataControllerBase<ProductReferenceImage, ProductReferenceImageDetails>
    {
        private readonly IProductReferenceImageService _productReferenceImageService;
        public ProductReferenceImageController(IProductReferenceImageService productReferenceImage,  IMapper mapper)
           : base(productReferenceImage, mapper)
        {
            _productReferenceImageService = productReferenceImage;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductReferenceImageDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductReferenceImageDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await GetEntities();
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductReferenceImage(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductReferenceImage(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/productReferenceImage")]
        public async Task<IActionResult> UploadProductReferenceImage(IFormFile uploadFile, int id)
        {
            var productReferenceImage = await _productReferenceImageService.Get(id);
            if (productReferenceImage != null)
            {
                await _productReferenceImageService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/productReferenceImage")]
        public async Task<IActionResult> DownloadProductReferenceImage(int id)
        {
            var productReferenceImage = await _productReferenceImageService.Get(id);
            if (productReferenceImage != null)
            {
                (Stream responseStream, string mimeType) = await _productReferenceImageService.DownloadImage(productReferenceImage.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = productReferenceImage.ImagePath
                };
            }
            else
                return NotFound();
        }


    }
}
