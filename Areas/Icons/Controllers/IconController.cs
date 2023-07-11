using AutoMapper;
using Hope.BackendServices.API.Areas.Icons.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hope.BackendServices.API.Areas.Icons.Controllers
{
    [Route("api/icons/[controller]")]
    [ApiController]
    [Authorize]
    public class IconController : ControllerBase
    {
        private readonly IIconService _iconService;
        private readonly IMapper _mapper;

        public IconController(IIconService iconService, IMapper mapper)
        {
            _iconService = iconService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IconDetails iconDetails)
        {
            var icon = _mapper.Map<Icon>(iconDetails);
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            icon.CreatorId = userId;
            var createdIcon = await _iconService.Create(icon);

            return Ok(_mapper.Map<IconDetails>(createdIcon));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IconDetails iconDetails)
        {
            var icon = _mapper.Map<Icon>(iconDetails);

            var updatedIcon = await _iconService.Update(icon);

            return Ok(_mapper.Map<IconDetails>(updatedIcon));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var icons = await _iconService.GetAll();

            return Ok(_mapper.Map<IEnumerable<IconDetails>>(icons));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var icon = await _iconService.Get(id);

            return icon != null ? Ok(_mapper.Map<IconDetails>(icon)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var icon = await _iconService.Delete(id);

            return icon != null ? Ok("Inactive") : NotFound();
        }

        [HttpPost("{id}/image")]
        public async Task<IActionResult> UploadDocument(IFormFile uploadFile, int id)
        {
            var icon = await _iconService.Get(id);
            if (icon != null)
            {
                await _iconService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/image")]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var icon = await _iconService.Get(id);
            if (icon != null)
            {
                (Stream responseStream, string mimeType) = await _iconService.DownloadImage(icon.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = icon.ImagePath
                };
            }
            else
                return NotFound();


        }

    }
}
