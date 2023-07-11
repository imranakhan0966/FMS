using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ozone.Infrastructure.Persistence.Models
{
    public partial class Ozone_Live_NewContext : DbContext
    {
        public Ozone_Live_NewContext()
        {
        }

        public Ozone_Live_NewContext(DbContextOptions<Ozone_Live_NewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accreditation> Accreditation { get; set; }
        public virtual DbSet<Active> Active { get; set; }
        public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        public virtual DbSet<ApplicationType> ApplicationType { get; set; }
        public virtual DbSet<ApprovalStatus> ApprovalStatus { get; set; }
        public virtual DbSet<AssessmentCompleted> AssessmentCompleted { get; set; }
        public virtual DbSet<AuditDocumentsType> AuditDocumentsType { get; set; }
        public virtual DbSet<AuditReport> AuditReport { get; set; }
        public virtual DbSet<AuditReportDetail> AuditReportDetail { get; set; }
        public virtual DbSet<AuditReportHistory> AuditReportHistory { get; set; }
        public virtual DbSet<AuditReportMaster> AuditReportMaster { get; set; }
        public virtual DbSet<AuditType> AuditType { get; set; }
        public virtual DbSet<AuditorTypes> AuditorTypes { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<CertificationBody> CertificationBody { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientAuditVisit> ClientAuditVisit { get; set; }
        public virtual DbSet<ClientProjects> ClientProjects { get; set; }
        public virtual DbSet<ClientSites> ClientSites { get; set; }
        public virtual DbSet<CompletedModule> CompletedModule { get; set; }
        public virtual DbSet<CompletedSteps> CompletedSteps { get; set; }
        public virtual DbSet<Consultant> Consultant { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CourseType> CourseType { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Eacode> Eacode { get; set; }
        public virtual DbSet<EffluentTreatmentPlant> EffluentTreatmentPlant { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<HolidayCalendar> HolidayCalendar { get; set; }
        public virtual DbSet<HolidayType> HolidayType { get; set; }
        public virtual DbSet<Legislation> Legislation { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<Methodology> Methodology { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleShare> ModuleShare { get; set; }
        public virtual DbSet<ModuleVersion> ModuleVersion { get; set; }
        public virtual DbSet<NaceCode> NaceCode { get; set; }
        public virtual DbSet<OrgCertification> OrgCertification { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<Prifix> Prifix { get; set; }
        public virtual DbSet<ProjectAmount> ProjectAmount { get; set; }
        public virtual DbSet<ProjectFormsPath> ProjectFormsPath { get; set; }
        public virtual DbSet<ProjectHigg> ProjectHigg { get; set; }
        public virtual DbSet<ProjectIso> ProjectIso { get; set; }
        public virtual DbSet<ProjectLedger> ProjectLedger { get; set; }
        public virtual DbSet<ProjectLedgerDetail> ProjectLedgerDetail { get; set; }
        public virtual DbSet<ProjectRemarksHistory> ProjectRemarksHistory { get; set; }
        public virtual DbSet<ProjectSa8000> ProjectSa8000 { get; set; }
        public virtual DbSet<ProjectSlcp> ProjectSlcp { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }
        public virtual DbSet<ProjectsApprovalStatus> ProjectsApprovalStatus { get; set; }
        public virtual DbSet<QcHistory> QcHistory { get; set; }
        public virtual DbSet<QcMasterComments> QcMasterComments { get; set; }
        public virtual DbSet<QcStatus> QcStatus { get; set; }
        public virtual DbSet<QcdocumentsList> QcdocumentsList { get; set; }
        public virtual DbSet<RequestOfSite> RequestOfSite { get; set; }
        public virtual DbSet<ResetPasswordAccount> ResetPasswordAccount { get; set; }
        public virtual DbSet<Risk> Risk { get; set; }
        public virtual DbSet<SecForm> SecForm { get; set; }
        public virtual DbSet<SecPolicy> SecPolicy { get; set; }
        public virtual DbSet<SecRole> SecRole { get; set; }
        public virtual DbSet<SecRoleForm> SecRoleForm { get; set; }
        public virtual DbSet<SecUser> SecUser { get; set; }
        public virtual DbSet<SecUserInvalidAccess> SecUserInvalidAccess { get; set; }
        public virtual DbSet<SecUserPwdHistory> SecUserPwdHistory { get; set; }
        public virtual DbSet<SecUserSession> SecUserSession { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<StageOfCertification> StageOfCertification { get; set; }
        public virtual DbSet<StandardType> StandardType { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<SurveillanceMethod> SurveillanceMethod { get; set; }
        public virtual DbSet<SurveillanceVisitFrequency> SurveillanceVisitFrequency { get; set; }
        public virtual DbSet<UserAcademic> UserAcademic { get; set; }
        public virtual DbSet<UserAudit> UserAudit { get; set; }
        public virtual DbSet<UserAuditorNace> UserAuditorNace { get; set; }
        public virtual DbSet<UserConsultancy> UserConsultancy { get; set; }
        public virtual DbSet<UserCpd> UserCpd { get; set; }
        public virtual DbSet<UserDeclaration> UserDeclaration { get; set; }
        public virtual DbSet<UserEmployment> UserEmployment { get; set; }
        public virtual DbSet<UserProfessional> UserProfessional { get; set; }
        public virtual DbSet<UserRemarks> UserRemarks { get; set; }
        public virtual DbSet<UserStandards> UserStandards { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<VerificationType> VerificationType { get; set; }
        public virtual DbSet<VisitStatus> VisitStatus { get; set; }
        public virtual DbSet<VisitType> VisitType { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PE36NEL;Initial Catalog=Ozone_Live_New;user id=farooq;password=123qwe;integrated security=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Accreditation>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AccreditationCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Accreditation_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.AccreditationLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Accreditation_SecUser1");
            });

            modelBuilder.Entity<Active>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.HasOne(d => d.Form)
                    .WithMany(p => p.ActivityLog)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActivityLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AssessmentCompleted>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AssessmentCompletedCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_AssessmentCompleted_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.AssessmentCompletedLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_AssessmentCompleted_SecUser1");
            });

            modelBuilder.Entity<AuditDocumentsType>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AuditDocumentsTypeCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_AuditDocumentsType_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.AuditDocumentsTypeLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_AuditDocumentsType_SecUser1");
            });

            modelBuilder.Entity<AuditReport>(entity =>
            {
                entity.HasOne(d => d.AuditDocumentType)
                    .WithMany(p => p.AuditReport)
                    .HasForeignKey(d => d.AuditDocumentTypeId)
                    .HasConstraintName("FK_AuditReport_AuditDocumentsType");

                entity.HasOne(d => d.AuditVisit)
                    .WithMany(p => p.AuditReport)
                    .HasForeignKey(d => d.AuditVisitId)
                    .HasConstraintName("FK_AuditReport_ClientAuditVisit");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AuditReportCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_AuditReport_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.AuditReportLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_AuditReport_SecUser1");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AuditReport)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_AuditReport_ClientProjects");
            });

            modelBuilder.Entity<AuditReportDetail>(entity =>
            {
                entity.HasOne(d => d.AuditDocumentType)
                    .WithMany(p => p.AuditReportDetail)
                    .HasForeignKey(d => d.AuditDocumentTypeId)
                    .HasConstraintName("FK_AuditReportDetail_AuditDocumentsType");

                entity.HasOne(d => d.AuditReportMaster)
                    .WithMany(p => p.AuditReportDetail)
                    .HasForeignKey(d => d.AuditReportMasterId)
                    .HasConstraintName("FK_AuditReportDetail_AuditReportMaster");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AuditReportDetailCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_AuditReportDetail_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.AuditReportDetailLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_AuditReportDetail_SecUser1");
            });

            modelBuilder.Entity<AuditReportHistory>(entity =>
            {
                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.AuditReportHistory)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_AuditReportHistory_ApprovalStatus");

                entity.HasOne(d => d.AuditReport)
                    .WithMany(p => p.AuditReportHistory)
                    .HasForeignKey(d => d.AuditReportId)
                    .HasConstraintName("FK_AuditReportHistory_AuditReport");

                entity.HasOne(d => d.RemarksBy)
                    .WithMany(p => p.AuditReportHistory)
                    .HasForeignKey(d => d.RemarksById)
                    .HasConstraintName("FK_AuditReportHistory_SecUser1");
            });

            modelBuilder.Entity<AuditReportMaster>(entity =>
            {
                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.AuditReportMaster)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_AuditReportMaster_ApprovalStatus");

                entity.HasOne(d => d.ClientAuditVisit)
                    .WithMany(p => p.AuditReportMaster)
                    .HasForeignKey(d => d.ClientAuditVisitId)
                    .HasConstraintName("FK_AuditReportMaster_ClientAuditVisit");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AuditReportMasterCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_AuditReportMaster_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.AuditReportMasterLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_AuditReportMaster_SecUser1");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AuditReportMaster)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_AuditReportMaster_ClientProjects");
            });

            modelBuilder.Entity<CertificationBody>(entity =>
            {
                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CertificationBodyCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CertificationBody_SecUser");

                entity.HasOne(d => d.LastModifiedyNavigation)
                    .WithMany(p => p.CertificationBodyLastModifiedyNavigation)
                    .HasForeignKey(d => d.LastModifiedy)
                    .HasConstraintName("FK_CertificationBody_SecUser1");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Cities_Countries");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Cities_State");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Website).IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Client_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Client_Countries");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_Client_Organization");

                entity.HasOne(d => d.Prefix)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.PrefixId)
                    .HasConstraintName("FK_Client_Prifix");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__Client__StateId__19DFD96B");
            });

            modelBuilder.Entity<ClientAuditVisit>(entity =>
            {
                entity.HasOne(d => d.Auditor1)
                    .WithMany(p => p.ClientAuditVisitAuditor1)
                    .HasForeignKey(d => d.Auditor1Id)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser3");

                entity.HasOne(d => d.Auditor2)
                    .WithMany(p => p.ClientAuditVisitAuditor2)
                    .HasForeignKey(d => d.Auditor2Id)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser4");

                entity.HasOne(d => d.Auditor3)
                    .WithMany(p => p.ClientAuditVisitAuditor3)
                    .HasForeignKey(d => d.Auditor3Id)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser5");

                entity.HasOne(d => d.Auditor4)
                    .WithMany(p => p.ClientAuditVisitAuditor4)
                    .HasForeignKey(d => d.Auditor4Id)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser6");

                entity.HasOne(d => d.Auditor5)
                    .WithMany(p => p.ClientAuditVisitAuditor5)
                    .HasForeignKey(d => d.Auditor5Id)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser7");

                entity.HasOne(d => d.JustifiedPerson)
                    .WithMany(p => p.ClientAuditVisitJustifiedPerson)
                    .HasForeignKey(d => d.JustifiedPersonId)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser");

                entity.HasOne(d => d.LeadAuditor)
                    .WithMany(p => p.ClientAuditVisitLeadAuditor)
                    .HasForeignKey(d => d.LeadAuditorId)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser2");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.ClientAuditVisit)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_ClientAuditVisit_Organization");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ClientAuditVisit)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ClientAuditVisit_ClientProjects");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.ClientAuditVisitReviewer)
                    .HasForeignKey(d => d.ReviewerId)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser8");

                entity.HasOne(d => d.TechnicalExpert)
                    .WithMany(p => p.ClientAuditVisitTechnicalExpert)
                    .HasForeignKey(d => d.TechnicalExpertId)
                    .HasConstraintName("FK_ClientAuditVisit_SecUser1");

                entity.HasOne(d => d.VisitStatus)
                    .WithMany(p => p.ClientAuditVisit)
                    .HasForeignKey(d => d.VisitStatusId)
                    .HasConstraintName("FK_ClientAuditVisit_VisitStatus");

                entity.HasOne(d => d.VisitType)
                    .WithMany(p => p.ClientAuditVisit)
                    .HasForeignKey(d => d.VisitTypeId)
                    .HasConstraintName("FK_ClientAuditVisit_VisitType");
            });

            modelBuilder.Entity<ClientProjects>(entity =>
            {
                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.ClientProjects)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_ClientProjects_ApprovalStatus");

                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.ClientProjectsApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_ClientProjects_SecUser");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientProjects)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_ClientProjects_Client");

                entity.HasOne(d => d.ClientSite)
                    .WithMany(p => p.ClientProjects)
                    .HasForeignKey(d => d.ClientSiteId)
                    .HasConstraintName("FK_ClientProjects_ClientSites");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ClientProjectsCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ClientProjects_SecUser1");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ClientProjectsLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ClientProjects_SecUser2");

                entity.HasOne(d => d.ProjectAmount)
                    .WithMany(p => p.ClientProjects)
                    .HasForeignKey(d => d.ProjectAmountId)
                    .HasConstraintName("FK_ClientProjects_ProjectAmount");

                entity.HasOne(d => d.ProjectType)
                    .WithMany(p => p.ClientProjects)
                    .HasForeignKey(d => d.ProjectTypeId)
                    .HasConstraintName("FK_ClientProjects_ProjectType");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.ClientProjects)
                    .HasForeignKey(d => d.StandardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientProjects_Certification");

                entity.HasOne(d => d.VerificationType)
                    .WithMany(p => p.ClientProjects)
                    .HasForeignKey(d => d.VerificationTypeId)
                    .HasConstraintName("FK_ClientProjects_VerificationType");
            });

            modelBuilder.Entity<ClientSites>(entity =>
            {
                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.ClientSitesApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_ClientSites_SecUser");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ClientSites)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_ClientSites_Cities");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSites)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientSites_Client");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ClientSites)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_ClientSites_Countries");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ClientSitesCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ClientSites_SecUser1");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ClientSitesLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ClientSites_SecUser2");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.ClientSites)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_ClientSites_State");
            });

            modelBuilder.Entity<CompletedModule>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.CompletedModuleCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_CompletedModule_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.CompletedModuleLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_CompletedModule_SecUser1");
            });

            modelBuilder.Entity<Consultant>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Consultant)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Consultant_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Consultant)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Consultant_Countries");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ConsultantCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Consultant_SecUser1");

                entity.HasOne(d => d.LastUpdated)
                    .WithMany(p => p.ConsultantLastUpdated)
                    .HasForeignKey(d => d.LastUpdatedId)
                    .HasConstraintName("FK_Consultant_SecUser");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Consultant)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_Consultant_Organization");

                entity.HasOne(d => d.Prefix)
                    .WithMany(p => p.Consultant)
                    .HasForeignKey(d => d.PrefixId)
                    .HasConstraintName("FK_Consultant_Prifix");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Consultant)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Consultant_State");
            });

            modelBuilder.Entity<EffluentTreatmentPlant>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.EffluentTreatmentPlantCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_EffluentTreatmentPlant_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.EffluentTreatmentPlantLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_EffluentTreatmentPlant_SecUser1");
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ExpensesCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Expenses_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ExpensesLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Expenses_SecUser1");
            });

            modelBuilder.Entity<HolidayCalendar>(entity =>
            {
                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.HolidayCalendarCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_HolidayCalendar_SecUser1");

                entity.HasOne(d => d.HolidayType)
                    .WithMany(p => p.HolidayCalendar)
                    .HasForeignKey(d => d.HolidayTypeId)
                    .HasConstraintName("FK_HolidayCalendar_HolidayType");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.HolidayCalendarLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_HolidayCalendar_SecUser");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.HolidayCalendar)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_HolidayCalendar_Organization");
            });

            modelBuilder.Entity<Legislation>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Legislation)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Legislation_Countries");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.LegislationCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Legislation_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.LegislationLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Legislation_SecUser1");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.HasOne(d => d.Certification)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.CertificationId)
                    .HasConstraintName("FK_Library_Certification");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_Library_DocumentType");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_Library_Module");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK__Library__Organiz__6EF57B66");

                entity.HasOne(d => d.ReviewerNavigation)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.Reviewer)
                    .HasConstraintName("FK_Library_SecUser");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Library)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Library_Status");
            });

            modelBuilder.Entity<Methodology>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.MethodologyCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Methodology_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.MethodologyLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Methodology_SecUser1");
            });

            modelBuilder.Entity<ModuleShare>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ModuleShareCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ModuleShare_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ModuleShareLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ModuleShare_SecUser1");
            });

            modelBuilder.Entity<ModuleVersion>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ModuleVersionCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ModuleVersion_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ModuleVersionLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ModuleVersion_SecUser1");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.ModuleVersion)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_ModuleVersion_Certification");
            });

            modelBuilder.Entity<OrgCertification>(entity =>
            {
                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.OrgCertification)
                    .HasForeignKey(d => d.AgencyId)
                    .HasConstraintName("FK_OrgCertification_Organization");

                entity.HasOne(d => d.Certification)
                    .WithMany(p => p.OrgCertification)
                    .HasForeignKey(d => d.CertificationId)
                    .HasConstraintName("FK_OrgCertification_Certification");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Organization_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Organization_Countries");

                entity.HasOne(d => d.OrganizationType)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.OrganizationTypeId)
                    .HasConstraintName("FK_Organization_Organization");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__Organizat__State__6FE99F9F");
            });

            modelBuilder.Entity<ProjectAmount>(entity =>
            {
                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProjectAmountCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_ProjectAmount_SecUser1");

                entity.HasOne(d => d.Lastupdated)
                    .WithMany(p => p.ProjectAmountLastupdated)
                    .HasForeignKey(d => d.LastupdatedId)
                    .HasConstraintName("FK_ProjectAmount_SecUser");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.ProjectAmount)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_ProjectAmount_Organization");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.ProjectAmount)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_ProjectAmount_Certification");
            });

            modelBuilder.Entity<ProjectFormsPath>(entity =>
            {
                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.ProjectFormsPath)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_ProjectFormsPath_Certification");
            });

            modelBuilder.Entity<ProjectHigg>(entity =>
            {
                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.ProjectHiggApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_ProjectHigg_SecUser3");

                entity.HasOne(d => d.AssessmentCompleted)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.AssessmentCompletedId)
                    .HasConstraintName("FK_ProjectHigg_AssessmentCompleted");

                entity.HasOne(d => d.ClientProject)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.ClientProjectId)
                    .HasConstraintName("FK_ProjectHigg_ClientProjects");

                entity.HasOne(d => d.CompletedModule)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.CompletedModuleId)
                    .HasConstraintName("FK_ProjectHigg_CompletedModule");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectHiggCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ProjectHigg_SecUser1");

                entity.HasOne(d => d.EffluentTreatmentPlant)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.EffluentTreatmentPlantId)
                    .HasConstraintName("FK_ProjectHigg_EffluentTreatmentPlant");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProjectHiggLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ProjectHigg_SecUser2");

                entity.HasOne(d => d.Methodology)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.MethodologyId)
                    .HasConstraintName("FK_ProjectHigg_Methodology");

                entity.HasOne(d => d.ModuleShare)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.ModuleShareId)
                    .HasConstraintName("FK_ProjectHigg_ModuleShare");

                entity.HasOne(d => d.ModuleVersion)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.ModuleVersionId)
                    .HasConstraintName("FK_ProjectHigg_ModuleVersion");

                entity.HasOne(d => d.RequestOfSite)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.RequestOfSiteId)
                    .HasConstraintName("FK_ProjectHigg_RequestOfSite");

                entity.HasOne(d => d.ServicesType)
                    .WithMany(p => p.ProjectHigg)
                    .HasForeignKey(d => d.ServicesTypeId)
                    .HasConstraintName("FK_ProjectHigg_ServiceType");
            });

            modelBuilder.Entity<ProjectIso>(entity =>
            {
                entity.HasOne(d => d.AccreditationNavigation)
                    .WithMany(p => p.ProjectIso)
                    .HasForeignKey(d => d.AccreditationId)
                    .HasConstraintName("FK_ProjectISO_Accreditation");

                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.ProjectIsoApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_ProjectISO_SecUser3");

                entity.HasOne(d => d.ClientProject)
                    .WithMany(p => p.ProjectIso)
                    .HasForeignKey(d => d.ClientProjectId)
                    .HasConstraintName("FK_ProjectISO_ClientProjects");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectIsoCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ProjectISO_SecUser1");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProjectIsoLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ProjectISO_SecUser2");

                entity.HasOne(d => d.StageCertificationNavigation)
                    .WithMany(p => p.ProjectIso)
                    .HasForeignKey(d => d.StageCertification)
                    .HasConstraintName("FK_ProjectISO_StageOfCertification");
            });

            modelBuilder.Entity<ProjectLedger>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectLedgerCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ProjectLedger_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProjectLedgerLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ProjectLedger_SecUser1");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectLedger)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectLedger_ClientProjects");
            });

            modelBuilder.Entity<ProjectLedgerDetail>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectLedgerDetailCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ProjectLedgerDetail_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProjectLedgerDetailLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ProjectLedgerDetail_SecUser1");

                entity.HasOne(d => d.ProjectLedgerMaster)
                    .WithMany(p => p.ProjectLedgerDetail)
                    .HasForeignKey(d => d.ProjectLedgerMasterId)
                    .HasConstraintName("FK_ProjectLedgerDetail_ProjectLedger");
            });

            modelBuilder.Entity<ProjectRemarksHistory>(entity =>
            {
                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.ProjectRemarksHistory)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_ProjectRemarksHistory_ProjectsApprovalStatus");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectRemarksHistory)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectRemarksHistory_ClientProjects");

                entity.HasOne(d => d.RemarksBy)
                    .WithMany(p => p.ProjectRemarksHistory)
                    .HasForeignKey(d => d.RemarksById)
                    .HasConstraintName("FK_ProjectRemarksHistory_SecUser");
            });

            modelBuilder.Entity<ProjectSa8000>(entity =>
            {
                entity.HasOne(d => d.Accreditation)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.AccreditationId)
                    .HasConstraintName("FK_Project_SA8000_Accreditation");

                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.ProjectSa8000ApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_Project_SA8000_SecUser3");

                entity.HasOne(d => d.ClientProject)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.ClientProjectId)
                    .HasConstraintName("FK_Project_SA8000_ClientProjects");

                entity.HasOne(d => d.Consultant)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.ConsultantId)
                    .HasConstraintName("FK_Project_SA8000_Consultant");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectSa8000CreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Project_SA8000_SecUser1");

                entity.HasOne(d => d.Eacode)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.EacodeId)
                    .HasConstraintName("FK_Project_SA8000_EACode");

                entity.HasOne(d => d.Expenses)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.ExpensesId)
                    .HasConstraintName("FK_Project_SA8000_Expenses");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProjectSa8000LastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Project_SA8000_SecUser2");

                entity.HasOne(d => d.NaceCode)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.NaceCodeId)
                    .HasConstraintName("FK_Project_SA8000_NaceCode");

                entity.HasOne(d => d.Risk)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.RiskId)
                    .HasConstraintName("FK_Project_SA8000_Risk");

                entity.HasOne(d => d.SurveillanceMethod)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.SurveillanceMethodId)
                    .HasConstraintName("FK_Project_SA8000_SurveillanceMethod");

                entity.HasOne(d => d.SurveillanceVisitFrequency)
                    .WithMany(p => p.ProjectSa8000)
                    .HasForeignKey(d => d.SurveillanceVisitFrequencyId)
                    .HasConstraintName("FK_Project_SA8000_SurveillanceVisitFrequency");
            });

            modelBuilder.Entity<ProjectSlcp>(entity =>
            {
                entity.HasOne(d => d.Accreditation)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.AccreditationId)
                    .HasConstraintName("FK_ProjectSLCP_Accreditation");

                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.ProjectSlcpApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_ProjectSLCP_SecUser3");

                entity.HasOne(d => d.AssessmentCompleted)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.AssessmentCompletedId)
                    .HasConstraintName("FK_ProjectSLCP_AssessmentCompleted");

                entity.HasOne(d => d.ClientProject)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.ClientProjectId)
                    .HasConstraintName("FK_ProjectSLCP_ClientProjects");

                entity.HasOne(d => d.CompletedStep)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.CompletedStepId)
                    .HasConstraintName("FK_ProjectSLCP_CompletedSteps");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectSlcpCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ProjectSLCP_SecUser1");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProjectSlcpLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ProjectSLCP_SecUser2");

                entity.HasOne(d => d.Methodology)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.MethodologyId)
                    .HasConstraintName("FK_ProjectSLCP_Methodology");

                entity.HasOne(d => d.ModuleShare)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.ModuleShareId)
                    .HasConstraintName("FK_ProjectSLCP_ModuleShare");

                entity.HasOne(d => d.ModuleVersion)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.ModuleVersionId)
                    .HasConstraintName("FK_ProjectSLCP_ModuleVersion");

                entity.HasOne(d => d.RequestOfSite)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.RequestOfSiteId)
                    .HasConstraintName("FK_ProjectSLCP_RequestOfSite");

                entity.HasOne(d => d.ServicesType)
                    .WithMany(p => p.ProjectSlcp)
                    .HasForeignKey(d => d.ServicesTypeId)
                    .HasConstraintName("FK_ProjectSLCP_ServiceType");
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ProjectTypeCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ProjectType_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ProjectTypeLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ProjectType_SecUser1");
            });

            modelBuilder.Entity<ProjectsApprovalStatus>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ProjectsApprovalStatus)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_ProjectsApprovalStatus_SecRole");
            });

            modelBuilder.Entity<QcHistory>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.QcHistory)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_QcHistory_ClientProjects");

                entity.HasOne(d => d.QcdocumentsList)
                    .WithMany(p => p.QcHistory)
                    .HasForeignKey(d => d.QcdocumentsListId)
                    .HasConstraintName("FK_QcHistory_QCDocumentsList");

                entity.HasOne(d => d.RemarksBy)
                    .WithMany(p => p.QcHistory)
                    .HasForeignKey(d => d.RemarksById)
                    .HasConstraintName("FK_QcHistory_SecUser");
            });

            modelBuilder.Entity<QcMasterComments>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.QcMasterComments)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_QcMasterComments_ClientProjects");

                entity.HasOne(d => d.QcDocuments)
                    .WithMany(p => p.QcMasterComments)
                    .HasForeignKey(d => d.QcDocumentsId)
                    .HasConstraintName("FK_QcMasterComments_QCDocumentsList");

                entity.HasOne(d => d.QcStatus)
                    .WithMany(p => p.QcMasterComments)
                    .HasForeignKey(d => d.QcStatusId)
                    .HasConstraintName("FK_QcMasterComments_QcStatus");
            });

            modelBuilder.Entity<QcdocumentsList>(entity =>
            {
                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.QcdocumentsList)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_QCDocumentsList_Organization");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.QcdocumentsList)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_QCDocumentsList_Certification");
            });

            modelBuilder.Entity<RequestOfSite>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.RequestOfSiteCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_RequestOfSite_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.RequestOfSiteLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_RequestOfSite_SecUser1");
            });

            modelBuilder.Entity<ResetPasswordAccount>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ResetPasswordAccountCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ResetPasswordAccount_ResetPasswordAccount");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ResetPasswordAccountLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ResetPasswordAccount_SecUser");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.ResetPasswordAccount)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_ResetPasswordAccount_Organaization");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ResetPasswordAccountUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ResetPasswordAccount_SecUser2");
            });

            modelBuilder.Entity<Risk>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.RiskCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Risk_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.RiskLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Risk_SecUser1");
            });

            modelBuilder.Entity<SecRoleForm>(entity =>
            {
                entity.Property(e => e.SbpAllowed).HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.SecRoleForm)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SecRoleForm)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SecUser>(entity =>
            {
                entity.HasOne(d => d.ApprovelStatus)
                    .WithMany(p => p.SecUser)
                    .HasForeignKey(d => d.ApprovelStatusId)
                    .HasConstraintName("FK__SecUser__Approve__7FB5F314");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.SecUser)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_SecUser_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.SecUser)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_SecUser_Countries");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.SecUser)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK__SecUser__Organiz__6E01572D");

                entity.HasOne(d => d.Prefix)
                    .WithMany(p => p.SecUser)
                    .HasForeignKey(d => d.PrefixId)
                    .HasConstraintName("FK_SecUser_Prifix");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.SecUser)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_SecUser_State");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.SecUser)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_SecUser_UserType");
            });

            modelBuilder.Entity<SecUserPwdHistory>(entity =>
            {
                entity.HasOne(d => d.SecUser)
                    .WithMany(p => p.SecUserPwdHistory)
                    .HasForeignKey(d => d.SecUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SecUserSession>(entity =>
            {
                entity.HasOne(d => d.SecUser)
                    .WithMany(p => p.SecUserSession)
                    .HasForeignKey(d => d.SecUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.SectionCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_Section_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.SectionLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_Section_SecUser1");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ServiceTypeCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_ServiceType_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.ServiceTypeLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_ServiceType_SecUser1");
            });

            modelBuilder.Entity<StageOfCertification>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.StageOfCertificationCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_StageOfCertification_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.StageOfCertificationLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_StageOfCertification_SecUser1");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.StageOfCertification)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_StageOfCertification_Certification");
            });

            modelBuilder.Entity<StandardType>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.StandardTypeCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_StandardType_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.StandardTypeLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_StandardType_SecUser1");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_State_Countries");
            });

            modelBuilder.Entity<SurveillanceMethod>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.SurveillanceMethodCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_SurveillanceMethod_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.SurveillanceMethodLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_SurveillanceMethod_SecUser1");
            });

            modelBuilder.Entity<SurveillanceVisitFrequency>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.SurveillanceVisitFrequencyCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_SurveillanceVisitFrequency_SecUser");

                entity.HasOne(d => d.LastModifiedBy)
                    .WithMany(p => p.SurveillanceVisitFrequencyLastModifiedBy)
                    .HasForeignKey(d => d.LastModifiedById)
                    .HasConstraintName("FK_SurveillanceVisitFrequency_SecUser1");
            });

            modelBuilder.Entity<UserAcademic>(entity =>
            {
                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.UserAcademicApprovedBy)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_UserAcademic_SecUser");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.UserAcademicCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_UserAcademic_SecUser1");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.UserAcademicLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_UserAcademic_SecUser2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAcademicUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAcademic_SecUser3");
            });

            modelBuilder.Entity<UserAudit>(entity =>
            {
                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.UserAuditApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_UserAudit_SecUser");

                entity.HasOne(d => d.AuditType)
                    .WithMany(p => p.UserAudit)
                    .HasForeignKey(d => d.AuditTypeId)
                    .HasConstraintName("FK_UserAudit_AuditType");

                entity.HasOne(d => d.CertificationBody)
                    .WithMany(p => p.UserAudit)
                    .HasForeignKey(d => d.CertificationBodyId)
                    .HasConstraintName("FK_UserAudit_CertificationBody");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserAuditCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserAudit_SecUser1");

                entity.HasOne(d => d.Eacode)
                    .WithMany(p => p.UserAudit)
                    .HasForeignKey(d => d.EacodeId)
                    .HasConstraintName("FK_UserAudit_EACode");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.UserAuditLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_UserAudit_SecUser2");

                entity.HasOne(d => d.NaceCode)
                    .WithMany(p => p.UserAudit)
                    .HasForeignKey(d => d.NaceCodeId)
                    .HasConstraintName("FK_UserAudit_NaceCode");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.UserAudit)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_UserAudit_Certification");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAuditUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserAudit_SecUser3");
            });

            modelBuilder.Entity<UserAuditorNace>(entity =>
            {
                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.UserAuditorNace)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_UserAuditorNace_ApprovalStatus");

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.UserAuditorNaceApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_UserAuditorNace_SecUser");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserAuditorNaceCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserAuditorNace_SecUser1");

                entity.HasOne(d => d.Eacode)
                    .WithMany(p => p.UserAuditorNace)
                    .HasForeignKey(d => d.EacodeId)
                    .HasConstraintName("FK_UserAuditorNace_EACode");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.UserAuditorNaceLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_UserAuditorNace_SecUser2");

                entity.HasOne(d => d.NaceCode)
                    .WithMany(p => p.UserAuditorNace)
                    .HasForeignKey(d => d.NaceCodeId)
                    .HasConstraintName("FK_UserAuditorNace_NaceCode");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.UserAuditorNace)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_UserAuditorNace_Certification");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAuditorNaceUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserAuditorNace_SecUser3");
            });

            modelBuilder.Entity<UserConsultancy>(entity =>
            {
                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.UserConsultancyApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_UserConsultancy_SecUser");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserConsultancyCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserConsultancy_SecUser1");

                entity.HasOne(d => d.Eacode)
                    .WithMany(p => p.UserConsultancy)
                    .HasForeignKey(d => d.EacodeId)
                    .HasConstraintName("FK_UserConsultancy_EACode");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.UserConsultancyLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_UserConsultancy_SecUser2");

                entity.HasOne(d => d.NaceCode)
                    .WithMany(p => p.UserConsultancy)
                    .HasForeignKey(d => d.NaceCodeId)
                    .HasConstraintName("FK_UserConsultancy_NaceCode");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.UserConsultancy)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_UserConsultancy_Certification");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserConsultancyUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserConsultancy_SecUser3");
            });

            modelBuilder.Entity<UserCpd>(entity =>
            {
                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.UserCpdApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_UserCPD_SecUser");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserCpdCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserCPD_SecUser1");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.UserCpdLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_UserCPD_SecUser2");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.UserCpd)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_UserCPD_Certification");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCpdUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserCPD_SecUser3");
            });

            modelBuilder.Entity<UserDeclaration>(entity =>
            {
                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.UserDeclaration)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_UserDeclaration_ApprovalStatus");

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.UserDeclarationApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_UserDeclaration_SecUser");

                entity.HasOne(d => d.ContractType)
                    .WithMany(p => p.UserDeclaration)
                    .HasForeignKey(d => d.ContractTypeId)
                    .HasConstraintName("FK_UserDeclaration_UserDeclaration");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserDeclarationCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserDeclaration_SecUser1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDeclarationUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserDeclaration_SecUser2");
            });

            modelBuilder.Entity<UserEmployment>(entity =>
            {
                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.UserEmploymentApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_UserEmployment_SecUser");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserEmploymentCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserEmployment_SecUser1");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.UserEmploymentLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_UserEmployment_SecUser2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEmploymentUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserEmployment_SecUser3");
            });

            modelBuilder.Entity<UserProfessional>(entity =>
            {
                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.UserProfessionalApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_UserProfessional_SecUser");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserProfessionalCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserProfessional_SecUser1");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.UserProfessionalLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_UserProfessional_SecUser2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfessionalUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserProfessional_SecUser3");
            });

            modelBuilder.Entity<UserRemarks>(entity =>
            {
                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.UserRemarks)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_UserRemarks_ApprovalStatus");

                entity.HasOne(d => d.RemarksBy)
                    .WithMany(p => p.UserRemarksRemarksBy)
                    .HasForeignKey(d => d.RemarksById)
                    .HasConstraintName("FK_UserRemarks_SecUser1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRemarksUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRemarks_SecUser");
            });

            modelBuilder.Entity<UserStandards>(entity =>
            {
                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.UserStandards)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK_UserStandards_ApprovalStatus");

                entity.HasOne(d => d.ApprovedbyNavigation)
                    .WithMany(p => p.UserStandardsApprovedbyNavigation)
                    .HasForeignKey(d => d.Approvedby)
                    .HasConstraintName("FK_UserStandards_SecUser");

                entity.HasOne(d => d.AuditorType)
                    .WithMany(p => p.UserStandards)
                    .HasForeignKey(d => d.AuditorTypeId)
                    .HasConstraintName("FK_UserStandards_Auditor Types");

                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.UserStandards)
                    .HasForeignKey(d => d.CourseTypeId)
                    .HasConstraintName("FK_UserStandards_CourseType");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserStandardsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserStandards_SecUser1");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.UserStandardsLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_UserStandards_SecUser2");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.UserStandards)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_UserStandards_Certification");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserStandardsUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserStandards_SecUser3");
            });

            modelBuilder.Entity<VerificationType>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.VerificationTypeCreatedBy)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK_VerificationType_SecUser");

                entity.HasOne(d => d.LastUpdatedBy)
                    .WithMany(p => p.VerificationTypeLastUpdatedBy)
                    .HasForeignKey(d => d.LastUpdatedById)
                    .HasConstraintName("FK_VerificationType_SecUser1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
