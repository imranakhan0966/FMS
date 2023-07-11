using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class CityModel
    {
        public long Id { get; set; }

        public string Code { get; set; }
        public string CountryName { get; set; }
        public string Name { get; set; }
       
        public bool? IsActive { get; set; }
        public long? CountryId { get; set; }
        public long? StateId  { get; set; }
        public string StateName { get; set; }
    }
}
