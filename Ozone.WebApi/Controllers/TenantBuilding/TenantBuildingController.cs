using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ozone.Infrastructure;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Ozone.Application.DTOs;
using Ozone.Infrastructure.Persistence.Models;

namespace Ozone.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TenantBuildingController : BaseApiController
    {
        #region Fields
        private readonly IMapper _mapper;
        IAllDropdownService _AllDropdownService;
        ITenantBuildingService _TenantBuildingService;
        ITenantFloorService _TenantFloorService;
        ITenantFloorTypeService _TenantFloorTypeService;
        ITenantFlatService _TenantFlatService;
        ITenantParkingSlotService _TenantParkingSlotService;
        private readonly OzoneContext _context;

        #endregion

        #region Ctor
        public TenantBuildingController(
            IMapper mapper,
            IAllDropdownService allDropdownService,
            ITenantBuildingService tenantBuildingService,
            ITenantFloorService tenantFloorService,
            ITenantFloorTypeService tenantFloorTypeService,
            ITenantFlatService tenantFlatService,
            ITenantParkingSlotService tenantParkingSlotService,
            OzoneContext context)
        {
            this._context = context;
            this._mapper = mapper;
            this._AllDropdownService = allDropdownService;
            this._TenantBuildingService = tenantBuildingService;
            this._TenantFloorService = tenantFloorService;
            this._TenantFloorTypeService = tenantFloorTypeService;
            _TenantFlatService = tenantFlatService;
            _TenantParkingSlotService = tenantParkingSlotService;
        }

        #endregion

        #region Methods

        #region Buildings

        [Route("building")]
        [HttpGet]
        public async Task<IActionResult> GetAllBuildings([FromQuery] AdvanceQueryParameter queryParameter)
        {
            if (!string.IsNullOrEmpty(queryParameter.filters) && queryParameter.filters.Contains("clientId"))
            {
                var split = queryParameter.filters.Split(',');
                var getUserId = split[2].Split("==");
                var getClientId = await Task.Run(() => _context.SecUser.Where(x => x.Id == Convert.ToInt64(getUserId[1])).FirstOrDefault());
                if (getClientId != null)
                {
                    var setClientId = split[1].Split("==");
                    setClientId[1] = getClientId.ClientId.ToString();
                    queryParameter.filters = setClientId[0] + "==" + setClientId[1];

                }
            }
          
            var List = await _TenantBuildingService.GetAllBuildings(queryParameter);
            return new JsonResult(List);
        }

        [Route("building")]
        [HttpPost]
        public async Task<IActionResult> CreateBuilding(BuildingsModel building)
        {
            var List = await _TenantBuildingService.InsertBuilding(building);
            return new JsonResult(List);
        }

        [Route("building/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetBuildingById(long id)
        {
            var List = await _TenantBuildingService.GetBuildingById(id);
            return new JsonResult(List);
        }

        [Route("building/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateBuilding(long id, BuildingsModel buildings)
        {
            var List = await _TenantBuildingService.UpdateBuilding(id, buildings);
            return new JsonResult(List);
        }

        #endregion

        #region Floors

        [Route("floor")]
        [HttpGet]
        public async Task<IActionResult> GetAllFloors([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var List = await _TenantFloorService.GetAllFloors(queryParameter);
            return new JsonResult(List);
        }

        [Route("floor")]
        [HttpPost]
        public async Task<IActionResult> CreateFloor(FloorDetailModel floor)
        {
            var List = await _TenantFloorService.InsertFloor(floor);
            return new JsonResult(List);
        }



        [Route("floor/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetFloorById(long id)
        {
            var List = await _TenantFloorService.GetFloorById(id);
            return new JsonResult(List);
        }

        [Route("floor/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateFloor(long id, FloorsModel floor)
        {
            var List = await _TenantFloorService.UpdateFloor(id, floor);
            return new JsonResult(List);
        }

        #endregion

        #region FloorType

        [Route("floorType")]
        [HttpGet]
        public async Task<IActionResult> GetAllFloorType([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var List = await _TenantFloorTypeService.GetAllFloorsTypes(queryParameter);
            return new JsonResult(List);
        }

        [Route("floorType")]
        [HttpPost]
        public async Task<IActionResult> CreateFloorType(FloorTypeModel floorType)
        {
            var List = await _TenantFloorTypeService.InsertFloorType(floorType);
            return new JsonResult(List);
        }

        [Route("floorType/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetFloorTypeById(long id)
        {
            var List = await _TenantFloorTypeService.GetFloorTypeById(id);
            return new JsonResult(List);
        }

        [Route("floorType/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateFloorType(long id, FloorTypeModel floorType)
        {
            var List = await _TenantFloorTypeService.UpdateFloorType(id, floorType);
            return new JsonResult(List);
        }

        #endregion

        #region Flats

        [Route("flat")]
        [HttpGet]
        public async Task<IActionResult> GetAllFlats([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var List = await _TenantFlatService.GetAllFlats(queryParameter);
            return new JsonResult(List);
        }       
        
        [Route("flatUpdateCase")]
        [HttpGet]
        public async Task<IActionResult> GetAllFlatsByUpdate([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var List = await _TenantFlatService.GetAllFlatsByUpdate(queryParameter);
            return new JsonResult(List);
        }

        [Route("flat")]
        [HttpPost]
        public async Task<IActionResult> CreateFlat(FlatDetailModel flat)
        {
            var List = await _TenantFlatService.InsertFlat(flat);
            return new JsonResult(List);
        }

        [Route("flat/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetFlatById(long id)
        {
            var List = await _TenantFlatService.GetFlatById(id);
            return new JsonResult(List);
        }

        [Route("flat/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateFlat(long id, FlatModel flat)
        {
            var List = await _TenantFlatService.UpdateFlat(id, flat);
            return new JsonResult(List);
        }

        #endregion

        #region ParkingSlots

        [Route("parkingSlot")]
        [HttpGet]
        public async Task<IActionResult> GetAllParkingSlots([FromQuery] AdvanceQueryParameter queryParameter)
        {
            var List = await _TenantParkingSlotService.GetAllParkingSlots(queryParameter);
            return new JsonResult(List);
        }

        [Route("parkingSlot")]
        [HttpPost]
        public async Task<IActionResult> CreateParkingSlot(ParkingSlotDetailModel parkingSlot)
        {
            var List = await _TenantParkingSlotService.InsertParkingSlot(parkingSlot);
            return new JsonResult(List);
        }

        [Route("parkingSlot/{id:long}")]
        [HttpGet]
        public async Task<IActionResult> GetParkingSlotById(long id)
        {
            var List = await _TenantParkingSlotService.GetParkingSlotById(id);
            return new JsonResult(List);
        }

        [Route("parkingSlot/{id:long}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateFlat(long id, ParkingSlotModel parkingSlot)
        {
            var List = await _TenantParkingSlotService.UpdateParkingSlot(id, parkingSlot);
            return new JsonResult(List);
        }

        #endregion

        #endregion
    }
}