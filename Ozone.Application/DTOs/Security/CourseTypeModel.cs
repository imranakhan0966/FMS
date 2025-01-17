﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class CourseTypeModel
    {
        public long Id { get; set; }
      
        public string Code { get; set; }
      
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public string Description { get; set; }
        public DateTime? CreeatedDate { get; set; }
    }
}
