using Hope.BackendServices.API.ApiModel;
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

namespace Hope.BackendServices.API.Areas.Identity.Controllers
{
    [AllowAnonymous]
    [Route("api/user/[controller]")]
    [ApiController]
    internal class AuthenticateController : ControllerBase
    {
        IUserAccountService _userAccountService;
        ITokenClaimsService<UserIdentity> _tokenClaimsService;

        public AuthenticateController(IUserAccountService userAccountService, ITokenClaimsService<UserIdentity> tokenClaimsService)
        {
            _userAccountService = userAccountService;
            _tokenClaimsService = tokenClaimsService;
        }

        // GET: api/<AuthenticateController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<AuthenticateController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDetails loginDetails)
        {
            var result = await _userAccountService.Authenticate(loginDetails.Username, loginDetails.Password);
            switch (result)
            {
                case AuthenticationResult.Success:
                    var token = await _tokenClaimsService.GetTokenAsync(loginDetails.Username);
                    return Ok(new { Token = token });
                case AuthenticationResult.Fail:
                    return Forbid();
                case AuthenticationResult.AccountLocked:
                    return Forbid();
                case AuthenticationResult.AccountDisabled:
                    return Forbid();
                default:
                    return Forbid();
            }
        }
    }
}
