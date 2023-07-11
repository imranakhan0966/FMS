using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Ozone.Application.Interfaces.Repositories;
//using Ozone.Infrastructure.Persistence.Contexts;
//using Ozone.Infrastructure.Persistence.Repositories;
//using Ozone.Infrastructure.Persistence.Repository;
//using Ozone.Application.Interfaces;
//using Ozone.Application.Helpers;
//using Ozone.Application.Interfaces.Setup;
using System;
//using Ozone.Domain.Entities;
//using Ozone.Application.Interfaces.Encashment;
//using Ozone.Infrastructure.Persistence.Repositories.Setup;
using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Ozone.Application;
//using Ozone.Application.Interfaces.Service;
//using Ozone.Application.View_Interface;
using Ozone.Infrastructure.Persistence.Models;
//using Ozone.Application.Helpers;
//using Ozone.Application;

namespace Ozone.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OzoneContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(OzoneContext).Assembly.FullName)
                     //b => b.MigrationsAssembly("COI.Migrations.SQL")
                    ));

        }

        //public static void AddSeedData(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<OzoneContext>();

        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));


        //    using (OzoneContext context = new OzoneContext(optionsBuilder.Options, new UserSessionHelper()))
        //    {

        //        ///////--------------SQL Server
        //        SecForm form = context.SecForm.FirstOrDefaultAsync(f => f.Name == "Indent").Result;
        //        if (form == null)
        //        {
        //            context.SecForm.Add(new SecForm { Name = "Indent", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = "indent", MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Batch Receive", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = "batch-receive", MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Branch Request", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = "branch-request-raised", MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "PID Inventory Issue", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = "pid-inventory-issue", MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Branch Stock Receive", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = "branch-stock-receive", MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Sales Applicant", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Enchashment Back", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Input Sc", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Applicant Reg", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Branch Stop Payment", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Branch Stop Payment", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Branch Duplicate Issue", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Branch Duplicate Issue", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Tax", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Tax Policy", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Zakat", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Product", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Product Denomination", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Profit Rates", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Costumer Type", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Issue Type", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Religion", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Doc Seen Master", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Stop Pay Reason", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Bank Master", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Location Master", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Currency Master", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Purchase Type", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Comission Sale", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = null, MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "User", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = "user", MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "Role", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = "role", MainTableName = null, SupportingTableNames = null });
        //            context.SecForm.Add(new SecForm { Name = "PID Request Authorizer", TypeId = 1, ParentId = null, AuthorizedBy = 1, AuthorizedDate = DateTime.Now, IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now, LastModifiedBy = null, LastModifiedDate = null, Code = "pid-request-authorizer", MainTableName = null, SupportingTableNames = null });
        //        }

        //        SecPolicy policy = context.SecPolicy.FirstOrDefaultAsync(f => f.Name == "DUPLICATE_LOGIN_ALLOWED").Result;
        //        if (policy == null)
        //        {
        //            context.SecPolicy.Add(new SecPolicy { Name = "DUPLICATE_LOGIN_ALLOWED", Value = "0", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.SecPolicy.Add(new SecPolicy { Name = "LOCKING_INCORRECT_ATTEMPTS", Value = "5", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.SecPolicy.Add(new SecPolicy { Name = "UNLOCK_TIME_MINUTES", Value = "20", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.SecPolicy.Add(new SecPolicy { Name = "REUSING_SAME_PASSWORD", Value = "4", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.SecPolicy.Add(new SecPolicy { Name = "PASSWORD_COMPLEXITY_REGEX", Value = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,20})", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //        }

        //        EntityEntry<ProfitType> sepPt = null;
        //        EntityEntry<ProfitType> comPt = null;

        //        ProfitType sepProfittype = context.ProfitType.FirstOrDefaultAsync(f => f.Name == "Separate").Result;
        //        if (sepProfittype == null)
        //        {
        //            sepPt = context.ProfitType.Add(new ProfitType { Name = "Separate", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //        }

        //        ProfitType comProfittype = context.ProfitType.FirstOrDefaultAsync(f => f.Name == "Combined").Result;
        //        if (comProfittype == null)
        //        {
        //            comPt = context.ProfitType.Add(new ProfitType { Name = "Combined", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //        }

        //        EncashType encashtype = context.EncashType.FirstOrDefaultAsync(f => f.Name == "Profit").Result;
        //        if (encashtype == null)
        //        {
        //            context.EncashType.Add(new EncashType { Name = "Profit", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.EncashType.Add(new EncashType { Name = "Principle", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.EncashType.Add(new EncashType { Name = "Re-Invest", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //        }

        //        IssueType form2 = context.IssueType.FirstOrDefaultAsync(f => f.Name == "Sales").Result;
        //        if (form2 == null)
        //        {
        //            context.IssueType.Add(new IssueType { Name = "Sales", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.IssueType.Add(new IssueType { Name = "Transfer", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.IssueType.Add(new IssueType { Name = "Duplicate", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.IssueType.Add(new IssueType { Name = "Encashment", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.IssueType.Add(new IssueType { Name = "Reinvest", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //        }

        //        CustomerType custype = context.CustomerType.FirstOrDefaultAsync(f => f.Name == "Individual-Single").Result;
        //        if (custype == null)
        //        {
        //            context.CustomerType.Add(new CustomerType { Name = "Individual-Single", Code = null, Remarks = null, IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.CustomerType.Add(new CustomerType { Name = "Individual-JointA", Code = null, Remarks = null, IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.CustomerType.Add(new CustomerType { Name = "Individual-JointB", Code = null, Remarks = null, IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.CustomerType.Add(new CustomerType { Name = "Corporate", Code = null, Remarks = null, IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.CustomerType.Add(new CustomerType { Name = "Minor-Single", Code = null, Remarks = null, IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //            context.CustomerType.Add(new CustomerType { Name = "Minor-Joint", Code = null, Remarks = null, IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //        }

        //        Location loc = context.Location.FirstOrDefaultAsync(f => f.Name == "PID").Result;
        //        if (loc == null)
        //        {
        //            context.Location.Add(new Location { Name = "PID", Code = "PID", LocationTypeId = 1, IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //        }

        //        SecRole role = context.SecRole.FirstOrDefaultAsync(f => f.Name == "Administrator").Result;
        //        if (role == null)
        //        {
        //            context.SecRole.Add(new SecRole { Name = "Administrator", IsClosed = false, IsAuthorized = true, IsSubmitted = true, CreatedBy = 1, CreatedDate = DateTime.Now, AuthorizedBy = 1, AuthorizedDate = DateTime.Now });
        //        }

        //        Department dept = context.Department.FirstOrDefaultAsync(f => f.Name == "PID").Result;
        //        if (dept == null)
        //        {
        //            context.Department.Add(new Department { Name = "PID", IsClosed = false, CreatedBy = 1, CreatedDate = DateTime.Now });
        //        }
        //        context.SaveChanges();

        //        Product form1 = context.Product.FirstOrDefaultAsync(f => f.Name == "Defence Saving Certificate").Result;
        //        if (form1 == null)
        //        {
        //            context.Product.Add(new Product { Name = "Defence Saving Certificate", Code = "DSC", IsClosed = false, MaturityYears = 10, PrincipleEncashCount = 1, ProfitSlipCount = 10, ProfitCompMonth = 12, ProfitTypeId = comProfittype != null ? comProfittype.Id : comPt.Entity.Id, CreatedBy = 1, CreatedDate = DateTime.Now });
        //            context.Product.Add(new Product { Name = "Special Saving Certificate", Code = "SSC", IsClosed = false, MaturityYears = 3, PrincipleEncashCount = 1, ProfitSlipCount = 6, ProfitCompMonth = 6, ProfitTypeId = sepProfittype != null ? sepProfittype.Id : sepPt.Entity.Id, CreatedBy = 1, CreatedDate = DateTime.Now });
        //            context.Product.Add(new Product { Name = "Premium Prize Bonds", Code = "PPB", IsClosed = false, MaturityYears = 0, PrincipleEncashCount = 1, ProfitSlipCount = 0, ProfitCompMonth = 0, ProfitTypeId = comProfittype != null ? comProfittype.Id : comPt.Entity.Id, CreatedBy = 1, CreatedDate = DateTime.Now });
        //        }
        //        context.SaveChanges();
        //    }



        //}

    }
}
