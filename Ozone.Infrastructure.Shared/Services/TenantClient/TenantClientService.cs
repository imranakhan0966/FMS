using System.Runtime.CompilerServices;
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
namespace Ozone.Infrastructure.Shared.Services
{
    public class TenantClientService : GenericRepositoryAsync<Client>, ITenantClientService
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

        public TenantClientService(
             IUnitOfWork unitOfWork,
         OzoneContext dbContext,
        //IDataShapeHelper<Library> dataShaper,
        IMapper mapper,
         // IUserSessionHelper userSession,
         SieveProcessor sieveProcessor,
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

        #region Methods 
        /// <summary>
        /// Gets All Client
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains list of Client
        /// </returns>

        public async Task<List<ClientModel>> GetAllClient(AdvanceQueryParameter queryParameter)
        {
            var result = new List<ClientModel>();
            var query = await Task.Run(() => _dbContext.Client.Include(x => x.Country).Include(x => x.State).Include(x => x.City).Where(x => x.IsActive == true && x.IsDeleted == false));

            var sieveModel = new SieveModel
            {
                Filters = queryParameter.filters,
                Sorts = queryParameter.sort,
                Page = queryParameter.page,
                PageSize = queryParameter.pageSize,
            };

            query = _sieveProcessor.Apply(sieveModel, query);

            var list = await Task.Run(() => query.ToList());
            result = _mapper.Map<List<ClientModel>>(list);
            return result;
        }

        /// <summary>
        /// Insert a Building
        /// </summary>
        /// <param name="input">BuildingsModel object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> InsertClient(ClientModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    input.IsActive = true;
                    input.IsDeleted = 0;
                    input.CreationTime = DateTime.Now;
                    await base.AddAsync(_mapper.Map<Client>(input));
                    await _unitOfWork.SaveChangesAsync();
                    transaction.Commit();
                    return "Successfully Inserted!";
                }
                catch (Exception ex)
                {
                    var Exception = ex;
                    transaction.Rollback();
                    return "Not Inserted!";
                }
            }
        }

        /// <summary>
        /// Gets a Building
        /// </summary>
        /// <param name="BuildingId">Building identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a Building
        /// </returns>
        public async Task<ClientModel> GetClientById(long clientId)
        {
            var result = new ClientModel();
            var obj = await Task.Run(() => _dbContext.Client.Where(x => x.Id == clientId && x.IsActive == true && x.IsDeleted == false).SingleOrDefaultAsync());
            result = _mapper.Map<ClientModel>(obj);
            return result;
        }

        /// <summary>
        /// Update a Building
        /// </summary>
        /// <param name="ClientId">Building Identifier</param>
        /// <param name="input">ServiceRequest object</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> UpdateClient(long clientId, ClientModel input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                Client client = await Task.Run(() => _dbContext.Client.Where(x => x.Id == clientId).FirstOrDefault());
                if (client == null) return "Service Request Not Found!";

                try
                {
                    if (!String.IsNullOrEmpty(input.Name)) client.Name = input.Name;
                    if (!String.IsNullOrEmpty(input.Code)) client.Code = input.Code;
                    if (!String.IsNullOrEmpty(input.Website)) client.Website = input.Website;
                    if (!String.IsNullOrEmpty(input.Email)) client.Email = input.Email;
                    if (!String.IsNullOrEmpty(input.ContactPerson)) client.ContactPerson = input.ContactPerson;
                    if (!String.IsNullOrEmpty(input.Address1)) client.Address1 = input.Address1;
                    if (!String.IsNullOrEmpty(input.PhoneNumber)) client.PhoneNumber = input.PhoneNumber;
                    if (!String.IsNullOrEmpty(input.MobileNumber)) client.MobileNumber = input.MobileNumber;
                    if (input.CountryId > 0) client.CountryId = input.CountryId;
                    if (input.StateId > 0) client.StateId = input.StateId;
                    if (input.CityId > 0) client.CityId = input.CityId;
                    client.IsActive = true;
                    client.IsDeleted = false;
                    client.LastModificationTime = DateTime.Now;
                    await base.UpdateAsync(_mapper.Map<Client>(client));
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
        #endregion
    }
}
