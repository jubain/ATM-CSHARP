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
    public class ChakraController : ControllerBase
    {
        private readonly IChakraService _chakraService;
        private readonly IMapper _mapper;

        public ChakraController(IChakraService chakraService, IMapper mapper)
        {
            _chakraService = chakraService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChakraDetails chakraDetails)
        {
            var chakra = _mapper.Map<Chakra>(chakraDetails);
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            chakra.CreatorId = userId;
            var createdChakra = await _chakraService.Create(chakra);
            
            return Ok(_mapper.Map<ChakraDetails>(createdChakra));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ChakraDetails chakraDetails)
        {
            var chakra = _mapper.Map<Chakra>(chakraDetails);

            var updatedChakra = await _chakraService.Update(chakra);

            return Ok(_mapper.Map<ChakraDetails>(updatedChakra));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chakras = await _chakraService.GetAll();

            return Ok(_mapper.Map<IEnumerable<ChakraDetails>>(chakras));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var chakra = await _chakraService.Get(id);

            return chakra != null ? Ok(_mapper.Map<ChakraDetails>(chakra)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var chakra = await _chakraService.Delete(id);

            return chakra != null ? Ok("Inactive") : NotFound();
        }

        [HttpPost("{id}/image")]
        public async Task<IActionResult> UploadDocument(IFormFile uploadFile, int id)
        {
            var chakra = await _chakraService.Get(id);
            if (chakra != null)
            {
                await _chakraService.UploadImage(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/image")]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var chakra = await _chakraService.Get(id);
            if (chakra != null)
            {
                (Stream responseStream, string mimeType) = await _chakraService.DownloadImage(chakra.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = chakra.ImagePath
                };
            }
            else
                return NotFound();
            
           
        }

    }
}
