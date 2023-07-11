using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedCityModel
    {
        public int TotalCount { get; set; }
        public List<CityModel> CityModel { get; set; }
    }
}
