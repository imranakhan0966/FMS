using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//using COI.Domain.Settings;
using Ozone.Infrastructure.Shared.Services;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Interfaces.Security;

using Ozone.Application.Interfaces;
using Ozone.Infrastructure.Shared;
using Ozone.Application;
using Ozone.Application.Interfaces.Setup;
using Ozone.Infrastructure.Shared.Services.MasterSetups;

using Ozone.Infrastructure.Shared.Services;

namespace Ozone.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
          
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IAllDropdownService, AllDropdownService>();
            services.AddTransient<ITenantRequestService, TenantRequestService>();
            services.AddTransient<ITenantServiceTypeService, TenantServiceTypeService>();
            services.AddTransient<ITenantWorkProgresHistoryService, TenantWorkProgresHistoryService>();
            services.AddTransient<ITenantBuildingService, TenantBuildingService>();
            services.AddTransient<ITenantFloorService, TenantFloorService>();
            services.AddTransient<ITenantFloorTypeService, TenantFloorTypeService>();
            services.AddTransient<ITenantFlatService, TenantFlatService>();
            services.AddTransient<ITenantParkingSlotService, TenantParkingSlotService>();
            services.AddTransient<ITenantClientService, TenantClientService>();
            services.AddTransient<ITenanatUserManagementService, TenanatUserManagementService>();

            services.AddSingleton<UserService>();
           services.AddTransient<IUnitOfWork, UnitOfWork>();
           // services.AddTransient<IM, SecUserService>();
            services.AddTransient<ISecUserService, SecUserService>();
       
            services.AddTransient<ICOIAuthenticationService, COIAuthenticationService>();
            services.AddTransient<IActivityLogService, ActivityLogService>(); //---------------------------Activity Log
            //services.AddTransient<IDbViewService, DbViewService>(); //---------------------------DataBase Views Service

            //Indent
           // services.AddTransient<IIndentRequestService, IndentRequestService>();
           // services.AddTransient<IBatchMasterService, BatchMasterService>();
           
            
            //services.AddTransient<IProductService, ProductService>();

            services.AddTransient<ISecUserSessionService, SecUserSessionService>();

            //SECURITY 
            services.AddTransient<ISecRoleService, SecRoleService>();
            services.AddScoped<ISecPolicyService, SecPolicyService>();

            //HolidayCalendar
            services.AddTransient<IHolidayCalendarService, HolidayCalendarService>();

            //Master Setups
            services.AddTransient<IStandardService, StandardService>();
            services.AddTransient<IModuleService, ModuleService>();
            //SALES
            // services.AddTransient<ISCFMasterService, SCFMasterService>();

            //ApplicantInfo
            //services.AddScoped<IApplicantInfoService, ApplicantInfoService>();

            //Encashment
            // services.AddScoped<IEncashmentService, EncashmentService>();

            //Setup
            // services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            // services.AddTransient<IReligionService, ReligionService>();
            // services.AddTransient<ISetupService, SetupService>();
            // services.AddTransient<IProductRateService, ProductRateService>();
            // services.AddScoped<IBankService, BankService>();
            //services.AddScoped<IDocSeenService, DocSeenService>();
            //services.AddTransient<ICompanyService, CompanyService>();

            //Tax
            // services.AddTransient<ITaxService, TaxService>();

            //CustomerType
            //services.AddTransient<ICustomerTypeService, CustomerTypeService>();

            //IssueType
            //services.AddTransient<IIssueTypeService, IssueTypeService>();

            ///   services.AddTransient<IZakatService, ZakatService>(); //--------------------Zakat

            //StopPayment
            // services.AddTransient<IStopPaymentService, StopPaymentService>();

            ////Duplicate
            //services.AddTransient<IDuplicateService, DuplicateService>();

            //services.AddTransient<IDashboardService, DashboardService>(); //---------------DashBoard

            //// Reporting
            //services.AddTransient<IIndentReportService, IndentReportService>();
            services.AddTransient<ILibraryResources, LibraryResources>();
            services.AddTransient<IAgensyService, AgencyService>();
            services.AddTransient<IClientService, ClientService>();


            services.AddTransient<IUserStandardService, UserStandardService>();
            services.AddTransient<IUserDeclarationService, UserDeclarationService>();
            services.AddTransient<IUserProfessionalService, UserProfessionalService>();
            services.AddTransient<IUserAcademicService, UserAcademicService>();
            services.AddTransient<IUserEmploymentService, UserEmploymentService>();
            services.AddTransient<IUserCPDService, UserCPDService>();
            services.AddTransient<IUserConsultancyService, UserConsultancyService>();
            services.AddTransient<IUserAuditService, UserAuditService>();
            services.AddTransient<IUserAuditorNaceService, UserAuditorNaceorNaceService>();
       
           services.AddTransient<IProjectSA8000Service, ProjectSA8000Service>();
            services.AddTransient<IClientSitesService, ClientSitesService>();


            services.AddTransient<IStandardService, StandardService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IDocumentTypeService, DocumentTypeService>();
            services.AddTransient<IStandardTypeService, StandardTypeService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IEaCodeService, EaCodeService>();
            services.AddTransient<INaceCodeService, NaceCodeService>();
            services.AddTransient<ICertificationBodyService, CertificationBodyService>();

            services.AddTransient<ISectionService, SectionService>();

            services.AddTransient<ILegislationService, LegislationService>();

            services.AddTransient<IAccreditationService, AccreditationService>();

            services.AddTransient<IAudditorTypeService, AudditorTypeService>();

            services.AddTransient<IApplicationTypeService, ApplicationTypeService>();
            services.AddTransient<IProjectHiggService, ProjectHiggService>();
            services.AddTransient<IProjectSlcpPService, ProjectSlcpPService>();
            services.AddTransient<IClientAuditVisitService, ClientAuditVisitService>();
            services.AddTransient<IAuditReportService, AuditReportService>();
            services.AddTransient<IProjectAmountService, ProjectAmountSevice>();
            services.AddTransient<IProjectIsoService, ProjectIsoService>();
            services.AddTransient<IProjectAmountReportsService, ProjectAmountReportsService>();
            services.AddTransient<IQcDocumentService, QcDocumentService>();
            services.AddTransient<IConsultantService, ConsultantService>();
        }
    }
}
