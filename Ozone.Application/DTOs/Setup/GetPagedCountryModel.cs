using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedCountryModel
    {
        public int TotalCount { get; set; }
        public List<CountryModel> CountryModel { get; set; }
    }
}
