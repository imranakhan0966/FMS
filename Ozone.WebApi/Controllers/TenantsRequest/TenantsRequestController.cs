using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ozone.Infrastructure;
using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Architectures;
using Ozone.Infrastructure.Persistence.Models;
using Ozone.Application.Parameters;
//using Ozone.Infrastructure.Shared.Services.TenantRequest;
using Ozone.Application.DTOs.Projects;
using Ozone.Infrastructure.Shared.Services;

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TenantsRequestController : BaseApiController
    {
        #region Fields
        private readonly IMapper _mapper;
        IAllDropdownService _AllDropdownService;
        ITenantRequestService _TenantRequestService;
        ITenantServiceTypeService _TenantServiceTypeService;
        private readonly ITenantWorkProgresHistoryService _tenantWorkProgresHistoryService;

        #endregion

        #region Ctor
        public TenantsRequestController(
             ITenantWorkProgresHistoryService tenantWorkProgresHistoryService,
        IAllDropdownService allDropdownService,
            ITenantRequestService tenantRequestService,
            ITenantServiceTypeService tenantServiceTypeService,
            //IWorkProgressHistory workProgressHistory,
            IMapper mapper)
        {
            this._tenantWorkProgresHistoryService = tenantWorkProgresHistoryService;
            this._mapper = mapper;
            this._AllDropdownService = allDropdownService;
            this._TenantRequestService = tenantRequestService;
            this._TenantServiceTypeService = tenantServiceTypeService;
            //this._WorkProgressHistory = workProgressHistory;
        }

        #endregion

        #region Methods

        #region serviceType

        [Route("serviceType")]
        [HttpGet]
        public async Task<IActionResult> GetAllServiceTypes()
        {
            var List = await _TenantServiceTypeService.GetALLServicesType();
            return new JsonResult(List);
        }

        [Route("serviceType")]
        [HttpPost]
        public async Task<IActionResult> CreateBuilding(ServiceTypeModel serviceType)
        {
            var List = await _TenantServiceTypeService.InsertServiceType(serviceType);
            return new JsonResult(List);
        }

        [Route("serviceType/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetServiceTypesById(long id)
        {
            var List = await _TenantServiceTypeService.GetServiceTypesById(id);
            return new JsonResult(List);
        }

        [Route("serviceType/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateBuilding(long id, ServiceTypeModel serviceType)
        {
            var List = await _TenantServiceTypeService.UpdateServiceTypes(id, serviceType);
            return new JsonResult(List);
        }

        #endregion

        #region priority

        [Route("priority")]
        [HttpGet]
        public async Task<IActionResult> GetAllPriorities()
        {
            var List = await _TenantRequestService.GetAllPriorities();
            return new JsonResult(List);
        }

        [Route("priority/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetAllPriorities(long id)
        {
            var List = await _TenantRequestService.GetPriorityById(id);
            return new JsonResult(List);
        }
        #endregion

        #region status

        [Route("status")]
        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            var List = await _TenantRequestService.GetAllServiceStatus();
            return new JsonResult(List);
        }

        [Route("status/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetStatusById(long id)
        {
            var List = await _TenantRequestService.GetServiceStatusById(id);
            return new JsonResult(List);
        }

        #endregion

        #region serviceRequest

        [Route("serviceRequest")]
        [HttpGet]
        public async Task<IActionResult> GetAllServiceRequest([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var List = await _TenantRequestService.GetAllServiceRequest(queryParameter);
            return new JsonResult(List);
        }

        [Route("serviceRequest/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetServiceRequestById(long id)
        {
            var List = await _TenantRequestService.GetServiceRequestById(id);
            return new JsonResult(List);
        }

        [Route("serviceRequest")]
        [HttpPost]
        public async Task<IActionResult> CreateServiceRequest(ServiceRequestModel serviceRequest)
        {
            var List = await _TenantRequestService.InsertServiceRequest(serviceRequest);
            return new JsonResult(List);
        }

        [Route("serviceRequest/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateServiceRequest(long id, ServiceRequestModel serviceRequest)
        {
            var List = await _TenantRequestService.UpdateServiceRequest(id, serviceRequest);
            if (!string.IsNullOrEmpty(List) && Convert.ToInt64(List)>0)
            {
                WorkProgressHistoryModel workHistory = new WorkProgressHistoryModel();
                workHistory.UserId = Convert.ToInt64(List);
                workHistory.ServiceId = id;
                workHistory.Commemts = serviceRequest.MaintainerComments;
                workHistory.CommemtsDate = DateTime.Now;
                var getList = await _tenantWorkProgresHistoryService.InsertWorkProgressHistory(workHistory);
                return new JsonResult(getList);
            }
            return null;
        }


        [Route("workProgressHistory/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetWorkProgressHistoryById(long id)
        {
            var List = await _tenantWorkProgresHistoryService.GetWorkProgressHistoryById(id);
            return new JsonResult(List);
        }
        #endregion
        #endregion
    }
}