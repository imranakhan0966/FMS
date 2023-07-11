using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using AutoMapper;
using Ozone.Application;
using Ozone.Application.Interfaces;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Sieve.Services;
using Sieve.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Mail;
using System.Net;
using Ozone.Application.DTOs.Projects;

namespace Ozone.Infrastructure.Shared.Services
{
    public class TenantRequestService : GenericRepositoryAsync<ServiceRequest>, ITenantRequestService
    {
        #region Fields
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;

        private readonly SieveProcessor _sieveProcessor;


        #endregion

        #region Ctor

        public TenantRequestService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        SieveProcessor sieveProcessor,
         // IUserSessionHelper userSession,
         IConfiguration configuration) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._sieveProcessor = sieveProcessor;
            //_mockData = mockData;
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        #region ServicesType

        /// <summary>
        /// Gets All ServicesType
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceTypes
        /// </returns>
        public async Task<List<ServiceTypeModel>> GetALLServicesType()
        {
            var result = new List<ServiceTypeModel>();

            var list = await Task.Run(() => _dbContext.ServiceType.Where(x => x.IsDeleted == false == x.IsActive == true).ToList());
            result = _mapper.Map<List<ServiceTypeModel>>(list);
            return result;
        }

        /// <summary>
        /// Gets a ServiceTypes
        /// </summary>
        /// <param name="ServiceTypesId">ServiceTypes identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a ServiceTypes
        /// </returns>
        public async Task<ServiceTypeModel> GetServiceTypesById(long ServiceTypesId)
        {
            var result = new ServiceTypeModel();
            var obj = await Task.Run(() => _dbContext.ServiceType.Where(x => x.Id == ServiceTypesId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<ServiceTypeModel>(obj);
            return result;
        }

        #endregion

        #region Priority

        /// <summary>
        /// Gets All Priorities
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Priority
        /// </returns>
        public async Task<List<PriorityModel>> GetAllPriorities()
        {
            var result = new List<PriorityModel>();
            var list = await Task.Run(() => _dbContext.Priority.Where(x => x.IsDeleted == false && x.IsActive == true).ToList());
            result = _mapper.Map<List<PriorityModel>>(list);
            return result;
        }

        /// <summary>
        /// Gets a Priority
        /// </summary>
        /// <param name="PriorityId">Priority identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Priority
        /// </returns>
        public async Task<PriorityModel> GetPriorityById(long id)
        {
            var result = new PriorityModel();
            var obj = await Task.Run(() => _dbContext.Priority.Where(x => x.Id == id && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<PriorityModel>(obj);
            return result;
        }

        #endregion

        #region Service Status

        /// <summary>
        /// Gets All ServiceStatuses
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceStatus
        /// </returns>
        public async Task<List<ServiceStatusModel>> GetAllServiceStatus()
        {
            var result = new List<ServiceStatusModel>();
            var list = await Task.Run(() => _dbContext.Status.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<ServiceStatusModel>>(list);
            return result;
        }

        /// <summary>
        /// Gets a ServiceStatus
        /// </summary>
        /// <param name="ServiceStatusId">ServiceStatus identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a ServiceStatus
        /// </returns>
        public async Task<ServiceStatusModel> GetServiceStatusById(long ServiceStatusId)
        {
            var result = new ServiceStatusModel();
            var obj = await Task.Run(() => _dbContext.Status.Where(x => x.Id == ServiceStatusId && x.IsActive == true).SingleOrDefaultAsync());
            result = _mapper.Map<ServiceStatusModel>(obj);
            return result;
        }

        #endregion

        #region Service Request

        /// <summary>
        /// Gets All ServiceRequest
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceRequest
        /// </returns>
        public async Task<List<ServiceRequestModel>> GetAllServiceRequest()
        {
            var result = new List<ServiceRequestModel>();
            var list = await Task.Run(() => _dbContext.ServiceRequest.Where(x => x.IsActive == true).ToList());
            result = _mapper.Map<List<ServiceRequestModel>>(list);
            return result;
        }

        /// <summary>
        /// Gets All ServiceRequest
        /// </summary>
        /// <param name="ServiceStatusId">ServiceStatus identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of ServiceRequest
        /// </returns>
        public async Task<List<ServiceRequestModel>> GetAllServiceRequest(AdvanceQueryParameter queryParameter)
        {
            var result = new List<ServiceRequestModel>();

            var query = _dbContext.ServiceRequest.Where(x => x.IsActive == true && x.IsDeleted == false);

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);
            if (sieveModel.Filters != null)
            {
                string PriorityId = string.Empty;
                string statusId = string.Empty;
                string CreatedById = string.Empty;
                var split = sieveModel.Filters.Split(',');
                foreach (var filter in split)
                {
                    var chkFilterCreatedById = filter.Contains("CreatedById");
                    if (chkFilterCreatedById != false)
                    {
                        var splitCreatedById = filter.Split("==");
                        CreatedById = splitCreatedById[1];
                    }
                    var chkFilterstatusId = filter.Contains("statusId");
                    if (chkFilterstatusId != false)
                    {
                        var splitstatusId = filter.Split("!=");
                        statusId = splitstatusId[1];
                    }
                    var chkPriorityId = filter.Contains("PriorityId");
                    if (chkPriorityId != false)
                    {
                        var splitPriorityId = filter.Split("==");
                        PriorityId = splitPriorityId[1];
                    }
                }
                if (!string.IsNullOrEmpty(CreatedById))
                {
                    if (!string.IsNullOrEmpty(statusId))
                    {
                        if (!string.IsNullOrEmpty(PriorityId))
                        {
                            var list = await Task.Run(() => query.Where(x => x.CreatedById == Convert.ToInt32(CreatedById) && x.StatusId != Convert.ToInt32(statusId) && x.PriorityId == Convert.ToInt32(PriorityId)).ToList());
                            result = _mapper.Map<List<ServiceRequestModel>>(list);
                        }
                        else
                        {
                            var list = await Task.Run(() => query.Where(x => x.CreatedById == Convert.ToInt32(CreatedById) && x.StatusId != Convert.ToInt32(statusId)).ToList());
                            result = _mapper.Map<List<ServiceRequestModel>>(list);
                        }
                    }
                    else
                    {
                        var list = await Task.Run(() => query.Where(x => x.CreatedById == Convert.ToInt32(CreatedById)).ToList());
                        result = _mapper.Map<List<ServiceRequestModel>>(list);
                    }
                }
                else if (!string.IsNullOrEmpty(statusId))
                {
                    if (!string.IsNullOrEmpty(PriorityId))
                    {
                        var list = await Task.Run(() => query.Where(x => x.StatusId != Convert.ToInt32(statusId) && x.PriorityId == Convert.ToInt32(PriorityId)).ToList());
                        result = _mapper.Map<List<ServiceRequestModel>>(list);
                    }
                    else
                    {
                        var list = await Task.Run(() => query.Where(x =>x.StatusId != Convert.ToInt32(statusId)).ToList());
                        result = _mapper.Map<List<ServiceRequestModel>>(list);
                    }
                }
                else if (!string.IsNullOrEmpty(PriorityId))
                {
                    var list = await Task.Run(() => query.Where(x => x.PriorityId == Convert.ToInt32(PriorityId)).ToList());
                    result = _mapper.Map<List<ServiceRequestModel>>(list);
                }
                else
                {
                    var list = await Task.Run(() => query.ToList());
                    result = _mapper.Map<List<ServiceRequestModel>>(list);
                }
            }
            else
            {
                var list = await Task.Run(() => query.ToList());
                result = _mapper.Map<List<ServiceRequestModel>>(list);
            }
            return result;
        }

        /// <summary>
        /// Gets a ServiceRequest
        /// </summary>
        /// <param name="ServiceRequestId">ServiceRequest identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a ServiceRequest
        /// </returns>
        public async Task<ServiceRequestModel> GetServiceRequestById(long ServiceRequestId)
        {
            var result = new ServiceRequestModel();
            var list = await Task.Run(() => _dbContext.ServiceRequest.Where(x => x.Id == ServiceRequestId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<ServiceRequestModel>(list);
            return result;
        }

        /// <summary>
        /// Insert a ServiceRequest
        /// </summary>
        /// <param name="input">ServiceRequest object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> InsertServiceRequest(ServiceRequestModel input)
        {
            EmailSending emailSending = new EmailSending(_configuration);
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var getMentanaceEmail = await Task.Run(() => _dbContext.SecUser.Where(x => x.BuildingId == input.BuildingId && x.RoleId == 23 && x.EmailForgotPassword != null && x.IsActive == true && x.IsDeleted == false).FirstOrDefault());
                try
                {
                    var response = emailSending.EmailRequest(getMentanaceEmail.Email, input.Title, input.Asset, input.Description);
                    if (response.Contains("successfully Send"))
                    {
                        input.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                        var serviceRequest = await base.AddAsync(_mapper.Map<ServiceRequest>(input));
                        var result = await _unitOfWork.SaveChangesAsync();
                        transaction.Commit();
                        return "Successfully Inserted!";
                    }
                    else
                    {
                        return "Not Inserted due to Email Problem!";
                    }
                }
                catch (Exception ex)
                {
                    var Exception = ex;
                    transaction.Rollback();
                    return "Not Inserted!";
                }
            }
        }

        /// <summary>
        /// Update a ServiceRequest
        /// </summary>
        /// <param name="input">ServiceRequest object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateServiceRequest(long ServiceRequestId, ServiceRequestModel input)
        {
            //WorkProgressHistory workProgressHistory = new WorkProgressHistory();

            EmailSending emailSending = new EmailSending(_configuration);
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Status statusType = await Task.Run(() => _dbContext.Status.Where(x => x.Id == input.StatusId).FirstOrDefault());
                ServiceRequest serviceRequest = await Task.Run(() => _dbContext.ServiceRequest.Where(x => x.Id == ServiceRequestId).FirstOrDefault());
               
                if (serviceRequest == null) return "Service Request Not Found!";
                SecUser secUser = await Task.Run(() => _dbContext.SecUser.Where(x => x.FlatId == serviceRequest.FlatId).FirstOrDefault());

                try
                {
                    if (secUser == null) return "User not provided";
                    var comments = input.MaintainerComments + " and your Service is " + statusType.Name;
                    var response = emailSending.EmailRequest(secUser.Email, serviceRequest.Title, serviceRequest.Asset,comments );
                    if (response.Contains("successfully Send"))
                    {
                        if (input.Id != 0) serviceRequest.Id = input.Id;
                        if (input.Code != null) serviceRequest.Code = input.Code;
                        if (input.Title != null) serviceRequest.Title = input.Title;
                        if (input.Description != null) serviceRequest.Description = input.Description;
                        if (input.ServiceTypeId != null) serviceRequest.ServiceTypeId = input.ServiceTypeId;
                        if (input.ClientId != null) serviceRequest.ClientId = input.ClientId;
                        if (input.BuildingId != null) serviceRequest.BuildingId = input.BuildingId;
                        if (input.FlatId != null) serviceRequest.FlatId = input.FlatId;
                        if (input.Asset != null) serviceRequest.Asset = input.Asset;
                        if (input.PriorityId != null) serviceRequest.PriorityId = input.PriorityId;
                        if (input.MaintainerComments != null) serviceRequest.MaintainerComments = input.MaintainerComments;
                        if (input.StatusId != null) serviceRequest.StatusId = input.StatusId;
                        if (input.IsActive != null) serviceRequest.IsActive = input.IsActive;
                        if (input.IsDeleted != null) serviceRequest.IsDeleted = input.IsDeleted;
                        if (input.CreatedById != null) serviceRequest.CreatedById = input.CreatedById;
                        if (input.CreatedDate != null) serviceRequest.CreatedDate = input.CreatedDate;
                        if (input.LastModifiedById != null) serviceRequest.LastModifiedById = input.LastModifiedById;
                        if (input.LastModifiedDate != null) serviceRequest.LastModifiedDate = input.LastModifiedDate;
                        if (input.CompletedById != null) serviceRequest.CompletedById = input.CompletedById;
                        if (input.CompletedDate != null) serviceRequest.CompletedDate = input.CompletedDate;

                        await base.UpdateAsync(_mapper.Map<ServiceRequest>(serviceRequest));
                        await _unitOfWork.SaveChangesAsync();
                        //if (serviceRequest != null)
                        //{

                        //    if (secUser != null && secUser.Id > 0) workProgressHistory.UserId = secUser.Id;
                        //    workProgressHistory.Commemts = input.MaintainerComments;
                        //    workProgressHistory.CommemtsDate = DateTime.Now;

                        //   _dbContext.WorkProgressHistory.Add(workProgressHistory);
                        //    await _unitOfWork.SaveChangesAsync();
                        //}

                        transaction.Commit();
                        return secUser.Id.ToString();
                    }
                    if (response.Contains("successfully Send"))
                    {
                        if (input.Id != 0) serviceRequest.Id = input.Id;
                    }

                    else
                    {
                        return "0";
                    }    
                }
                catch (Exception ex)
                {
                    var Exception = ex;
                    transaction.Rollback();
                    return "0";
                }
            }
            return "0";
        }

        #endregion

        #endregion
    }
}
