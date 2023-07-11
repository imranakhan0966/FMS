using Ozone.Application.DTOs;
//using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
    public interface IHolidayCalendarService
    {
        Task<string> Create(HolidayCalendarModel input);
        Task<GetPagedHolidayCalendarModel> GetPagedHolidayCalendarResponse(PagedResponseModel model);
        Task<HolidayCalendarModel> GetHolidayCalendarBYId(long id);
        Task<string> HolidayCalendarDeleteById(long id);
    }
}
