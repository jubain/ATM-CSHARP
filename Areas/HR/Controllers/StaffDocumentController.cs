using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
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

namespace Hope.BackendServices.API.Areas.HR.Controllers
{


    [Route("api/hr/[controller]")]
    [ApiController]
    [Authorize]
    public class StaffDocumentController : ControllerBase
    {
        private readonly IStaffDocumentService _staffDocumentService;
        private readonly IMapper _mapper;

        public StaffDocumentController(IStaffDocumentService staffDocumentService, IMapper mapper)
        {
            _staffDocumentService = staffDocumentService;           
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StaffDocumentDetails staffDocumentDetails)
        {
            var staffDocument = _mapper.Map<StaffDocument>(staffDocumentDetails);

            var createdStaffDocument = await _staffDocumentService.AddDocument(staffDocument);           

            return Ok(_mapper.Map<StaffDocumentDetails>(createdStaffDocument));
        }

        [HttpGet()]
        public async Task<IActionResult> GetStaffDocuments( [FromQuery]int? staffId )
        {
            if (staffId != null)
            {
                var staffDocuments = await _staffDocumentService.GetStaffDocuments(staffId.Value);

                return Ok(_mapper.Map<IEnumerable<StaffDocumentDetails>>(staffDocuments));
            }

            return BadRequest();
            
        }

        [HttpGet("{staffDocumentId}")]
        public async Task<IActionResult> GetStaffDocument(int staffDocumentId)
        {
            var staffDocument = await _staffDocumentService.GetStaffDocument(staffDocumentId);

            return Ok(_mapper.Map<StaffDocumentDetails>(staffDocument));
        }



        [HttpPost("{id}/document")]
        public async Task<IActionResult> UploadDocument(IFormFile uploadFile, int id)
        {
            
            var staffDocument = await _staffDocumentService.GetStaffDocument(id);
            if (staffDocument != null)
            {
                await _staffDocumentService.UploadDocument(id, uploadFile.FileName, uploadFile.ContentType, uploadFile.OpenReadStream()); ;
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("{id}/document")]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var staffDocument = await _staffDocumentService.GetStaffDocument(id);
            if (staffDocument != null)
            {
                (Stream responseStream, string mimeType) = await _staffDocumentService.DownloadDocument(staffDocument.ImagePath);
                return new FileStreamResult(responseStream, mimeType)
                {
                    FileDownloadName = staffDocument.ImagePath
                };
            }
            else
                return NotFound();


        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StaffDocumentDetails staffDocumentDetails)
        {
            var staffDocument = _mapper.Map<StaffDocument>(staffDocumentDetails);

            var updatedStaffDocument = await _staffDocumentService.Update(staffDocument);

            return Ok(_mapper.Map<StaffDocumentDetails>(updatedStaffDocument));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffDocument(int id)
        {
            var staffDocument = await _staffDocumentService.DeleteStaffDocument(id);

            return staffDocument != null ? Ok("Deleted") : NotFound();
        }


    }
        
 }
