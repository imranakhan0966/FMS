using AutoMapper;
//using COI.Application.DTOs;
//using COI.Application.DTOs.Encashment;
//using COI.Application.DTOs.Inventory;
//using COI.Application.DTOs.Setup;
//using COI.Application.DTOs.Setup.Product;
//using COI.Application.DTOs.Setup.Tax;
//using COI.Application.Features.Employees.Queries.GetEmployees;
//using COI.Application.Features.Positions.Commands.CreatePosition;
//using COI.Application.Features.Positions.Queries.GetPositions;
//using COI.Domain.Entities;
//using COI.Domain.Entities.Encashment;
using Microsoft.AspNetCore.Routing;
using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.DTOs.Projects;
using Ozone.Application.Features.Employees.Queries.GetEmployees;
using Ozone.Application.Features.Positions.Commands.CreatePosition;
using Ozone.Application.Features.Positions.Queries.GetPositions;
using Ozone.Infrastructure.Persistence.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ozone.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //CreateMap<Position, GetPositionsViewModel>().ReverseMap();
            //CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();
            //CreateMap<CreatePositionCommand, Position>();
            
            //Authentication
            CreateMap<SecUser, SecUserPasswordModel>().ReverseMap();
            CreateMap<SecUserModel, SecUser>().ReverseMap();
            CreateMap<SecUser, SecUserModel>()
                .ForMember(sup => sup.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(sup => sup.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                 .ForMember(sup => sup.CountryName, opt => opt.MapFrom(src => src.Country.Name))
                  .ForMember(sup => sup.StateName, opt => opt.MapFrom(src => src.State.Name))
                   .ForMember(sup => sup.CityName, opt => opt.MapFrom(src => src.City.Name))
                   .ForMember(sup => sup.PrefixNmae, opt => opt.MapFrom(src => src.Prefix.Name))
                     .ForMember(sup => sup.ApprovelStatus, opt => opt.MapFrom(src => src.ApprovelStatus.Name))
                     .ForMember(sup => sup.OrganizationName, opt => opt.MapFrom(src => src.Organization.Name))
                     .ForMember(sup => sup.ParentUserName, opt => opt.MapFrom(src => src.ParentUser.FullName))
                     .ForMember(sup => sup.ParentAgencyId, opt => opt.MapFrom(src => src.ParentUser.OrganizationId))
                      .ForMember(sup => sup.ParentAgencyName, opt => opt.MapFrom(src => src.ParentUser.Organization.Name))


                .ForMember(x => x.Status, opt => opt.MapFrom(src =>
                 (src.IsAuthorized == true && src.IsSubmitted == false) ? "Authorized" :
                 (src.IsAuthorized == null && src.IsSubmitted == false) ? "Draft" :
                 (src.IsAuthorized == false && src.IsSubmitted == false) ? "Rejected" :
                 (src.IsAuthorized == true && src.IsSubmitted == true) ? "Authorized" :
                 (src.IsAuthorized == null && src.IsSubmitted == true) ? "Submitted" : " "
                 ));

            // CreateMap<SecUserPagedModel, SecUser>().ReverseMap();
            CreateMap<SecFormPagedModel, SecForm>().ReverseMap();
            CreateMap<SecRoleFormModel, SecRoleForm>().ReverseMap();
            CreateMap<SecRole, SecRoleFormPagedModel>().ReverseMap();
            CreateMap<SecRole, SecRoleFormPagedModel>()
             .ForMember(x => x.Status, opt => opt.MapFrom(src =>
                 (src.IsAuthorized == true && src.IsSubmitted == false) ? "Authorized" :
                 (src.IsAuthorized == null && src.IsSubmitted == false) ? "Draft" :
                 (src.IsAuthorized == false && src.IsSubmitted == false) ? "Rejected" :
                 (src.IsAuthorized == true && src.IsSubmitted == true) ? "Authorized" :
                 (src.IsAuthorized == null && src.IsSubmitted == true) ? "Submitted" : " "
                 ));
            CreateMap<SecRoleForm, SecRoleFormLoginModel>()
                 .ForMember(x => x.FormId, opt => opt.MapFrom(src => src.PermissionId))
                 .ForMember(x => x.FormName, opt => opt.MapFrom(src => src.Permission.Name))
                 .ForMember(x => x.FormCode, opt => opt.MapFrom(src => src.Permission.Code))
                .ReverseMap();
            //Security
            CreateMap<SecUserSession, SecUserSessionModel>().ReverseMap();
            CreateMap<SecPolicy, SecPolicyModel>().ReverseMap();

            CreateMap<SecUserSession, SecUserSessionModel>();
            CreateMap<SecPolicy, SecPolicyModel>();
            // Security get
            CreateMap<SecUserSessionModel, SecUserSession>();
            CreateMap<SecPolicyModel, SecPolicy>();

            CreateMap<Section, SectionModel>();
            CreateMap<Module, ModuleModel>();
            CreateMap<DocumentType, DocumentsTypeModel>();

            //HolidayCalendar
            CreateMap<HolidayCalendar, HolidayCalendarModel>()

              .ForMember(x => x.HolidayName, opt => opt.MapFrom(src => src.HolidayType.Name))
             


              .ReverseMap();
            CreateMap<HolidayType, HolidayTypeModel>();

            CreateMap<ProjectLedgerDetail, ProjectLedgerDetailModel>();
            CreateMap<ProjectLedger, ProjectLedgerModel>()
            .ForMember(x => x.AgencyName, opt => opt.MapFrom(src => src.Project.Client.Organization.Name))
            .ForMember(x => x.ClientName, opt => opt.MapFrom(src => src.Project.Client.Name))
            .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Project.Standard.Name))
            .ForMember(x => x.ProjectCode, opt => opt.MapFrom(src => src.Project.ProjectCode))
            .ForMember(x => x.ReceivedAmount, opt => opt.MapFrom(src => src.ProjectLedgerDetail.Sum(x=>x.ReceiveAmount)));


            CreateMap<Library, LibraryResourcesModel>()
            .ForMember(x => x.ModuleName, opt => opt.MapFrom(src => src.Module.Name))
             .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Certification.Name))
              .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status.Name));
            CreateMap<Status, StatusModel>();
            CreateMap<Certification, CertificationModel>();
            CreateMap<Cities, CityModel>()

             .ForMember(x => x.CountryName, opt => opt.MapFrom(src => src.Country.Name))
               .ForMember(x => x.StateName, opt => opt.MapFrom(src => src.State.Name))
                
               
              .ReverseMap();

            CreateMap<State, StateModel>()

           .ForMember(x => x.CountryName, opt => opt.MapFrom(src => src.Country.Name))
            


            .ReverseMap();
            CreateMap<Countries, CountryModel>();
            CreateMap<Prifix, PrefixModel>();
           // CreateMap<State, StateModel>();
            CreateMap<Organization, OrganizationModel>();
            CreateMap<Client, ClientModel>()
                .ForMember(x => x.CityName, opt => opt.MapFrom(src => src.City.Name))
                 .ForMember(x => x.CountryName, opt => opt.MapFrom(src => src.Country.Name))
                  .ForMember(x => x.StateName, opt => opt.MapFrom(src => src.State.Name))
                  //.ForMember(x => x.CityName, opt => opt.MapFrom(src => src.City.Name))
                   .ForMember(x => x.OrganizationName, opt => opt.MapFrom(src => src.Organization.Name))
                     .ForMember(x => x.OrganizationCode, opt => opt.MapFrom(src => src.Organization.Code))
                  .ForMember(x => x.OverAllEmployees, opt => opt.MapFrom(src => src.ClientSites.Sum(x => x.TotalEmployees)))
             .ReverseMap();

            CreateMap<Active, IsActiveModel>();


           // CreateMap<UserStandards, UserStandardModel>();
           // CreateMap<UserDeclaration, UserDeclarationModel>();
            CreateMap<UserProfessional, UserProfessionalModel>();
            CreateMap<UserEmployment, UserEmploymentModel>();
            CreateMap<UserConsultancy, UserConsultancyModel>()
              .ForMember(x => x.EacodeName, opt => opt.MapFrom(src => src.Eacode.Name))
               .ForMember(x => x.NacecodeName, opt => opt.MapFrom(src => src.NaceCode.Name))
                .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Standard.Name))

              .ReverseMap();
            CreateMap<UserAcademic, UserAcademicModel>();
           // CreateMap<UserAudit, UserAuditModel>();
            //CreateMap<UserAuditorNace, UserAuditorNaceModel>();
            CreateMap<UserCpd, UserCPDModel>().ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Standard.Name))

              .ReverseMap();
            CreateMap<AuditorTypes, AuditorTypeModel>();
            CreateMap<CourseType, CourseTypeModel>();
            CreateMap<ApprovalStatus, ApprovalStatusModel>();
            CreateMap<ContractType, ContractTypeModel>();
            CreateMap<Eacode, EACodeModel>();
            CreateMap<NaceCode, NaceCodeModel>();

            CreateMap<UserStandards, UserStandardModel>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.User.FullName))
               .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Standard.Name))
               .ForMember(x => x.ApprovalStatus, opt => opt.MapFrom(src => src.ApprovalStatus.Name))
               .ForMember(x => x.AuditorTypeName, opt => opt.MapFrom(src => src.AuditorType.Name))
               .ForMember(x => x.CourseTypeName, opt => opt.MapFrom(src => src.CourseType.Name))
               

              .ReverseMap();
            //get
            CreateMap<UserDeclaration, UserDeclarationModel>()
            .ForMember(x => x.ContractTypeName, opt => opt.MapFrom(src => src.ContractType.Name))
            .ForMember(x => x.ApprovalStatus, opt => opt.MapFrom(src => src.ApprovalStatus.Name))
           
           .ReverseMap();

            CreateMap<UserRemarks, UserRemarksModel>()
           .ForMember(x => x.ApprovalStatus, opt => opt.MapFrom(src => src.ApprovalStatus.Name))
             .ForMember(x => x.RemarksBy, opt => opt.MapFrom(src => src.RemarksBy.FullName))


          .ReverseMap();

            ////get
            CreateMap<SecRole, SecRoleModelUpdate>();
            CreateMap<SecRoleForm, SecRoleFormModel>()
                .ForMember(a => a.PermissionId, map => map.MapFrom(src => src.PermissionId))
                .ForMember(a => a.PermissionName, map => map.MapFrom(src => src.Permission.Name));
            //create
            CreateMap<SecRoleModelUpdate, SecRole>();
            CreateMap<SecRoleFormModel, SecRoleForm>();



            CreateMap<ProjectSa8000, ProjectSA8000Model>()
       // .ForMember(x => x.ProjectTypeName, opt => opt.MapFrom(src => src.ProjectType.Name))
          .ForMember(x => x.RiskName, opt => opt.MapFrom(src => src.Risk.Name))
           .ForMember(x => x.Eacodename, opt => opt.MapFrom(src => src.Eacode.Name))
               .ForMember(x => x.NaceCodeName, opt => opt.MapFrom(src => src.NaceCode.Name))
                   .ForMember(x => x.ConsultantName, opt => opt.MapFrom(src => src.Consultant.Name))
                       .ForMember(x => x.AccreditationName, opt => opt.MapFrom(src => src.Accreditation.Name))
                           .ForMember(x => x.SurveillanceVisitFrequencyName, opt => opt.MapFrom(src => src.SurveillanceVisitFrequency.Name))
                       .ForMember(x => x.SurveillanceMethodName, opt => opt.MapFrom(src => src.SurveillanceMethod.Name))
                           .ForMember(x => x.ExpensesName, opt => opt.MapFrom(src => src.Expenses.Name))
                               .ForMember(x => x.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy.FullName))
                                   .ForMember(x => x.LastModifiedByName, opt => opt.MapFrom(src => src.LastModifiedBy.FullName))
                                       .ForMember(x => x.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy.FullName))
                                           //.ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(src => src.ApprovalStatus.Name))
                       .ReverseMap();

    //        CreateMap<ProjectSa8000, ProjectSA8000CreateModel>()
    //.ForMember(x => x.ProjectTypeName, opt => opt.MapFrom(src => src.ProjectType.Name))
    //  .ForMember(x => x.RiskName, opt => opt.MapFrom(src => src.Risk.Name))
    //   .ForMember(x => x.Eacodename, opt => opt.MapFrom(src => src.Eacode.Name))
    //       .ForMember(x => x.NaceCodeName, opt => opt.MapFrom(src => src.NaceCode.Name))
    //           .ForMember(x => x.ConsultantName, opt => opt.MapFrom(src => src.Consultant.UserName))
    //               .ForMember(x => x.AccreditationName, opt => opt.MapFrom(src => src.Accreditation.Name))
    //                   .ForMember(x => x.SurveillanceVisitFrequencyName, opt => opt.MapFrom(src => src.SurveillanceVisitFrequency.Name))
    //               .ForMember(x => x.SurveillanceMethodName, opt => opt.MapFrom(src => src.SurveillanceMethod.Name))
    //                   .ForMember(x => x.ExpensesName, opt => opt.MapFrom(src => src.Expenses.Name))
    //                       .ForMember(x => x.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy.UserName))
    //                           .ForMember(x => x.LastModifiedByName, opt => opt.MapFrom(src => src.LastModifiedBy.UserName))
    //                               .ForMember(x => x.ApprovedByName, opt => opt.MapFrom(src => src.ApprovedBy.UserName))
    //                                   .ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(src => src.ApprovalStatus.Name))
    //               .ReverseMap();


            CreateMap<AuditType, AuditTypeModel>();
            CreateMap<CertificationBody, CertificationBodyModel>();

            //CreateMap <ClientSites, ClientSitesModel>();
            CreateMap<AuditorTypes, AuditorTypeModel>();
            CreateMap<VerificationType, VerificationTypeModel>();
            CreateMap<ProjectType, ProjectTypeModel>();
            CreateMap<Accreditation, AccreditationModel>();
            CreateMap<SurveillanceVisitFrequency, SurveillanceVisitFrequencyModel>();
            CreateMap<SurveillanceMethod, SurveillanceMethodModel>();
            CreateMap<Expenses, ExpencesModel>();
            CreateMap<Risk, RiskModel>();

            CreateMap<StandardType, StandardTypeModel>();

            CreateMap<ClientSites, ClientSitesModel>()
            .ForMember(x => x.CountryName, opt => opt.MapFrom(src => src.Country.Name))
             .ForMember(x => x.CityName, opt => opt.MapFrom(src => src.City.Name))
               .ForMember(x => x.StateName, opt => opt.MapFrom(src => src.State.Name))
                .ForMember(x => x.ClientName, opt => opt.MapFrom(src => src.Client.Name))
                 .ForMember(x => x.AgencyCode, opt => opt.MapFrom(src => src.Client.Organization.Code))
                .ForMember(x => x.ClientCode, opt => opt.MapFrom(src => src.Client.Code))
                             
                                        



           .ReverseMap();

            CreateMap<ClientProjects, ClientProjectModel>()
           .ForMember(x => x.AgencyName, opt => opt.MapFrom(src => src.Client.Organization.Name))
           .ForMember(x => x.ClientName, opt => opt.MapFrom(src => src.Client.Name))
           .ForMember(x => x.ProjectTypeName, opt => opt.MapFrom(src => src.ProjectType.Name))
            .ForMember(x => x.SiteName, opt => opt.MapFrom(src => src.ClientSite.SiteName))
              .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Standard.Name))
               .ForMember(x => x.VerificationTypeName, opt => opt.MapFrom(src => src.VerificationType.Name))
                 .ForMember(x => x.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy.FullName))
                       .ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(src => src.ApprovalStatus.Name))
                         //.ForMember(x => x.ClientId, opt => opt.MapFrom(src => src.ClientSite.ClientId))
                             .ForMember(x => x.AgencyCode, opt => opt.MapFrom(src => src.Client.Organization.Code))
                                 .ForMember(x => x.ClientCode, opt => opt.MapFrom(src => src.Client.Code))
                                     .ForMember(x => x.ClientSiteCode, opt => opt.MapFrom(src => src.ClientSite.Code))
                                         .ForMember(x => x.StandardCode, opt => opt.MapFrom(src => src.Standard.Code))
                                          .ForMember(x => x.AgencyId, opt => opt.MapFrom(src => src.Client.OrganizationId))
                                       .ForMember(x => x.ProjectStandardAmount, opt => opt.MapFrom(src => src.ProjectAmount.Amount))




          .ReverseMap();


            CreateMap<ProjectFormsPath, ProjectFormPathModel>();


              CreateMap<ProjectRemarksHistory, ProjectRemarksHistoryModel>()
           .ForMember(x => x.ProjectTypeName, opt => opt.MapFrom(src => src.Project.ProjectType.Name))
            .ForMember(x => x.RemarksBy, opt => opt.MapFrom(src => src.RemarksBy.FullName))
              .ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(src => src.ApprovalStatus.Name))
              .ForMember(x => x.ClientId, opt => opt.MapFrom(src => src.Project.ClientSite.ClientId))




          .ReverseMap();



            CreateMap<ProjectsApprovalStatus, ProjectApprovalStatusModel>();
            //CreateMap<AuditorTypes, LegislationModel>();
            CreateMap<Legislation, LegislationModel>();
            CreateMap<ApplicationType, ApplicationTypeModel>();
            CreateMap<AuditorTypes, AudditorTypeModel>();

            CreateMap<ProjectHigg, ProjectHiggModel>();
            CreateMap<ServiceType, ServiceTypeModel>();
            CreateMap<Methodology, MethodologyModel>();
            CreateMap<AssessmentCompleted, AssessmentCompletedModel>();
            CreateMap<CompletedModule, CompletedModuleModel>();
            CreateMap<EffluentTreatmentPlant, EffluentTreatmentPlantModel>();
            CreateMap<ModuleVersion, ModuleVersionModel>();
            CreateMap<ModuleShare, ModuleShareModel>();
            CreateMap<RequestOfSite, RequestOfSiteModel>();

            CreateMap<ProjectSlcp, ProjectSLCPModel>();
            CreateMap<CompletedSteps, CompletedStepsModel>();

           // CreateMap<ClientAuditVisit, ClientAuditVisitModel>();

            CreateMap<ClientAuditVisit, ClientAuditVisitModel>()
         .ForMember(x => x.ProjectCode, opt => opt.MapFrom(src => src.Project.ProjectCode))
          .ForMember(x => x.VisitStatusName, opt => opt.MapFrom(src => src.VisitStatus.Name))
            .ForMember(x => x.VisitTypeName, opt => opt.MapFrom(src => src.VisitType.Name))
               .ForMember(x => x.Auditor5Name, opt => opt.MapFrom(src => src.Auditor5.FullName))
                .ForMember(x => x.Auditor1Name, opt => opt.MapFrom(src => src.Auditor1.FullName))
                 .ForMember(x => x.Auditor2Name, opt => opt.MapFrom(src => src.Auditor2.FullName))
                  .ForMember(x => x.Auditor3Name, opt => opt.MapFrom(src => src.Auditor3.FullName))
                   .ForMember(x => x.Auditor4Name, opt => opt.MapFrom(src => src.Auditor4.FullName))
                      .ForMember(x => x.TechnicalExpertName, opt => opt.MapFrom(src => src.TechnicalExpert.FullName))
                       .ForMember(x => x.LeadAuditorName, opt => opt.MapFrom(src => src.LeadAuditor.FullName))
                        .ForMember(x => x.JustifiedPersonName, opt => opt.MapFrom(src => src.JustifiedPerson.FullName))
                        .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Project.Standard.Name))
                         .ForMember(x => x.ReviewerName, opt => opt.MapFrom(src => src.Reviewer.FullName))
                         .ForMember(x => x.StandardId, opt => opt.MapFrom(src => src.Project.StandardId))
                             .ForMember(x => x.ClientId, opt => opt.MapFrom(src => src.Project.ClientId))
                               .ForMember(x => x.VisitLevelName, opt => opt.MapFrom(src => src.VisitLevel.Name))
                               .ForMember(x => x.ClientName, opt => opt.MapFrom(src => src.Project.Client.Name))

                         .ReverseMap();

            CreateMap<VisitStatus, VisitStatusModel>();
            CreateMap<VisitType, VisitTypeModel>();
            

                 CreateMap<UserAudit, UserAuditModel>()
         .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Standard.Name))
          .ForMember(x => x.CertificationBodyName, opt => opt.MapFrom(src => src.CertificationBody.Body))
            .ForMember(x => x.EacodeName, opt => opt.MapFrom(src => src.Eacode.Name))
            .ForMember(x => x.NacecodeName, opt => opt.MapFrom(src => src.NaceCode.Name))
            .ForMember(x => x.AuditTypeName, opt => opt.MapFrom(src => src.AuditType.Name))

        .ReverseMap();

            CreateMap<UserAuditorNace, UserAuditorNaceModel>()
                .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Standard.Name))
             .ForMember(x => x.EacodeName, opt => opt.MapFrom(src => src.Eacode.Name))
            .ForMember(x => x.NacecodeName, opt => opt.MapFrom(src => src.NaceCode.Name))
            .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.User.FullName))
              .ForMember(x => x.ApprovalStatus, opt => opt.MapFrom(src => src.ApprovalStatus.Name))


        .ReverseMap();

            CreateMap<AuditReport, AuditReportModel>()
               .ForMember(x => x.AuditDocumentName, opt => opt.MapFrom(src => src.AuditDocumentType.Name))
            


       .ReverseMap();

            CreateMap<ProjectAmount, ProjectAmountModel>()
              .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Standard.Name))
           .ForMember(x => x.Agency, opt => opt.MapFrom(src => src.Organization.Name))

         .ReverseMap();

            CreateMap<AuditDocumentsType, AuditDocumentsTypeModel>();


            CreateMap<AuditReportDetail, AuditVisitReportMasterModel>()
            .ForMember(x => x.AuditDocumentName, opt => opt.MapFrom(src => src.AuditDocumentType.Name))

             //.ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(src => src.AuditReportMaster.ApprovalStatus.Name))
             .ForMember(x => x.AuditReportMasterId, opt => opt.MapFrom(src => src.AuditReportMaster.Id))
             .ForMember(x => x.ClientAuditVisitId, opt => opt.MapFrom(src => src.AuditReportMaster.ClientAuditVisitId))
             .ForMember(x => x.ProjectId, opt => opt.MapFrom(src => src.AuditReportMaster.ProjectId))
             .ForMember(x => x.ProjectCode, opt => opt.MapFrom(src => src.AuditReportMaster.Project.ProjectCode))
                          //.ForMember(x => x.AuditReportMasterId, opt => opt.MapFrom(src => src.AuditReportMaster.Project.ProjectCode))
             .ReverseMap();
            CreateMap<AuditReportMaster, AuditReportMSModel>()
           .ForMember(x => x.ProjectCode, opt => opt.MapFrom(src => src.Project.ProjectCode))
            .ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(src => src.ApprovalStatus.Name))


      .ReverseMap();
            CreateMap<ResetPasswordAccount
, ResetPasswordModel>();

            CreateMap<QcdocumentsList, QCDocumentsListModel>()

                .ForMember(x => x.StandardName, opt => opt.MapFrom(src => src.Standard.Name)).ReverseMap();

            CreateMap<QcHistory, QCHistoryModel>()

                 .ForMember(x => x.RemarksBy, opt => opt.MapFrom(src => src.RemarksBy.FullName)).ReverseMap();
            CreateMap<QcMasterComments, QcCommentsMasterModel>()

              .ForMember(x => x.StatusName, opt => opt.MapFrom(src => src.QcStatus.Name)).ReverseMap();

            CreateMap<Consultant, ConsultantModel>();
            CreateMap<VisitLevel, VisitLevelModel>();
            CreateMap<Buildings, BuildingsModel>()
                 .ForMember(x => x.CountryName, opt => opt.MapFrom(src => src.Country.Name))
               .ForMember(x => x.StateName, opt => opt.MapFrom(src => src.State.Name))
                .ForMember(x => x.CityName, opt => opt.MapFrom(src => src.City.Name))
              .ReverseMap();

            CreateMap<Client, ClientModel>()
                 .ForMember(x => x.CountryName, opt => opt.MapFrom(src => src.Country.Name))
               .ForMember(x => x.StateName, opt => opt.MapFrom(src => src.State.Name))
                .ForMember(x => x.CityName, opt => opt.MapFrom(src => src.City.Name))
              .ReverseMap();

            CreateMap<SecUser, SecUserModel>()
                .ForMember(x => x.CountryName, opt => opt.MapFrom(src => src.Country.Name))
              .ForMember(x => x.StateName, opt => opt.MapFrom(src => src.State.Name))
               .ForMember(x => x.CityName, opt => opt.MapFrom(src => src.City.Name))
               .ForMember(x=>x.BuildingName, opt => opt.MapFrom(src => src.Building.Name))
             .ReverseMap();

            CreateMap<ClientModel, Client>();

            CreateMap<BuildingsModel, Buildings>();

            CreateMap<Floors, FloorsModel>();
            CreateMap<FloorsModel, Floors>();
            
            CreateMap<FloorTypeModel, FloorType>();
            CreateMap<FloorType, FloorTypeModel>();
            
            CreateMap<Flats, FlatModel>();
            CreateMap<FlatModel, Flats>();
            
            CreateMap<ParkingSlots, ParkingSlotModel>();
            CreateMap<ParkingSlotModel, ParkingSlots>();
            
            CreateMap<PriorityModel, Priority>();
            CreateMap<Priority, PriorityModel>();
            
            CreateMap<Status, ServiceStatusModel>();
            CreateMap<ServiceStatusModel, Status>();

            CreateMap<ServiceRequest, ServiceRequestModel>();
            CreateMap<ServiceRequestModel, ServiceRequest>();

            CreateMap<WorkProgressHistory, WorkProgressHistoryModel>();
            CreateMap<WorkProgressHistoryModel, WorkProgressHistory>();

            CreateMap<ServiceType, ServiceTypeModel>();
            CreateMap<ServiceTypeModel, ServiceType>();
            
        }
    }

}
