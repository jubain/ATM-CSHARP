using Hope.BackendServices.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hope.BackendServices.Infrastructure.Identity.ApplicationUser;
using Hope.BackendServices.Infrastructure.Identity.Trader;
using Hope.BackendServices.Infrastructure.Identity.Staff;
using Hope.BackendServices.ApplicationCore.Interfaces;
using Amazon.S3;

namespace Hope.BackendServices.API.Configuration
{
    public static class InfrastructureServicesConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBackendServicesDbContext, BackendServicesDbContext>();

            var appUserIdentityDatabase = configuration.GetConnectionString("AppUserIdentityDatabase");
            var tradeUserIdentityDatabase = configuration.GetConnectionString("TradeUserIdentityDatabase");
            var staffUserIdentityDatabase = configuration.GetConnectionString("StaffUserIdentityDatabase");
            var hopeBackendDatabase = configuration.GetConnectionString("HopeBackendDatabase");

            //services.AddDbContext<BackendServicesDbContext>(options =>
            //    options.UseSqlServer(hopeBackendDatabase));

            //services.AddDbContext<BackendServicesDbContext>(options =>
            //    options.UseSqlServer(hopeBackendDatabase));

            services.AddDbContext<BackendServicesDbContext>(options =>
                options.UseMySQL(hopeBackendDatabase));


            //services.AddDbContext<AppUserIdentityDbContext>(options =>
            //    options.UseSqlServer(appUserIdentityDatabase));

            //services.AddDbContext<TradeUserIdentityDbContext>(options =>
            //    options.UseSqlServer(tradeUserIdentityDatabase));

            //services.AddDbContext<StaffUserIdentityDbContext>(options =>
            //    options.UseSqlServer(staffUserIdentityDatabase));

            services.AddDbContext<StaffUserIdentityDbContext>(options =>
                options.UseMySQL(staffUserIdentityDatabase));

            //services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            //services.AddAWSService<IAmazonS3>();
            // temp fix
            var awsAccessKey = configuration["AWSAccessKey"];
            var awsAccessSecret = configuration["AwsAccessSecret"];
            services.AddScoped<IAmazonS3>(_ => new AmazonS3Client(awsAccessKey, awsAccessSecret, Amazon.RegionEndpoint.EUWest2));

            return services;
        }
    }
}
