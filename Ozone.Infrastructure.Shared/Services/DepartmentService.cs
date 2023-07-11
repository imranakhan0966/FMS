using AutoMapper;
using Ozone.Application.DTOs;
using Ozone.Application.Interfaces;
using Ozone.Application.Interfaces.Service;
//using Ozone.Application.Interfaces.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozone.Infrastructure.Persistence.Models;
//using Ozone.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Ozone.Application.Repository;

namespace Ozone.Infrastructure.Shared.Services
{
    public class DepartmentService : GenericRepositoryAsync<DepartmentService>, IDepartmentService
    {
       // IDepartmentRepositoryAsync _departmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly OzoneContext _dbContext;
        private readonly DbSet<Department> _Department;

        public DepartmentService(
         // IDepartmentRepositoryAsync departmentRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           OzoneContext dbContext) : base(dbContext)
        {
           // this._departmentRepository = departmentRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper; 
            _dbContext = dbContext;
            _Department = dbContext.Set<Department>();
        }
        public async Task<List<DepartmentModel>> GetAllDepartments()
        {
            List<DepartmentModel> result = new List<DepartmentModel>();
           // OzoneContext _dbContext = new OzoneContext();
            var list=await Task.Run(()=> _dbContext.Department.Where(x => x.IsClosed == false).ToList());
            foreach (var Departmentmod in list)
            {
                DepartmentModel mod =new DepartmentModel();
                mod.Id = Departmentmod.Id;
                mod.Name = Departmentmod.Name;
                result.Add(mod);


            }


           
           // var list = await _departmentRepository.GetDepartments();
         //   result = _mapper.Map<List<DepartmentModel>>(list);
            return result;
        }

    }
}
