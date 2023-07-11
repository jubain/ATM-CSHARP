using Hope.BackendServices.ApplicationCore.Interfaces;
using Hope.BackendServices.ApplicationCore.Services;
using Hope.BackendServices.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.BackendServices.API.Configuration
{
    public static class CoreServicesConfiguration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped(typeof(IUserAccountService), typeof(UserAccountService));
            services.AddScoped(typeof(IStaffService), typeof(StaffService));
            services.AddScoped(typeof(IStaffStatusService), typeof(StaffStatusService));
            //services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));
            //services.AddScoped(typeof(IJobTitleService), typeof(JobTitleService));
            //services.AddScoped(typeof(IHierarchyService), typeof(HierarchyService));
            //services.AddScoped(typeof(ICountryCodeService), typeof(CountryCodeService));
            //services.AddScoped(typeof(ICountryService), typeof(CountryService));
            services.AddScoped(typeof(INextOfKinService), typeof(NextOfKinService));
            services.AddScoped(typeof(IStaffDocumentService), typeof(StaffDocumentService));
            //services.AddScoped(typeof(IDocumentTypeService), typeof(DocumentTypeService));
            //services.AddScoped(typeof(IRoomService), typeof(RoomService));
            //services.AddScoped(typeof(IStaffRoomService), typeof(StaffRoomService));
            services.AddScoped(typeof(IDomainService<>), typeof(DomainService<>));
            services.AddScoped(typeof(IReferenceDataService<>), typeof(ReferenceDataService<>));
            services.AddScoped<IChakraService, ChakraService>();
            services.AddScoped<IIconService, IconService>();
            services.AddScoped<IStorageService, AwsStorageService>();
            services.AddScoped<IWorkSegmentService, WorkSegmentService>();
            services.AddScoped(typeof(IConceptArtSystemImageService), typeof(ConceptArtSystemImageService));
            services.AddScoped(typeof(IArt3DSystemImageService), typeof(Art3DSystemImageService));
            services.AddScoped(typeof(IAnimationReferenceVideoService), typeof(AnimationReferenceVideoService));
            services.AddScoped(typeof(IIdlePoseService), typeof(IdlePoseService));
            services.AddScoped(typeof(IAnimationPlayBlastService), typeof(AnimationPlayBlastService));
            services.AddScoped(typeof(IAnimationExpressionService), typeof(AnimationExpressionService));
            services.AddScoped(typeof(IStatusService), typeof(StatusService));
            services.AddScoped(typeof(ISoundFileService), typeof(SoundFileService));
            services.AddScoped(typeof(ISoundSystemService), typeof(SoundSystemService));
            services.AddScoped(typeof(ISoundSystemPlayblastService), typeof(SoundSystemPlayblastService));
            services.AddScoped(typeof(ISoundTimeIntervalService), typeof(SoundTimeIntervalService));
            services.AddScoped(typeof(IAnimationApprovalSystemService), typeof(AnimationApprovalSystemService));
            services.AddScoped(typeof(IFXFileService), typeof(FXFileService));
            services.AddScoped(typeof(IFXSystemService), typeof(FXSystemService));
            services.AddScoped(typeof(IFXSystemPlayblastService), typeof(FXSystemPlayblastService));
            services.AddScoped(typeof(IFXTimeIntervalService), typeof(FXTimeIntervalService));

            services.AddScoped(typeof(IColourAvailableSystemImageService), typeof(ColourAvailableSystemImageService));
            services.AddScoped(typeof(IBuyerBrandRangeCombinationService), typeof(BuyerBrandRangeCombinationService));
            services.AddScoped(typeof(IBuyerSilhouetteUploadSystemService), typeof(BuyerSilhouetteUploadSystemService));
            services.AddScoped(typeof(IBuyerSilhouetteUploadSystemImageService), typeof(BuyerSilhouetteUploadSystemImageService));
            services.AddScoped(typeof(IRangeService), typeof(RangeService));
            services.AddScoped(typeof(IProductReferenceImageService), typeof(ProductReferenceImageService));
            services.AddScoped(typeof(IProductCreationService), typeof(ProductCreationService));
            services.AddScoped(typeof(IProductSymbolService), typeof(ProductSymbolService));
            services.AddScoped(typeof(IUniqueSellingPointService), typeof(UniqueSellingPointService));
            services.AddScoped(typeof(IWashSymbolService), typeof(WashSymbolService));
            services.AddScoped(typeof(ILogoService), typeof(LogoService));
            services.AddScoped(typeof(ISubjectService), typeof(SubjectService));
            services.AddScoped(typeof(IProductTypeService), typeof(ProductTypeService));

            services.AddScoped(typeof(IAnimationToProductLinkPlayBlastService), typeof(AnimationToProductLinkPlayBlastService));
            services.AddScoped(typeof(IAnimationAmalgamationPlayBlastService), typeof(AnimationAmalgamationPlayBlastService));
            








            
        
        


            return services;
        }
    }
}
