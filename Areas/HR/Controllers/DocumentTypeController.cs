using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Controllers
{
    [Route("api/hr/[controller]")]
    [ApiController]
    [Authorize]

    public class DocumentTypeController : ControllerBase
    {
        private readonly IReferenceDataService<DocumentType> _referenceDataService;
        private readonly IMapper _mapper;

        public DocumentTypeController(IReferenceDataService<DocumentType> referenceDataService, IMapper mapper )
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DocumentTypeDetails documentTypeDetails)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            documentType.CreatorId = userId;

            var createdDocumentType = await _referenceDataService.Create(documentType);

            return Ok(_mapper.Map<DocumentTypeDetails>(createdDocumentType));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DocumentTypeDetails documentTypeDetails)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDetails);

            var updatedDocumentType = await _referenceDataService.Update(documentType);

            return Ok(_mapper.Map<DocumentTypeDetails>(updatedDocumentType));
        }

        
        [HttpGet("{documentTypeId}")]
        public async Task<IActionResult> GetDocumentType(int documentTypeId)
        {
            var documentType = await _referenceDataService.Get(documentTypeId);

            return Ok(_mapper.Map<DocumentTypeDetails>(documentType));
        }


        
        [HttpGet]
        public async Task<IActionResult> GetDocumentTypes(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var documentTypes = await _referenceDataService.Find(e => e.Type.Contains(word));
                return Ok(_mapper.Map<IEnumerable<DocumentTypeDetails>>(documentTypes));

            }
            else if (statusId != null)
            {

                var documentTypes = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<DocumentTypeDetails>>(documentTypes));

            }
            else
            {
                var documentTypes = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<DocumentTypeDetails>>(documentTypes));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            var documentType = await _referenceDataService.Delete(id);

            return documentType != null ? Ok("Deleted") : NotFound();
        }

    }
}
