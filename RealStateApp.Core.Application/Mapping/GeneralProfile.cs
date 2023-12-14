using AutoMapper;
using RealStateApp.Core.Application.ViewModels.User;
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Domain.Entities;
using RealStateApp.Core.Application.ViewModels.PropertiesTypes;
using RealStateApp.Core.Application.ViewModels.Properties;
using RealStateApp.Core.Application.ViewModels.SalesTypes;
using RealStateApp.Core.Application.ViewModels.Improvements;
using RealStateApp.Core.Application.ViewModels.ImagesProperties;
using RealStateApp.Core.Application.ViewModels.ImprovementsProperties;
using RealStateApp.Core.Application.Dtos.Api.Properties;
using RealStateApp.Core.Application.Features.Properties.Queries.GetAllProperties;
using RealStateApp.Core.Application.Dtos.User;
using RealStateApp.Core.Application.ViewModels.Agents;
using RealStateApp.Core.Application.ViewModels.AgentImages;

namespace RealStateApp.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region UserProfile

            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UserDTO, AgentVM>()
                .ReverseMap()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.IsActive, opt => opt.Ignore())
                .ForMember(x => x.HasError, opt => opt.Ignore());
   ;

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            #endregion

            #region Properties

            CreateMap<Properties, SavePropertiesVM>()
                .ForMember(x => x.PropertiesTypes, opt => opt.Ignore())
                .ForMember(x => x.PropertiesImprovementsId, opt => opt.Ignore())
                .ForMember(x => x.Improvements, opt => opt.Ignore())
                .ForMember(x => x.ImagesProperties, opt => opt.Ignore())
                 .ForMember(x => x.SalesTypes, opt => opt.Ignore())
                  .ForMember(x => x.File, opt => opt.Ignore())
                 .ReverseMap()
                  .ForMember(x => x.Created, opt => opt.Ignore())
                   .ForMember(x => x.PropertiesTypes, opt => opt.Ignore())
                   .ForMember(x => x.PropertiesImprovements, opt => opt.Ignore())
                    .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                     .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                      .ForMember(x => x.LastModified, opt => opt.Ignore())
                       .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                        .ForMember(x => x.SaleTypes, opt => opt.Ignore());

            CreateMap<Properties, PropertiesVM>()
              //.ForMember(x => x.PropertiesTypes, opt => opt.Ignore())
              //.ForMember(x => x.PropertiesImprovementsId, opt => opt.Ignore())
              //.ForMember(x => x.Improvements, opt => opt.Ignore())
              //.ForMember(x => x.ImagesProperties, opt => opt.Ignore())
              // .ForMember(x => x.SalesTypes, opt => opt.Ignore())
              //  .ForMember(x => x.File, opt => opt.Ignore())
               .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.PropertiesTypes, opt => opt.Ignore())
                 .ForMember(x => x.PropertiesImprovements, opt => opt.Ignore())
                  .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                   .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                    .ForMember(x => x.LastModified, opt => opt.Ignore())
                     .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                      .ForMember(x => x.SaleTypes, opt => opt.Ignore());

            CreateMap<GetAllPropertiesParameter, GetAllPropertiesQuery>()
                .ReverseMap();

            #endregion

            #region PropertiesTypes

            CreateMap<PropertiesTypes, PropertiesTypesVM>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                .ForMember(x => x.Properties, opt => opt.Ignore());


            CreateMap<PropertiesTypes, SavePropertiesTypesVM>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                .ForMember(x => x.Properties, opt => opt.Ignore());

            #endregion


            #region SalesTypes

            CreateMap<SalesTypes, SalesTypesVM>()
               .ReverseMap()
               .ForMember(x => x.Created, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
               .ForMember(x => x.IsDeleted, opt => opt.Ignore())
               .ForMember(x => x.Properties, opt => opt.Ignore());


            CreateMap<SalesTypes, SaveSalesTypesVM>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                .ForMember(x => x.Properties, opt => opt.Ignore());

            #endregion

            #region Improvements

            CreateMap<Improvements, ImprovementsVM>()
               .ReverseMap()
               .ForMember(x => x.Created, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
               .ForMember(x => x.IsDeleted, opt => opt.Ignore())
               .ForMember(x => x.PropertiesImprovements, opt => opt.Ignore());


            CreateMap<Improvements, SaveImprovementsVM>()
             .ReverseMap()
             .ForMember(x => x.Created, opt => opt.Ignore())
             .ForMember(x => x.CreatedBy, opt => opt.Ignore())
             .ForMember(x => x.LastModified, opt => opt.Ignore())
             .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
             .ForMember(x => x.IsDeleted, opt => opt.Ignore())
             .ForMember(x => x.PropertiesImprovements, opt => opt.Ignore());

            #endregion

            #region ImagesProperties

            CreateMap<SaveImagesPropertiesVM, ImagesProperties>()
                .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                  .ForMember(x => x.LastModified, opt => opt.Ignore())
                   .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                    .ForMember(x => x.Created, opt => opt.Ignore())
                     .ForMember(x => x.IsDeleted, opt => opt.Ignore())
                      .ForMember(x => x.Properties, opt => opt.Ignore())
                     .ReverseMap();

            #endregion

            #region PropertiesImprovements

            CreateMap<SavePropertiesImprovementsVM, PropertiesImprovements>()
                   .ForMember(x => x.Improvements, opt => opt.Ignore())
                    .ForMember(x => x.Properties, opt => opt.Ignore())
                   .ReverseMap();

            #endregion

            #region AgentImages

            CreateMap<SaveAgentImagesVM, AgentImages>()
                .ReverseMap();

            CreateMap<AgentImagesVM, AgentImages>()
                .ReverseMap();

            #endregion

        }
    }
}
