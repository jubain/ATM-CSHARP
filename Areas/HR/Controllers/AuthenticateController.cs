using Hope.BackendServices.API.ApiModel;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Enums;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Areas.HR.Controllers
{
    /// <summary>
    /// Provides authentication services for HR system
    /// </summary>
    [Route("api/hr/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticateController : ControllerBase
    {
        IStaffService _staffService;
        ITokenClaimsService<StaffIdentity> _tokenClaimsService;

        public AuthenticateController(IStaffService staffService, ITokenClaimsService<StaffIdentity> tokenClaimsService)
        {
            _staffService = staffService;
            _tokenClaimsService = tokenClaimsService;
        }

        /// <summary>
        /// Authenticate using username and password
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        // POST api/staff/<AuthenticateController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDetails loginDetails)
        {
            var result = await _staffService.Authenticate(loginDetails.Username, loginDetails.Password);
            switch (result)
            {
                case AuthenticationResult.Success:
                    var token = await _tokenClaimsService.GetTokenAsync(loginDetails.Username);
                    return Ok(new { Token = token });

                case AuthenticationResult.Fail:
                    return Unauthorized();
                case AuthenticationResult.AccountLocked:
                    return Unauthorized();
                case AuthenticationResult.AccountDisabled:
                    return Unauthorized();
                default:
                    return Unauthorized();
            }
        }
    }
}
