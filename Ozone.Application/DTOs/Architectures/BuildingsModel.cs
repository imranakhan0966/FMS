using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ozone.Application.DTOs.Architectures
{
   public class BuildingsModel
    {

        public long Id { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public long? ClientId { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string FloorPrefix { get; set; }
        public string FlatPrefix { get; set; }
        public string ParkingPrefix { get; set; }
        public string FloorParkingPrefix { get; set; }
    }
}
