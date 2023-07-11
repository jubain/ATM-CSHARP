using AutoMapper;
using Hope.BackendServices.API.Areas.User.Models;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Enums;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Hope.BackendServices.Infrastructure.Identity.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.User.Controllers
{
    [Authorize]
    [Route("api/user/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IIdentityService<StaffIdentity> _identityService;
        private readonly IMapper _mapper;

        public RoleController(IIdentityService<StaffIdentity> identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleRegistrationDetails roleToBeCreated)
        {
            var result = await _identityService.CreateRole(_mapper.Map<Role>(roleToBeCreated));

            switch (result)
            {
                case RoleResult.Success:
                    return Ok("Role Created");
                case RoleResult.Fail:
                    return Ok("Role Creation Failed");
                default:
                    return Ok("Role Creation Problem");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoleDetails roleToBeUpdated)
        {
            var result = await _identityService.UpdateRole(_mapper.Map<Role>(roleToBeUpdated));

            switch (result)
            {
                case RoleResult.Success:
                    return Ok("Role Updated");
                case RoleResult.Fail:
                    return Ok("Role Update Failed");
                default:
                    return Ok("Role Update Problem");                

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _identityService.GetAllRoles();
            return roles != null ? Ok(_mapper.Map<IEnumerable<Role>>(roles)) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var role = await _identityService.GetRole(id);
            return role != null ? Ok(_mapper.Map<RoleDetails>(role)) : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RoleDetails roleToBeDeleted)
        {
            var result = await _identityService.DeleteRole(_mapper.Map<Role>(roleToBeDeleted));

            switch (result)
            {
                case RoleResult.Success:
                    return Ok("Role Deleted");
                case RoleResult.Fail:
                    return Ok("Role Deletion Failed");
                default:
                    return Ok("Role Deletion Problem");

            }

        }


    }
}
