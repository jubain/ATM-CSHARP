using AutoMapper;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.API.Areas.User.Models;
using Hope.BackendServices.ApplicationCore.DTOs;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Enums;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hope.BackendServices.API.Areas.HR.Controllers
{
    [Route("api/hr/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize]
    public class StaffController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService<StaffIdentity> _identityService;
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService, IIdentityService<StaffIdentity> identityService, IMapper mapper)
        {
            _identityService = identityService;
            _staffService = staffService;
            _mapper = mapper;
        }

        // GET: api/staff/<AccountController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staffList = await _staffService.GetAll();
            return Ok(_mapper.Map<IEnumerable<StaffDetails>>(staffList));
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var staff = await _staffService.Get(id);
            return staff != null ? Ok(_mapper.Map<StaffDetails>(staff)) : NotFound();
        }

        // POST api/<AccountController>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] StaffRegistrationDetails staffRegistration)
        {
            // TODO: By this point the entry has already been created in the Staff table, but if the registration below fails,
            // the corresponding entry in StaffUserIdentity doesn't get created, which leaves the DB in an inconsistent state.

            var staffRegistrationDto = _mapper.Map<StaffRegistrationDTO>(staffRegistration);

            var registeredStaff = await _staffService.Create(staffRegistrationDto);
            return registeredStaff != null ? Ok(_mapper.Map<StaffDetails>(registeredStaff)) : NotFound();
        }

        // PUT api/<AccountController>/5
        [HttpPut("Update")]

        public async Task<IActionResult> Put([FromBody] StaffDetails staffUpdate)
        {
            var staff = _mapper.Map<Staff>(staffUpdate);

            var updatedStaff = await _staffService.Update(staff);
            return updatedStaff != null ? Ok(_mapper.Map<StaffDetails>(updatedStaff)) : NotFound();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _staffService.DeleteStaff(id);

            return staff != null ? Ok("Deleted") : NotFound();

        }

        [HttpPost("{id}/Role")]
        public async Task<IActionResult> Post(int id, UserRoleDetails roleToBeAssigned)
        {


            var staff = await _staffService.Get(id);


            var result = await _identityService.AssignRole(staff.Email, roleToBeAssigned.RoleId);

            switch (result)
            {
                case UserRoleResult.Success:
                    return Ok("Role Assigned");
                case UserRoleResult.Fail:
                    return Ok("Role Assignment Failed");
                default:
                    return Ok("Role Creation Problem");
            }

        }

        [HttpPut("{id}/Role")]
        public async Task<IActionResult> Put(int id, [FromBody] UserRoleUpdateDetails userRolesToBeUpdated)
        {
            var staff = await _staffService.Get(id);

            var result = await _identityService.UpdateRoleAssignments(staff.Email, userRolesToBeUpdated.RoleIds);


            switch (result)
            {
                case UserRoleResult.Success:
                    return Ok("Role Assigned");
                case UserRoleResult.Fail:
                    return Ok("Role Assignment Failed");
                default:
                    return Ok("Role Creation Problem");
            }


        }

        [HttpGet("{id}/Role")]
        public async Task<IActionResult> GetAllForUser(int id)
        {
            var staff = await _staffService.Get(id);

            var roles = await _identityService.GetRolesForUser(staff.Email);

            return roles != null ? Ok(_mapper.Map<IEnumerable<RoleDetails>>(roles)) : NotFound();
        }

        [HttpDelete("{id}/Role")]
        public async Task<IActionResult> Delete(int id, [FromBody] UserRoleDetails userRoleDetailsToBeDeleted)
        {
            var staff = await _staffService.Get(id);

            var result = await _identityService.RemoveRoleAssignment(staff.Email, userRoleDetailsToBeDeleted.RoleId);

            switch (result)
            {
                case UserRoleResult.Success:
                    return Ok("Role Assignment Deleted");
                case UserRoleResult.Fail:
                    return Ok("Role Assignment Deletion Failed");
                default:
                    return Ok("Role Assignment Deletion Problem");

            }

        }

        [HttpPost("Role/id/Permission")]
        public async Task<IActionResult> Post([FromQuery] string id, [FromBody] RolePermissionDetails rolePermissionToBeAssigned)
        {
            var result = await _identityService.AddRolePermission(id, rolePermissionToBeAssigned.Permission);

            switch (result)
            {
                case RolePermissionResult.Success:
                    return Ok("Role Permissions Assigned");
                case RolePermissionResult.Fail:
                    return Ok("Role Permissions Assignment Failed");
                default:
                    return Ok("Role Permissions Assignment Problem");
            }

        }

        [HttpPut("Role/{id}/Permission")]
        public async Task<IActionResult> Put(string id, [FromBody] RolePermissionUpdateDetails userRolesToBeUpdated)
        {
            var result = await _identityService.UpdateRolePermissions(id, userRolesToBeUpdated.Permissions);

            switch (result)
            {
                case RolePermissionResult.Success:
                    return Ok("Role Permissions Updated");
                case RolePermissionResult.Fail:
                    return Ok("RolePermissions Update Failed");
                default:
                    return Ok("Role Permissions Update Problem");
            }


        }

        [HttpGet("Role/{id}/Permission")]
        public async Task<IActionResult> GetRolePermissionsForUser(string id)
        {
            var roles = await _identityService.GetRolePermissions(id);
            return roles != null ? Ok(_mapper.Map<IEnumerable<RoleDetails>>(roles)) : NotFound();
        }

        [HttpGet("Role/Permission")]
        public async Task<IActionResult> GetAllPermissions()
        {
            var permissions = await _identityService.GetAllPermissions();
            return permissions != null ? Ok(permissions) : NotFound();
        }

        [HttpDelete("Role/{id}/Permission")]
        public async Task<IActionResult> Delete(string id, [FromBody] RolePermissionDetails rolePermissionsDetailsToBeDeleted)
        {
            var result = await _identityService.RemoveRolePermission(id, rolePermissionsDetailsToBeDeleted.Permission);

            switch (result)
            {
                case RolePermissionResult.Success:
                    return Ok("Role Permission Deleted");
                case RolePermissionResult.Fail:
                    return Ok("Role Permission Deletion Failed");
                default:
                    return Ok("Role Permission Deletion Problem");

            }

        }

    }
}
