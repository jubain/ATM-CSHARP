using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Hope.BackendServices.ApplicationCore.Services;
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
    public class DepartmentController : ControllerBase
    {
        private readonly IReferenceDataService<Department> _referenceDataService;
        private readonly IMapper _mapper;

        public DepartmentController(IReferenceDataService<Department> referenceDataService, IMapper mapper)
        {
            _referenceDataService = referenceDataService;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentDetails departmentDetails)
        {
            var department = _mapper.Map<Department>(departmentDetails);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            department.CreatorId = userId;

            var createdDepartment = await _referenceDataService.Create(department);

            return Ok(_mapper.Map<DepartmentDetails>(createdDepartment));

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DepartmentDetails departmentDetails)
        {
            var department = _mapper.Map<Department>(departmentDetails);

            var updatedDepartment = await _referenceDataService.Update(department);

            return Ok(_mapper.Map<DepartmentDetails>(updatedDepartment));
        }




       

        [HttpGet]
        public async Task<IActionResult> GetDepartments(string word, int? statusId)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {

                var departments = await _referenceDataService.Find(e => e.Name.Contains(word));
                return Ok(_mapper.Map<IEnumerable<DepartmentDetails>>(departments));

            }
            else if (statusId != null)
            {

                var departments = await _referenceDataService.Find(e => e.StatusId.Equals(statusId));
                return Ok(_mapper.Map<IEnumerable<DepartmentDetails>>(departments));

            }
            else
            {
                var departments = await _referenceDataService.GetAll();
                return Ok(_mapper.Map<IEnumerable<DepartmentDetails>>(departments));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _referenceDataService.Get(id);

            return department != null ? Ok(_mapper.Map<DepartmentDetails>(department)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _referenceDataService.Delete(id);

            return department != null ? Ok("Deleted") : NotFound();
        }


    }
}
