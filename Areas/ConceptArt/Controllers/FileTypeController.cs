using AutoMapper;
using Hope.BackendServices.API.Areas.ConceptArt.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.ConceptArt.Controllers
{
    [Route("api/ConceptArt/[controller]")]
    [ApiController]
    [Authorize]
    public class FileTypeController : ControllerBase
    {
        private readonly IReferenceDataService<FileType> _referenceDataService;
        private readonly IMapper _mapper;

        public FileTypeController(IReferenceDataService<FileType> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FileTypeDetails fileTypeDetails)
        {
            var fileType = _mapper.Map<FileType>(fileTypeDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            fileType.CreatorId = userId;

            var createdFileType = await _referenceDataService.Create(fileType);

            return Ok(_mapper.Map<FileTypeDetails>(createdFileType));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FileTypeDetails fileTypeDetails)
        {
            var fileType = _mapper.Map<FileType>(fileTypeDetails);

            var updatedFileType = await _referenceDataService.Update(fileType);

            return Ok(_mapper.Map<FileTypeDetails>(updatedFileType));
        }

        [HttpGet]
        public async Task<IActionResult> GetFileTypes(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var fileTypes = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<FileTypeDetails>>(fileTypes));

            }
            else if (statusId != null)
            {

                var fileTypes = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<FileTypeDetails>>(fileTypes));

            }
            else
            {
                var fileTypes = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<FileTypeDetails>>(fileTypes));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileType(int id)
        {
            var fileType = await _referenceDataService.Get(id);

            return fileType != null ? Ok(_mapper.Map<FileTypeDetails>(fileType)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileType(int id)
        {
            var fileType = await _referenceDataService.Delete(id);

            return fileType != null ? Ok("Deleted") : NotFound();
        }



    }
}
