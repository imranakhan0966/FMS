using Ozone.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Setup
{
   public interface ICourseTypeService
    {
        Task<string> Create(CourseTypeModel input);
        Task<GetPagedCourseTypeModel> GetPagedCourseTypeResponse(PagedResponseModel model);
        Task<CourseTypeModel> GetCourseTypeBYId(long id);
        Task<string> CourseTypeDeleteById(long id);

    }
}
