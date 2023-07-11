using Ozone.Application.DTOs;
using Ozone.Application.Interfaces.Setup;
using Ozone.Application.Repository;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using AutoMapper;
using Ozone.Application;
using Ozone.Application.Interfaces;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Sieve.Services;
using Sieve.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Mail;
using System.Net;
using Ozone.Application.DTOs.Projects;

namespace Ozone.Infrastructure.Shared.Services
{
    public class TenantWorkProgresHistoryService : GenericRepositoryAsync<WorkProgressHistory>,  ITenantWorkProgresHistoryService
    {

        #region Fields
        private readonly OzoneContext _dbContext;
        //  private readonly DbSet<Library> _user;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        IConfiguration _configuration;

        private readonly SieveProcessor _sieveProcessor;


        #endregion

        #region Ctor

        public TenantWorkProgresHistoryService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
        SieveProcessor sieveProcessor,
         // IUserSessionHelper userSession,
         IConfiguration configuration) : base(dbContext)
        {
            this._unitOfWork = unitOfWork;
            _dbContext = dbContext;
            //  _user = dbContext.Set<Library>();
            //_dataShaper = dataShaper;
            this._mapper = mapper;
            this._sieveProcessor = sieveProcessor;
            //_mockData = mockData;
            this._configuration = configuration;
        }

        #endregion


        #region methods
        /// <summary>
        /// Add Comments of Request Services
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> InsertWorkProgressHistory(WorkProgressHistoryModel input)
        {
           
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                  try
                {
                     
                        await base.AddAsync(_mapper.Map<WorkProgressHistory>(input));
                        await _unitOfWork.SaveChangesAsync();
                        transaction.Commit();
                        return "Successfully Updated!";
                   
                }
                catch (Exception ex)
                {
                    var Exception = ex;
                    transaction.Rollback();
                    return "Not Updated!";
                }
            }
        }



        public async Task<WorkProgressHistoryModel> GetWorkProgressHistoryById(long WorkHistoryId)
        {
                var result = new WorkProgressHistoryModel();
            try
            {
                var obj = await Task.Run(() => _dbContext.WorkProgressHistory.Where(x => x.UserId == WorkHistoryId).ToListAsync());
                result = _mapper.Map<WorkProgressHistoryModel>(obj);
            }
            catch (Exception ex)
            {
                var Exception = ex;
                
              
            }
                return result;
        }


            #endregion
        }
}
