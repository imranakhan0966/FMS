using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
   public class GetPagedCourseTypeModel
    {
        public int TotalCount { get; set; }
        public List<CourseTypeModel> CourseTypeModel { get; set; }



    }
}
