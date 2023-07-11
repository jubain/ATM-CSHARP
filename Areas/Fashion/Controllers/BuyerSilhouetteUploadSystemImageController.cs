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
    public class BuyerSilhouetteUploadSystemImageController : ReferenceDataControllerBase<BuyerSilhouetteUploadSystemImage, BuyerSilhouetteUploadSystemImageDetails>
    {
        private readonly IBuyerSilhouetteUploadSystemImageService _buyerSilhouetteUploadSystemImageService;
        public BuyerSilhouetteUploadSystemImageController(IBuyerSilhouetteUploadSystemImageService buyerSilhouetteUploadSystemImageService, IMapper mapper)
            : base(buyerSilhouetteUploadSystemImageService, mapper)
        {
            _buyerSilhouetteUploadSystemImageService = buyerSilhouetteUploadSystemImageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BuyerSilhouetteUploadSystemImageDetails details)
        {
            return await CreateEntity(details);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BuyerSilhouetteUploadSystemImageDetails details)
        {
            return await UpdateEntity(details);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return await GetEntities();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuyerSilhouetteUploadSystemImage(int id)
        {
            return await GetEntity(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyerSilhouetteUploadSystemImage(int id)
        {
            return await DeleteEntity(id);
        }

        [HttpPost("{id}/buyerSilhouetteUploadSystemImage")]
        public async Task<IActionResult> UploadBuyerSilhouetteUploadSystemImage(IFormFile uploadFile, int id)
        {
            var buyerSilhouetteUploadSystemImage = await _buyerSilhouetteUploadSystemImageService.Get(id);
            if (buyerSilhouetteUploadSystemImage != null)
            {
                await _buyerSilhouetteUploadSystemImageService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/buyerSilhouetteUploadSystemImage")]
        public async Task<IActionResult> DownloadBuyerSilhouetteUploadSystemImage(int id)
        {
            var buyerSilhouetteUploadSystemImage = await _buyerSilhouetteUploadSystemImageService.Get(id);
            if (buyerSilhouetteUploadSystemImage != null)
            {
                (Stream responseStream, string mimeType) = await _buyerSilhouetteUploadSystemImageService.DownloadImage(buyerSilhouetteUploadSystemImage.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = buyerSilhouetteUploadSystemImage.ImagePath
                };
            }
            else
                return NotFound();
        }


    }
}
