using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Auth.Permissions
{
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IIdentityService<StaffIdentity> _identityService;

        public PermissionAuthorizationHandler(IIdentityService<StaffIdentity> identityService) =>
            _identityService = identityService;

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userName = context.User?.GetUserName();
            if (!string.IsNullOrEmpty(userName))
            {
                await _identityService.HasPermission(userName, requirement.Permission);


                context.Succeed(requirement);

            }


            if (context.User?.GetUserName() is { } userId &&
            await _identityService.HasPermission(userId, requirement.Permission))
            {
                context.Succeed(requirement);
            }

        }
    }
}
