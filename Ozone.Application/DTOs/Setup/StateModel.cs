using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class StateModel
    {

        public long Id { get; set; }
        public string Code { get; set; }
        public string CountryName{ get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public long? CountryId { get; set; }
    }
}
