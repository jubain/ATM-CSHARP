﻿using AutoMapper;
using Hope.BackendServices.API.Areas.Art3D.Models;
using Hope.BackendServices.API.Areas.Animation.Models;
using Hope.BackendServices.API.Areas.ConceptArt.Models;
using Hope.BackendServices.API.Areas.HR.Models;
using Hope.BackendServices.API.Areas.Icons.Models;
using Hope.BackendServices.API.Areas.Shared.Models;
using Hope.BackendServices.API.Areas.Sound.Models;
using Hope.BackendServices.API.Areas.User.Models;
using Hope.BackendServices.API.SharedApiModel;
using Hope.BackendServices.ApplicationCore.DTOs;
using Hope.BackendServices.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hope.BackendServices.API.Areas.FX.Models;
using Hope.BackendServices.API.Areas.Fashion.Models;
using Hope.BackendServices.API.Areas.LoginAccount.Models;

namespace Hope.BackendServices.API.Configuration.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationDetails, UserRegistrationDTO>();
            CreateMap<StaffRegistrationDetails, StaffRegistrationDTO>();
            CreateMap<Staff, StaffDetails>();
            CreateMap<StaffDetails, Staff>(); 
            CreateMap<Department, DepartmentDetails>();
            CreateMap<DepartmentDetails, Department>();
            CreateMap<JobTitle, JobTitleDetails>();
            CreateMap<JobTitleDetails, JobTitle>();
            CreateMap<Hierarchy, HierarchyDetails>();
            CreateMap<HierarchyDetails, Hierarchy>();
            CreateMap<CountryCode, CountryCodeDetails>();
            CreateMap<CountryCodeDetails, CountryCode>();
            CreateMap<Country, CountryDetails>();
            CreateMap<CountryDetails, Country>();
            CreateMap<NextOfKin, NextOfKinDetails>();
            CreateMap<NextOfKinDetails, NextOfKin>();
            CreateMap<NextOfKinDetails, NextOfKinDetails>();
            CreateMap<NextOfKinDetails, NextOfKin>();
            CreateMap<StaffDocumentDetails, StaffDocument>();
            CreateMap<StaffDocument, StaffDocumentDetails>();
            CreateMap<DocumentType, DocumentTypeDetails>();
            CreateMap<DocumentTypeDetails, DocumentType>();
            CreateMap<Room, RoomDetails>();
            CreateMap<RoomDetails, Room>();
            CreateMap<ColourDetails, Colour>();
            CreateMap<Colour, ColourDetails>();
            CreateMap<ChakraDetails, Chakra>();
            CreateMap<Chakra, ChakraDetails>();
            CreateMap<IconDetails, Icon>();
            CreateMap<Icon, IconDetails>();
            CreateMap<StatusDetails, ReferenceDataStatus>()
                .ForMember(d => d.ReferenceDataStatusId, opt => opt.MapFrom(s => s.StatusId));
            CreateMap<ReferenceDataStatus, StatusDetails>()
                .ForMember(d => d.StatusId, opt => opt.MapFrom(s => s.ReferenceDataStatusId));
            CreateMap<Staff, CreatorDetails>();
            CreateMap<CreatorDetails, Staff>();
            CreateMap<StaffStatus, StaffStatusDetails>();
            CreateMap<StaffStatusDetails, StaffStatus>();
            CreateMap<ArtAsset, ArtAssetDetails>();
            CreateMap<ArtAssetDetails, ArtAsset>();
            CreateMap<CharacterName, CharacterNameDetails>();
            CreateMap<CharacterNameDetails, CharacterName>();
            CreateMap<FileType, FileTypeDetails>();
            CreateMap<FileTypeDetails, FileType>();
            CreateMap<Screen, ScreenDetails>();
            CreateMap<ScreenDetails, Screen>();
            CreateMap<TextureType, TextureTypeDetails>();
            CreateMap<TextureTypeDetails, TextureType>();
            CreateMap<WorkDivision, WorkDivisionDetails>();
            CreateMap<WorkDivisionDetails, WorkDivision>();
            CreateMap<WorkSegment, WorkSegmentDetails>();
            CreateMap<WorkSegmentDetails, WorkSegment>();
            CreateMap<Importance, ImportanceDetails>();
            CreateMap<ImportanceDetails, Importance>();
            CreateMap<ConceptArtSystem, ConceptArtSystemDetails>();
            CreateMap<ConceptArtSystemDetails, ConceptArtSystem>();
            CreateMap<ConceptArtSystemImage, ConceptArtSystemImageDetails>();
            CreateMap<ConceptArtSystemImageDetails, ConceptArtSystemImage>();
            CreateMap<Art3DSystemImage, Art3DSystemImageDetails>();
            CreateMap<Art3DSystemImageDetails, Art3DSystemImage>();
            CreateMap<Animation, AnimationDetails>();
            CreateMap<AnimationDetails, Animation>();
            CreateMap<AnimationReferenceVideo, AnimationReferenceVideoDetails>();
            CreateMap<AnimationReferenceVideoDetails, AnimationReferenceVideo>();
            CreateMap<IdlePose, IdlePoseDetails>();
            CreateMap<IdlePoseDetails, IdlePose>();
            CreateMap<AnimationPlayBlast, AnimationPlayBlastDetails>();
            CreateMap<AnimationPlayBlastDetails, AnimationPlayBlast>(); 
            CreateMap<CharacterTexture, CharacterTextureDetails>();
            CreateMap<CharacterTextureDetails, CharacterTexture>();
            CreateMap<AnimationExpression, AnimationExpressionDetails>();
            CreateMap<AnimationExpressionDetails, AnimationExpression>();
            CreateMap<BodyPart, BodyPartDetails>();
            CreateMap<BodyPartDetails, BodyPart>();
            CreateMap<SoundSystem, SoundSystemDetails>();
            CreateMap<SoundSystemDetails, SoundSystem>();
            CreateMap<SoundFile, SoundFileDetails>();
            CreateMap<SoundFileDetails, SoundFile>();
            CreateMap<SoundSystemPlayblast, SoundSystemPlayblastDetails>();
            CreateMap<SoundSystemPlayblastDetails, SoundSystemPlayblast>();
            CreateMap<SoundTimeInterval, SoundTimeIntervalDetails>();
            CreateMap<SoundTimeIntervalDetails, SoundTimeInterval>();
            CreateMap<FXSystem, FXSystemDetails>();
            CreateMap<FXSystemDetails, FXSystem>();
            CreateMap<FXFile, FXFileDetails>();
            CreateMap<FXFileDetails, FXFile>();
            CreateMap<FXSystemPlayblast, FXSystemPlayblastDetails>();
            CreateMap<FXSystemPlayblastDetails, FXSystemPlayblast>();
            CreateMap<FXTimeInterval, FXTimeIntervalDetails>();
            CreateMap<FXTimeIntervalDetails, FXTimeInterval>();
            CreateMap<AnimationApprovalSystem, AnimationApprovalSystemDetails>();
            CreateMap<AnimationApprovalSystemDetails, AnimationApprovalSystem>();

            CreateMap<ColourAvailableSystem, ColourAvailableSystemDetails>();
            CreateMap< ColourAvailableSystemDetails, ColourAvailableSystem> ();
            CreateMap<ColourAvailableSystemImage, ColourAvailableSystemImageDetails>();
            CreateMap<ColourAvailableSystemImageDetails, ColourAvailableSystemImage >();
            CreateMap<SilhouetteAvailableSystem, SilhouetteAvailableSystemDetails>();
            CreateMap<SilhouetteAvailableSystemDetails, SilhouetteAvailableSystem >();
            CreateMap<BuyerBrandRangeCombination, BuyerBrandRangeCombinationDetails>();
            CreateMap<BuyerBrandRangeCombinationDetails, BuyerBrandRangeCombination>();
            CreateMap<BuyerSilhouetteUploadSystem, BuyerSilhouetteUploadSystemDetails>();
            CreateMap<BuyerSilhouetteUploadSystemDetails, BuyerSilhouetteUploadSystem>();
            CreateMap<BuyerSilhouetteUploadSystemImage, BuyerSilhouetteUploadSystemImageDetails>();
            CreateMap<BuyerSilhouetteUploadSystemImageDetails, BuyerSilhouetteUploadSystemImage>();
            CreateMap<Brand, BrandDetails>();
            CreateMap<BrandDetails, Brand >();
            CreateMap<ApplicationCore.Entities.Range, RangeDetails>();
            CreateMap<RangeDetails, ApplicationCore.Entities.Range >();
            CreateMap<ProductDesign, ProductDesignDetails>();
            CreateMap<ProductDesignDetails, ProductDesign>();
            CreateMap<ProductGroup, ProductGroupDetails>();
            CreateMap<ProductGroupDetails, ProductGroup>();
            CreateMap<ProductType, ProductTypeDetails>();
            CreateMap<ProductTypeDetails, ProductType>();
            CreateMap<Gender, GenderDetails>();
            CreateMap<GenderDetails, Gender >();
            CreateMap<ProductSize, ProductSizeDetails>();
            CreateMap<ProductSizeDetails, ProductSize>();
            CreateMap<ProductReferenceImage, ProductReferenceImageDetails>();
            CreateMap<ProductReferenceImageDetails, ProductReferenceImage>();
            CreateMap<ProductCreation, ProductCreationDetails>();
            CreateMap<ProductCreationDetails, ProductCreation >();
            CreateMap<ProductSymbol, ProductSymbolDetails>();
            CreateMap<ProductSymbolDetails, ProductSymbol >();
            CreateMap<UniqueSellingPoint, UniqueSellingPointDetails>();
            CreateMap<UniqueSellingPointDetails, UniqueSellingPoint>();
            CreateMap<WashSymbol, WashSymbolDetails>();
            CreateMap<WashSymbolDetails, WashSymbol>();
            CreateMap<Logo, LogoDetails>();
            CreateMap<LogoDetails, Logo >();
            CreateMap<Subject, SubjectDetails>();
            CreateMap<SubjectDetails, Subject>();
            CreateMap<UseOfImage, UseOfImageDetails>();
            CreateMap<UseOfImageDetails, UseOfImage >();
            CreateMap<HREmploymentType, HREmploymentTypeDetails>();
            CreateMap<HREmploymentTypeDetails, HREmploymentType>();
            CreateMap<HREntity, HREntityDetails>();
            CreateMap<HREntityDetails, HREntity>();
            CreateMap<HREntity, HREntityDetails>();
            CreateMap<HREntityDetails, HREntity>();
            CreateMap<HRHiringSource, HRHiringSourceDetails>();
            CreateMap<HRHiringSourceDetails, HRHiringSource>();
            CreateMap<HRVisaStatus, HRVisaStatusDetails>();
            CreateMap<HRVisaStatusDetails, HRVisaStatus>();

            CreateMap<AnimationAmalgamation, AnimationAmalgamationDetails>();
            CreateMap<AnimationAmalgamationDetails, AnimationAmalgamation>();
            CreateMap<AnimationAmalgamationPlayBlast, AnimationAmalgamationPlayBlastDetails>();
            CreateMap<AnimationAmalgamationPlayBlastDetails, AnimationAmalgamationPlayBlast>();
            CreateMap<AnimationToProductLink, AnimationToProductLinkDetails>();
            CreateMap<AnimationToProductLinkDetails, AnimationToProductLink>();
            CreateMap<AnimationToProductLinkPlayBlast, AnimationToProductLinkPlayBlastDetails>();
            CreateMap<AnimationToProductLinkPlayBlastDetails, AnimationToProductLinkPlayBlast>();

            CreateMap<TradingType, TradingTypeDetails>();
            CreateMap<TradingTypeDetails, TradingType>();

            CreateMap<Role, RoleDetails>();
            CreateMap<RoleDetails, Role>();

            CreateMap<Role, RoleRegistrationDetails>();
            CreateMap<RoleRegistrationDetails, Role>();

        }
    }
}
