using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class GetPagedHolidayCalendarModel
    {
        public int TotalCount { get; set; }
        public List<HolidayCalendarModel> HolidayCalendarModel { get; set; }
    }
}
