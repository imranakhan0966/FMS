using Ozone.Application.DTOs;
//using Ozone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Application.Interfaces.Service
{
    public interface IDepartmentService
    {
        Task<List<DepartmentModel>> GetAllDepartments();
    }
}
