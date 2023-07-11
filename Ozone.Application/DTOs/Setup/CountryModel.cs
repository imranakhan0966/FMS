using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
  public  class CountryModel
    {
        public long Id { get; set; }
        
        public int? Code { get; set; }
     
        public string Name { get; set; }

        public int? Status { get; set; }
        public bool IsActive { get; set; }



    }
}
