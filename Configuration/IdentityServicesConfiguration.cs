using Hope.BackendServices.API.Auth.Permissions;
using Hope.BackendServices.ApplicationCore.Entities;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Hope.BackendServices.Infrastructure.Identity;
using Hope.BackendServices.Infrastructure.Identity.ApplicationUser;
using Hope.BackendServices.Infrastructure.Identity.Staff;
using Hope.BackendServices.Infrastructure.Identity.Trader;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Configuration
{
    public static class IdentityServicesConfiguration
    {
        public static IServiceCollection AddAppIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IIdentityService<UserIdentity>, AspNetAppIdentityService<ApplicationUser, UserIdentity>>();
            //services.AddScoped<IIdentityService<TraderIdentity>, AspNetAppIdentityService<TradeUser, TraderIdentity>>();
            services.AddScoped<IIdentityService<StaffIdentity>, AspNetAppIdentityService<StaffUser, StaffRole, StaffIdentity>>();

            //services.AddScoped<ITokenClaimsService<UserIdentity>, IdentityTokenClaimService<ApplicationUser, UserIdentity>>();
            //services.AddScoped<ITokenClaimsService<TraderIdentity>, IdentityTokenClaimService<TradeUser, TraderIdentity>>();
            services.AddScoped<ITokenClaimsService<StaffIdentity>, IdentityTokenClaimService<StaffUser, StaffIdentity>>();

            //For Identity
            //services.AddIdentityCore<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddUserManager<UserManager<ApplicationUser>>()
            //    .AddSignInManager<SignInManager<ApplicationUser>>()
            //    .AddEntityFrameworkStores<AppUserIdentityDbContext>()
            //    .AddDefaultTokenProviders();

            //services.AddIdentityCore<TradeUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddUserManager<UserManager<TradeUser>>()
            //    .AddSignInManager< SignInManager<TradeUser>>()
            //    .AddEntityFrameworkStores<TradeUserIdentityDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddIdentityCore<StaffUser>()
                .AddRoles<StaffRole>()
                .AddUserManager<UserManager<StaffUser>>()
                .AddSignInManager<SignInManager<StaffUser>>()
                .AddRoleManager<RoleManager<StaffRole>>()
                .AddEntityFrameworkStores<StaffUserIdentityDbContext>()
                .AddDefaultTokenProviders();

            
            //JWT Authentication
             var key = Encoding.ASCII.GetBytes(configuration.GetConnectionString("JwtSecretKey"));
            //var key = Encoding.ASCII.GetBytes("SecretKey");
            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = true;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                jwt.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        //Log failed authentications
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        //Log successful authentications
                        return Task.CompletedTask;
                    }
                };

            });

            services
                .AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
                .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            return services;
        }

    }
}
