using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sieve.Attributes;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class SecUser
    {
        public SecUser()
        {
            AccreditationCreatedBy = new HashSet<Accreditation>();
            AccreditationLastModifiedBy = new HashSet<Accreditation>();
            ActivityLog = new HashSet<ActivityLog>();
            AssessmentCompletedCreatedBy = new HashSet<AssessmentCompleted>();
            AssessmentCompletedLastModifiedBy = new HashSet<AssessmentCompleted>();
            AuditDocumentsTypeCreatedBy = new HashSet<AuditDocumentsType>();
            AuditDocumentsTypeLastModifiedBy = new HashSet<AuditDocumentsType>();
            AuditReportCreatedBy = new HashSet<AuditReport>();
            AuditReportDetailCreatedBy = new HashSet<AuditReportDetail>();
            AuditReportDetailLastModifiedBy = new HashSet<AuditReportDetail>();
            AuditReportHistory = new HashSet<AuditReportHistory>();
            AuditReportLastModifiedBy = new HashSet<AuditReport>();
            AuditReportMasterCreatedBy = new HashSet<AuditReportMaster>();
            AuditReportMasterLastModifiedBy = new HashSet<AuditReportMaster>();
            CertificationBodyCreatedByNavigation = new HashSet<CertificationBody>();
            CertificationBodyLastModifiedyNavigation = new HashSet<CertificationBody>();
            ClientAuditVisitAuditor1 = new HashSet<ClientAuditVisit>();
            ClientAuditVisitAuditor2 = new HashSet<ClientAuditVisit>();
            ClientAuditVisitAuditor3 = new HashSet<ClientAuditVisit>();
            ClientAuditVisitAuditor4 = new HashSet<ClientAuditVisit>();
            ClientAuditVisitAuditor5 = new HashSet<ClientAuditVisit>();
            ClientAuditVisitJustifiedPerson = new HashSet<ClientAuditVisit>();
            ClientAuditVisitLeadAuditor = new HashSet<ClientAuditVisit>();
            ClientAuditVisitReviewer = new HashSet<ClientAuditVisit>();
            ClientAuditVisitTechnicalExpert = new HashSet<ClientAuditVisit>();
            ClientProjectsApprovedBy = new HashSet<ClientProjects>();
            ClientProjectsCreatedBy = new HashSet<ClientProjects>();
            ClientProjectsLastModifiedBy = new HashSet<ClientProjects>();
            ClientSitesApprovedBy = new HashSet<ClientSites>();
            ClientSitesCreatedBy = new HashSet<ClientSites>();
            ClientSitesLastModifiedBy = new HashSet<ClientSites>();
            CompletedModuleCreatedBy = new HashSet<CompletedModule>();
            CompletedModuleLastModifiedBy = new HashSet<CompletedModule>();
            ConsultantCreatedBy = new HashSet<Consultant>();
            ConsultantLastUpdated = new HashSet<Consultant>();
            EffluentTreatmentPlantCreatedBy = new HashSet<EffluentTreatmentPlant>();
            EffluentTreatmentPlantLastModifiedBy = new HashSet<EffluentTreatmentPlant>();
            ExpensesCreatedBy = new HashSet<Expenses>();
            ExpensesLastModifiedBy = new HashSet<Expenses>();
            HolidayCalendarCreatedByNavigation = new HashSet<HolidayCalendar>();
            HolidayCalendarLastModifiedByNavigation = new HashSet<HolidayCalendar>();
            InverseParentUser = new HashSet<SecUser>();
            LegislationCreatedBy = new HashSet<Legislation>();
            LegislationLastModifiedBy = new HashSet<Legislation>();
            Library = new HashSet<Library>();
            MethodologyCreatedBy = new HashSet<Methodology>();
            MethodologyLastModifiedBy = new HashSet<Methodology>();
            ModuleShareCreatedBy = new HashSet<ModuleShare>();
            ModuleShareLastModifiedBy = new HashSet<ModuleShare>();
            ModuleVersionCreatedBy = new HashSet<ModuleVersion>();
            ModuleVersionLastModifiedBy = new HashSet<ModuleVersion>();
            ProjectAmountCreatedByNavigation = new HashSet<ProjectAmount>();
            ProjectAmountLastupdated = new HashSet<ProjectAmount>();
            ProjectHiggApprovedBy = new HashSet<ProjectHigg>();
            ProjectHiggCreatedBy = new HashSet<ProjectHigg>();
            ProjectHiggLastModifiedBy = new HashSet<ProjectHigg>();
            ProjectIsoApprovedBy = new HashSet<ProjectIso>();
            ProjectIsoCreatedBy = new HashSet<ProjectIso>();
            ProjectIsoLastModifiedBy = new HashSet<ProjectIso>();
            ProjectLedgerCreatedBy = new HashSet<ProjectLedger>();
            ProjectLedgerDetailCreatedBy = new HashSet<ProjectLedgerDetail>();
            ProjectLedgerDetailLastModifiedBy = new HashSet<ProjectLedgerDetail>();
            ProjectLedgerLastModifiedBy = new HashSet<ProjectLedger>();
            ProjectRemarksHistory = new HashSet<ProjectRemarksHistory>();
            ProjectSa8000ApprovedBy = new HashSet<ProjectSa8000>();
            ProjectSa8000CreatedBy = new HashSet<ProjectSa8000>();
            ProjectSa8000LastModifiedBy = new HashSet<ProjectSa8000>();
            ProjectSlcpApprovedBy = new HashSet<ProjectSlcp>();
            ProjectSlcpCreatedBy = new HashSet<ProjectSlcp>();
            ProjectSlcpLastModifiedBy = new HashSet<ProjectSlcp>();
            ProjectTypeCreatedBy = new HashSet<ProjectType>();
            ProjectTypeLastModifiedBy = new HashSet<ProjectType>();
            QcHistory = new HashSet<QcHistory>();
            RequestOfSiteCreatedBy = new HashSet<RequestOfSite>();
            RequestOfSiteLastModifiedBy = new HashSet<RequestOfSite>();
            ResetPasswordAccountCreatedBy = new HashSet<ResetPasswordAccount>();
            ResetPasswordAccountLastModifiedBy = new HashSet<ResetPasswordAccount>();
            ResetPasswordAccountUser = new HashSet<ResetPasswordAccount>();
            RiskCreatedBy = new HashSet<Risk>();
            RiskLastModifiedBy = new HashSet<Risk>();
            SecUserInvalidAccess = new HashSet<SecUserInvalidAccess>();
            SecUserPwdHistory = new HashSet<SecUserPwdHistory>();
            SecUserSession = new HashSet<SecUserSession>();
            SectionCreatedBy = new HashSet<Section>();
            SectionLastModifiedBy = new HashSet<Section>();
            ServiceTypeCreatedBy = new HashSet<ServiceType>();
            ServiceTypeLastModifiedBy = new HashSet<ServiceType>();
            StageOfCertificationCreatedBy = new HashSet<StageOfCertification>();
            StageOfCertificationLastModifiedBy = new HashSet<StageOfCertification>();
            StandardTypeCreatedBy = new HashSet<StandardType>();
            StandardTypeLastModifiedBy = new HashSet<StandardType>();
            SurveillanceMethodCreatedBy = new HashSet<SurveillanceMethod>();
            SurveillanceMethodLastModifiedBy = new HashSet<SurveillanceMethod>();
            SurveillanceVisitFrequencyCreatedBy = new HashSet<SurveillanceVisitFrequency>();
            SurveillanceVisitFrequencyLastModifiedBy = new HashSet<SurveillanceVisitFrequency>();
            UserAcademicApprovedBy = new HashSet<UserAcademic>();
            UserAcademicCreatedBy = new HashSet<UserAcademic>();
            UserAcademicLastModifiedByNavigation = new HashSet<UserAcademic>();
            UserAcademicUser = new HashSet<UserAcademic>();
            UserAuditApprovedByNavigation = new HashSet<UserAudit>();
            UserAuditCreatedByNavigation = new HashSet<UserAudit>();
            UserAuditLastModifiedByNavigation = new HashSet<UserAudit>();
            UserAuditUser = new HashSet<UserAudit>();
            UserAuditorNaceApprovedByNavigation = new HashSet<UserAuditorNace>();
            UserAuditorNaceCreatedByNavigation = new HashSet<UserAuditorNace>();
            UserAuditorNaceLastModifiedByNavigation = new HashSet<UserAuditorNace>();
            UserAuditorNaceUser = new HashSet<UserAuditorNace>();
            UserConsultancyApprovedByNavigation = new HashSet<UserConsultancy>();
            UserConsultancyCreatedByNavigation = new HashSet<UserConsultancy>();
            UserConsultancyLastModifiedByNavigation = new HashSet<UserConsultancy>();
            UserConsultancyUser = new HashSet<UserConsultancy>();
            UserCpdApprovedByNavigation = new HashSet<UserCpd>();
            UserCpdCreatedByNavigation = new HashSet<UserCpd>();
            UserCpdLastModifiedByNavigation = new HashSet<UserCpd>();
            UserCpdUser = new HashSet<UserCpd>();
            UserDeclarationApprovedByNavigation = new HashSet<UserDeclaration>();
            UserDeclarationCreatedByNavigation = new HashSet<UserDeclaration>();
            UserDeclarationUser = new HashSet<UserDeclaration>();
            UserEmploymentApprovedByNavigation = new HashSet<UserEmployment>();
            UserEmploymentCreatedByNavigation = new HashSet<UserEmployment>();
            UserEmploymentLastModifiedByNavigation = new HashSet<UserEmployment>();
            UserEmploymentUser = new HashSet<UserEmployment>();
            UserProfessionalApprovedByNavigation = new HashSet<UserProfessional>();
            UserProfessionalCreatedByNavigation = new HashSet<UserProfessional>();
            UserProfessionalLastModifiedByNavigation = new HashSet<UserProfessional>();
            UserProfessionalUser = new HashSet<UserProfessional>();
            UserRemarksRemarksBy = new HashSet<UserRemarks>();
            UserRemarksUser = new HashSet<UserRemarks>();
            UserStandardsApprovedbyNavigation = new HashSet<UserStandards>();
            UserStandardsCreatedByNavigation = new HashSet<UserStandards>();
            UserStandardsLastModifiedByNavigation = new HashSet<UserStandards>();
            UserStandardsUser = new HashSet<UserStandards>();
            VerificationTypeCreatedBy = new HashSet<VerificationType>();
            VerificationTypeLastUpdatedBy = new HashSet<VerificationType>();
            VisitLevelCreatedBy = new HashSet<VisitLevel>();
            VisitLevelLastUpdatedBy = new HashSet<VisitLevel>();
        }

        [Key]
        [Sieve(CanFilter = true)]
        public long Id { get; set; }
        [Sieve(CanFilter = true)]
        public string UserName { get; set; }
        [StringLength(50)]
        [Sieve(CanFilter = true)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        [Sieve(CanFilter = true)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public DateTime? PwdChangeDateTime { get; set; }
        public DateTime? ProfileExpiryDate { get; set; }
        [StringLength(50)]
        public string SecurityKey { get; set; }
        public long? DepartmentId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? LockedDateTime { get; set; }
        public int? AccessFailedCount { get; set; }
        [Sieve(CanFilter = true)]
        public long? RoleId { get; set; }
        public DateTime? RetirementDate { get; set; }
        [StringLength(50)]
        public string Designation { get; set; }
        public bool? IsClosed { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long? AuthorizedBy { get; set; }
        public DateTime? AuthorizedDate { get; set; }
        public bool? IsSubmitted { get; set; }
        public bool? IsAuthorized { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }
        public long? UserTypeId { get; set; }
        public long? PrefixId { get; set; }
        [Sieve(CanFilter = true)]
        public long? CountryId { get; set; }
        [Sieve(CanFilter = true)]
        public long? CityId { get; set; }
        [Sieve(CanFilter = true)]
        public long? StateId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [StringLength(30)]
        [Sieve(CanFilter = true)]
        public string Mobile { get; set; }
        [StringLength(30)]
        [Sieve(CanFilter = true)]
        public string Telephone { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public string PhotoPath { get; set; }
        public string PhotoContentType { get; set; }
        public string ConfidentialityPath { get; set; }
        public string ConfidentialityContentType { get; set; }
        public string ContractPath { get; set; }
        public string ContractContentType { get; set; }
        [StringLength(100)]
        [Sieve(CanFilter = true)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string RegistrationNo { get; set; }
        [StringLength(50)]
        public string EmailForgotPassword { get; set; }
        public long? OrganizationId { get; set; }
        public bool? IsDeleted { get; set; }
        public long? ApprovelStatusId { get; set; }
        public long? ParentUserId { get; set; }
        [Sieve(CanFilter = true)]

        public long? BuildingId { get; set; }
        public long? FloorId { get; set; }
        [Sieve(CanFilter = true)]
        public long? FlatId { get; set; }
        public long? ClientId { get; set; }

        [ForeignKey(nameof(ApprovelStatusId))]
        [InverseProperty(nameof(ApprovalStatus.SecUser))]
        public virtual ApprovalStatus ApprovelStatus { get; set; }
        [ForeignKey(nameof(BuildingId))]
        [InverseProperty(nameof(Buildings.SecUser))]
        public virtual Buildings Building { get; set; }
        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Cities.SecUser))]
        public virtual Cities City { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.SecUser))]
        public virtual Countries Country { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("SecUser")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(FlatId))]
        [InverseProperty(nameof(Flats.SecUser))]
        public virtual Flats Flat { get; set; }
        [ForeignKey(nameof(FloorId))]
        [InverseProperty(nameof(Floors.SecUser))]
        public virtual Floors Floor { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        [InverseProperty("SecUser")]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(ParentUserId))]
        [InverseProperty(nameof(SecUser.InverseParentUser))]
        public virtual SecUser ParentUser { get; set; }
        [ForeignKey(nameof(PrefixId))]
        [InverseProperty(nameof(Prifix.SecUser))]
        public virtual Prifix Prefix { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(SecRole.SecUser))]
        public virtual SecRole Role { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("SecUser")]
        public virtual State State { get; set; }
        [ForeignKey(nameof(UserTypeId))]
        [InverseProperty("SecUser")]
        public virtual UserType UserType { get; set; }
        [InverseProperty(nameof(Accreditation.CreatedBy))]
        public virtual ICollection<Accreditation> AccreditationCreatedBy { get; set; }
        [InverseProperty(nameof(Accreditation.LastModifiedBy))]
        public virtual ICollection<Accreditation> AccreditationLastModifiedBy { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        [InverseProperty(nameof(AssessmentCompleted.CreatedBy))]
        public virtual ICollection<AssessmentCompleted> AssessmentCompletedCreatedBy { get; set; }
        [InverseProperty(nameof(AssessmentCompleted.LastModifiedBy))]
        public virtual ICollection<AssessmentCompleted> AssessmentCompletedLastModifiedBy { get; set; }
        [InverseProperty(nameof(AuditDocumentsType.CreatedBy))]
        public virtual ICollection<AuditDocumentsType> AuditDocumentsTypeCreatedBy { get; set; }
        [InverseProperty(nameof(AuditDocumentsType.LastModifiedBy))]
        public virtual ICollection<AuditDocumentsType> AuditDocumentsTypeLastModifiedBy { get; set; }
        [InverseProperty(nameof(AuditReport.CreatedBy))]
        public virtual ICollection<AuditReport> AuditReportCreatedBy { get; set; }
        [InverseProperty(nameof(AuditReportDetail.CreatedBy))]
        public virtual ICollection<AuditReportDetail> AuditReportDetailCreatedBy { get; set; }
        [InverseProperty(nameof(AuditReportDetail.LastModifiedBy))]
        public virtual ICollection<AuditReportDetail> AuditReportDetailLastModifiedBy { get; set; }
        [InverseProperty("RemarksBy")]
        public virtual ICollection<AuditReportHistory> AuditReportHistory { get; set; }
        [InverseProperty(nameof(AuditReport.LastModifiedBy))]
        public virtual ICollection<AuditReport> AuditReportLastModifiedBy { get; set; }
        [InverseProperty(nameof(AuditReportMaster.CreatedBy))]
        public virtual ICollection<AuditReportMaster> AuditReportMasterCreatedBy { get; set; }
        [InverseProperty(nameof(AuditReportMaster.LastModifiedBy))]
        public virtual ICollection<AuditReportMaster> AuditReportMasterLastModifiedBy { get; set; }
        [InverseProperty(nameof(CertificationBody.CreatedByNavigation))]
        public virtual ICollection<CertificationBody> CertificationBodyCreatedByNavigation { get; set; }
        [InverseProperty(nameof(CertificationBody.LastModifiedyNavigation))]
        public virtual ICollection<CertificationBody> CertificationBodyLastModifiedyNavigation { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.Auditor1))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitAuditor1 { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.Auditor2))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitAuditor2 { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.Auditor3))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitAuditor3 { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.Auditor4))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitAuditor4 { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.Auditor5))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitAuditor5 { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.JustifiedPerson))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitJustifiedPerson { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.LeadAuditor))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitLeadAuditor { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.Reviewer))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitReviewer { get; set; }
        [InverseProperty(nameof(ClientAuditVisit.TechnicalExpert))]
        public virtual ICollection<ClientAuditVisit> ClientAuditVisitTechnicalExpert { get; set; }
        [InverseProperty(nameof(ClientProjects.ApprovedBy))]
        public virtual ICollection<ClientProjects> ClientProjectsApprovedBy { get; set; }
        [InverseProperty(nameof(ClientProjects.CreatedBy))]
        public virtual ICollection<ClientProjects> ClientProjectsCreatedBy { get; set; }
        [InverseProperty(nameof(ClientProjects.LastModifiedBy))]
        public virtual ICollection<ClientProjects> ClientProjectsLastModifiedBy { get; set; }
        [InverseProperty(nameof(ClientSites.ApprovedBy))]
        public virtual ICollection<ClientSites> ClientSitesApprovedBy { get; set; }
        [InverseProperty(nameof(ClientSites.CreatedBy))]
        public virtual ICollection<ClientSites> ClientSitesCreatedBy { get; set; }
        [InverseProperty(nameof(ClientSites.LastModifiedBy))]
        public virtual ICollection<ClientSites> ClientSitesLastModifiedBy { get; set; }
        [InverseProperty(nameof(CompletedModule.CreatedBy))]
        public virtual ICollection<CompletedModule> CompletedModuleCreatedBy { get; set; }
        [InverseProperty(nameof(CompletedModule.LastModifiedBy))]
        public virtual ICollection<CompletedModule> CompletedModuleLastModifiedBy { get; set; }
        [InverseProperty(nameof(Consultant.CreatedBy))]
        public virtual ICollection<Consultant> ConsultantCreatedBy { get; set; }
        [InverseProperty(nameof(Consultant.LastUpdated))]
        public virtual ICollection<Consultant> ConsultantLastUpdated { get; set; }
        [InverseProperty(nameof(EffluentTreatmentPlant.CreatedBy))]
        public virtual ICollection<EffluentTreatmentPlant> EffluentTreatmentPlantCreatedBy { get; set; }
        [InverseProperty(nameof(EffluentTreatmentPlant.LastModifiedBy))]
        public virtual ICollection<EffluentTreatmentPlant> EffluentTreatmentPlantLastModifiedBy { get; set; }
        [InverseProperty(nameof(Expenses.CreatedBy))]
        public virtual ICollection<Expenses> ExpensesCreatedBy { get; set; }
        [InverseProperty(nameof(Expenses.LastModifiedBy))]
        public virtual ICollection<Expenses> ExpensesLastModifiedBy { get; set; }
        [InverseProperty(nameof(HolidayCalendar.CreatedByNavigation))]
        public virtual ICollection<HolidayCalendar> HolidayCalendarCreatedByNavigation { get; set; }
        [InverseProperty(nameof(HolidayCalendar.LastModifiedByNavigation))]
        public virtual ICollection<HolidayCalendar> HolidayCalendarLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(SecUser.ParentUser))]
        public virtual ICollection<SecUser> InverseParentUser { get; set; }
        [InverseProperty(nameof(Legislation.CreatedBy))]
        public virtual ICollection<Legislation> LegislationCreatedBy { get; set; }
        [InverseProperty(nameof(Legislation.LastModifiedBy))]
        public virtual ICollection<Legislation> LegislationLastModifiedBy { get; set; }
        [InverseProperty("ReviewerNavigation")]
        public virtual ICollection<Library> Library { get; set; }
        [InverseProperty(nameof(Methodology.CreatedBy))]
        public virtual ICollection<Methodology> MethodologyCreatedBy { get; set; }
        [InverseProperty(nameof(Methodology.LastModifiedBy))]
        public virtual ICollection<Methodology> MethodologyLastModifiedBy { get; set; }
        [InverseProperty(nameof(ModuleShare.CreatedBy))]
        public virtual ICollection<ModuleShare> ModuleShareCreatedBy { get; set; }
        [InverseProperty(nameof(ModuleShare.LastModifiedBy))]
        public virtual ICollection<ModuleShare> ModuleShareLastModifiedBy { get; set; }
        [InverseProperty(nameof(ModuleVersion.CreatedBy))]
        public virtual ICollection<ModuleVersion> ModuleVersionCreatedBy { get; set; }
        [InverseProperty(nameof(ModuleVersion.LastModifiedBy))]
        public virtual ICollection<ModuleVersion> ModuleVersionLastModifiedBy { get; set; }
        [InverseProperty(nameof(ProjectAmount.CreatedByNavigation))]
        public virtual ICollection<ProjectAmount> ProjectAmountCreatedByNavigation { get; set; }
        [InverseProperty(nameof(ProjectAmount.Lastupdated))]
        public virtual ICollection<ProjectAmount> ProjectAmountLastupdated { get; set; }
        [InverseProperty(nameof(ProjectHigg.ApprovedBy))]
        public virtual ICollection<ProjectHigg> ProjectHiggApprovedBy { get; set; }
        [InverseProperty(nameof(ProjectHigg.CreatedBy))]
        public virtual ICollection<ProjectHigg> ProjectHiggCreatedBy { get; set; }
        [InverseProperty(nameof(ProjectHigg.LastModifiedBy))]
        public virtual ICollection<ProjectHigg> ProjectHiggLastModifiedBy { get; set; }
        [InverseProperty(nameof(ProjectIso.ApprovedBy))]
        public virtual ICollection<ProjectIso> ProjectIsoApprovedBy { get; set; }
        [InverseProperty(nameof(ProjectIso.CreatedBy))]
        public virtual ICollection<ProjectIso> ProjectIsoCreatedBy { get; set; }
        [InverseProperty(nameof(ProjectIso.LastModifiedBy))]
        public virtual ICollection<ProjectIso> ProjectIsoLastModifiedBy { get; set; }
        [InverseProperty(nameof(ProjectLedger.CreatedBy))]
        public virtual ICollection<ProjectLedger> ProjectLedgerCreatedBy { get; set; }
        [InverseProperty(nameof(ProjectLedgerDetail.CreatedBy))]
        public virtual ICollection<ProjectLedgerDetail> ProjectLedgerDetailCreatedBy { get; set; }
        [InverseProperty(nameof(ProjectLedgerDetail.LastModifiedBy))]
        public virtual ICollection<ProjectLedgerDetail> ProjectLedgerDetailLastModifiedBy { get; set; }
        [InverseProperty(nameof(ProjectLedger.LastModifiedBy))]
        public virtual ICollection<ProjectLedger> ProjectLedgerLastModifiedBy { get; set; }
        [InverseProperty("RemarksBy")]
        public virtual ICollection<ProjectRemarksHistory> ProjectRemarksHistory { get; set; }
        [InverseProperty(nameof(ProjectSa8000.ApprovedBy))]
        public virtual ICollection<ProjectSa8000> ProjectSa8000ApprovedBy { get; set; }
        [InverseProperty(nameof(ProjectSa8000.CreatedBy))]
        public virtual ICollection<ProjectSa8000> ProjectSa8000CreatedBy { get; set; }
        [InverseProperty(nameof(ProjectSa8000.LastModifiedBy))]
        public virtual ICollection<ProjectSa8000> ProjectSa8000LastModifiedBy { get; set; }
        [InverseProperty(nameof(ProjectSlcp.ApprovedBy))]
        public virtual ICollection<ProjectSlcp> ProjectSlcpApprovedBy { get; set; }
        [InverseProperty(nameof(ProjectSlcp.CreatedBy))]
        public virtual ICollection<ProjectSlcp> ProjectSlcpCreatedBy { get; set; }
        [InverseProperty(nameof(ProjectSlcp.LastModifiedBy))]
        public virtual ICollection<ProjectSlcp> ProjectSlcpLastModifiedBy { get; set; }
        [InverseProperty(nameof(ProjectType.CreatedBy))]
        public virtual ICollection<ProjectType> ProjectTypeCreatedBy { get; set; }
        [InverseProperty(nameof(ProjectType.LastModifiedBy))]
        public virtual ICollection<ProjectType> ProjectTypeLastModifiedBy { get; set; }
        [InverseProperty("RemarksBy")]
        public virtual ICollection<QcHistory> QcHistory { get; set; }
        [InverseProperty(nameof(RequestOfSite.CreatedBy))]
        public virtual ICollection<RequestOfSite> RequestOfSiteCreatedBy { get; set; }
        [InverseProperty(nameof(RequestOfSite.LastModifiedBy))]
        public virtual ICollection<RequestOfSite> RequestOfSiteLastModifiedBy { get; set; }
        [InverseProperty(nameof(ResetPasswordAccount.CreatedBy))]
        public virtual ICollection<ResetPasswordAccount> ResetPasswordAccountCreatedBy { get; set; }
        [InverseProperty(nameof(ResetPasswordAccount.LastModifiedBy))]
        public virtual ICollection<ResetPasswordAccount> ResetPasswordAccountLastModifiedBy { get; set; }
        [InverseProperty(nameof(ResetPasswordAccount.User))]
        public virtual ICollection<ResetPasswordAccount> ResetPasswordAccountUser { get; set; }
        [InverseProperty(nameof(Risk.CreatedBy))]
        public virtual ICollection<Risk> RiskCreatedBy { get; set; }
        [InverseProperty(nameof(Risk.LastModifiedBy))]
        public virtual ICollection<Risk> RiskLastModifiedBy { get; set; }
        [InverseProperty("SecUser")]
        public virtual ICollection<SecUserInvalidAccess> SecUserInvalidAccess { get; set; }
        [InverseProperty("SecUser")]
        public virtual ICollection<SecUserPwdHistory> SecUserPwdHistory { get; set; }
        [InverseProperty("SecUser")]
        public virtual ICollection<SecUserSession> SecUserSession { get; set; }
        [InverseProperty(nameof(Section.CreatedBy))]
        public virtual ICollection<Section> SectionCreatedBy { get; set; }
        [InverseProperty(nameof(Section.LastModifiedBy))]
        public virtual ICollection<Section> SectionLastModifiedBy { get; set; }
        [InverseProperty(nameof(ServiceType.CreatedBy))]
        public virtual ICollection<ServiceType> ServiceTypeCreatedBy { get; set; }
        [InverseProperty(nameof(ServiceType.LastModifiedBy))]
        public virtual ICollection<ServiceType> ServiceTypeLastModifiedBy { get; set; }
        [InverseProperty(nameof(StageOfCertification.CreatedBy))]
        public virtual ICollection<StageOfCertification> StageOfCertificationCreatedBy { get; set; }
        [InverseProperty(nameof(StageOfCertification.LastModifiedBy))]
        public virtual ICollection<StageOfCertification> StageOfCertificationLastModifiedBy { get; set; }
        [InverseProperty(nameof(StandardType.CreatedBy))]
        public virtual ICollection<StandardType> StandardTypeCreatedBy { get; set; }
        [InverseProperty(nameof(StandardType.LastModifiedBy))]
        public virtual ICollection<StandardType> StandardTypeLastModifiedBy { get; set; }
        [InverseProperty(nameof(SurveillanceMethod.CreatedBy))]
        public virtual ICollection<SurveillanceMethod> SurveillanceMethodCreatedBy { get; set; }
        [InverseProperty(nameof(SurveillanceMethod.LastModifiedBy))]
        public virtual ICollection<SurveillanceMethod> SurveillanceMethodLastModifiedBy { get; set; }
        [InverseProperty(nameof(SurveillanceVisitFrequency.CreatedBy))]
        public virtual ICollection<SurveillanceVisitFrequency> SurveillanceVisitFrequencyCreatedBy { get; set; }
        [InverseProperty(nameof(SurveillanceVisitFrequency.LastModifiedBy))]
        public virtual ICollection<SurveillanceVisitFrequency> SurveillanceVisitFrequencyLastModifiedBy { get; set; }
        [InverseProperty(nameof(UserAcademic.ApprovedBy))]
        public virtual ICollection<UserAcademic> UserAcademicApprovedBy { get; set; }
        [InverseProperty(nameof(UserAcademic.CreatedBy))]
        public virtual ICollection<UserAcademic> UserAcademicCreatedBy { get; set; }
        [InverseProperty(nameof(UserAcademic.LastModifiedByNavigation))]
        public virtual ICollection<UserAcademic> UserAcademicLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(UserAcademic.User))]
        public virtual ICollection<UserAcademic> UserAcademicUser { get; set; }
        [InverseProperty(nameof(UserAudit.ApprovedByNavigation))]
        public virtual ICollection<UserAudit> UserAuditApprovedByNavigation { get; set; }
        [InverseProperty(nameof(UserAudit.CreatedByNavigation))]
        public virtual ICollection<UserAudit> UserAuditCreatedByNavigation { get; set; }
        [InverseProperty(nameof(UserAudit.LastModifiedByNavigation))]
        public virtual ICollection<UserAudit> UserAuditLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(UserAudit.User))]
        public virtual ICollection<UserAudit> UserAuditUser { get; set; }
        [InverseProperty(nameof(UserAuditorNace.ApprovedByNavigation))]
        public virtual ICollection<UserAuditorNace> UserAuditorNaceApprovedByNavigation { get; set; }
        [InverseProperty(nameof(UserAuditorNace.CreatedByNavigation))]
        public virtual ICollection<UserAuditorNace> UserAuditorNaceCreatedByNavigation { get; set; }
        [InverseProperty(nameof(UserAuditorNace.LastModifiedByNavigation))]
        public virtual ICollection<UserAuditorNace> UserAuditorNaceLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(UserAuditorNace.User))]
        public virtual ICollection<UserAuditorNace> UserAuditorNaceUser { get; set; }
        [InverseProperty(nameof(UserConsultancy.ApprovedByNavigation))]
        public virtual ICollection<UserConsultancy> UserConsultancyApprovedByNavigation { get; set; }
        [InverseProperty(nameof(UserConsultancy.CreatedByNavigation))]
        public virtual ICollection<UserConsultancy> UserConsultancyCreatedByNavigation { get; set; }
        [InverseProperty(nameof(UserConsultancy.LastModifiedByNavigation))]
        public virtual ICollection<UserConsultancy> UserConsultancyLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(UserConsultancy.User))]
        public virtual ICollection<UserConsultancy> UserConsultancyUser { get; set; }
        [InverseProperty(nameof(UserCpd.ApprovedByNavigation))]
        public virtual ICollection<UserCpd> UserCpdApprovedByNavigation { get; set; }
        [InverseProperty(nameof(UserCpd.CreatedByNavigation))]
        public virtual ICollection<UserCpd> UserCpdCreatedByNavigation { get; set; }
        [InverseProperty(nameof(UserCpd.LastModifiedByNavigation))]
        public virtual ICollection<UserCpd> UserCpdLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(UserCpd.User))]
        public virtual ICollection<UserCpd> UserCpdUser { get; set; }
        [InverseProperty(nameof(UserDeclaration.ApprovedByNavigation))]
        public virtual ICollection<UserDeclaration> UserDeclarationApprovedByNavigation { get; set; }
        [InverseProperty(nameof(UserDeclaration.CreatedByNavigation))]
        public virtual ICollection<UserDeclaration> UserDeclarationCreatedByNavigation { get; set; }
        [InverseProperty(nameof(UserDeclaration.User))]
        public virtual ICollection<UserDeclaration> UserDeclarationUser { get; set; }
        [InverseProperty(nameof(UserEmployment.ApprovedByNavigation))]
        public virtual ICollection<UserEmployment> UserEmploymentApprovedByNavigation { get; set; }
        [InverseProperty(nameof(UserEmployment.CreatedByNavigation))]
        public virtual ICollection<UserEmployment> UserEmploymentCreatedByNavigation { get; set; }
        [InverseProperty(nameof(UserEmployment.LastModifiedByNavigation))]
        public virtual ICollection<UserEmployment> UserEmploymentLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(UserEmployment.User))]
        public virtual ICollection<UserEmployment> UserEmploymentUser { get; set; }
        [InverseProperty(nameof(UserProfessional.ApprovedByNavigation))]
        public virtual ICollection<UserProfessional> UserProfessionalApprovedByNavigation { get; set; }
        [InverseProperty(nameof(UserProfessional.CreatedByNavigation))]
        public virtual ICollection<UserProfessional> UserProfessionalCreatedByNavigation { get; set; }
        [InverseProperty(nameof(UserProfessional.LastModifiedByNavigation))]
        public virtual ICollection<UserProfessional> UserProfessionalLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(UserProfessional.User))]
        public virtual ICollection<UserProfessional> UserProfessionalUser { get; set; }
        [InverseProperty(nameof(UserRemarks.RemarksBy))]
        public virtual ICollection<UserRemarks> UserRemarksRemarksBy { get; set; }
        [InverseProperty(nameof(UserRemarks.User))]
        public virtual ICollection<UserRemarks> UserRemarksUser { get; set; }
        [InverseProperty(nameof(UserStandards.ApprovedbyNavigation))]
        public virtual ICollection<UserStandards> UserStandardsApprovedbyNavigation { get; set; }
        [InverseProperty(nameof(UserStandards.CreatedByNavigation))]
        public virtual ICollection<UserStandards> UserStandardsCreatedByNavigation { get; set; }
        [InverseProperty(nameof(UserStandards.LastModifiedByNavigation))]
        public virtual ICollection<UserStandards> UserStandardsLastModifiedByNavigation { get; set; }
        [InverseProperty(nameof(UserStandards.User))]
        public virtual ICollection<UserStandards> UserStandardsUser { get; set; }
        [InverseProperty(nameof(VerificationType.CreatedBy))]
        public virtual ICollection<VerificationType> VerificationTypeCreatedBy { get; set; }
        [InverseProperty(nameof(VerificationType.LastUpdatedBy))]
        public virtual ICollection<VerificationType> VerificationTypeLastUpdatedBy { get; set; }
        [InverseProperty(nameof(VisitLevel.CreatedBy))]
        public virtual ICollection<VisitLevel> VisitLevelCreatedBy { get; set; }
        [InverseProperty(nameof(VisitLevel.LastUpdatedBy))]
        public virtual ICollection<VisitLevel> VisitLevelLastUpdatedBy { get; set; }
        public virtual ICollection<WorkProgressHistory> WorkProgressHistory { get; set; }

    }
}

