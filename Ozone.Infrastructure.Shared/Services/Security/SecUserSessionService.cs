using AutoMapper;
using Ozone.Application.DTOs;
//using Ozone.Application.Interfaces;
//using Ozone.Application.Interfaces.Service;
using Ozone.Infrastructure.Persistence;
//using Ozone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozone.Infrastructure.Persistence.Models;
using Ozone.Application.Interfaces.Service;
using Ozone.Application.Interfaces;
using System.Data.Entity;
using Ozone.Application.Repository;

namespace Ozone.Infrastructure.Shared.Services
{
    public class SecUserSessionService:GenericRepositoryAsync<SecUserSession>, ISecUserSessionService
    {
        // ISecUserSessionRepositoryAsync _secUserSessionRepo;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfwork;
        private readonly OzoneContext _dbContext;
        public SecUserSessionService( IMapper mapper, IUnitOfWork unitOfWork, OzoneContext dbContext) : base(dbContext)
        {
         //   this._secUserSessionRepo = secUserSessionRepo;
            this._mapper = mapper;
            this._unitOfwork = unitOfWork;
            _dbContext = dbContext;
        }
        public async Task<SecUserSessionModel> CreateUserSession(SecUserSessionModel userSessionModel)
        {

            SecUserSessionModel session = new SecUserSessionModel();


             var userSessionEntity = _mapper.Map<SecUserSession>(userSessionModel);

            var existingSessionEntity = await Task.Run(()=> _dbContext.SecUserSession.Where(sus => sus.SecUserId == userSessionModel.SecUserId).FirstOrDefault());
     
            if (existingSessionEntity != null)
            {
                existingSessionEntity.LoginDateTime = userSessionEntity.LoginDateTime;
               // existingSessionEntity.LoginCount= existingSessionEntity.LoginCount+1;
                //existingSessionEntity.LogoutDateTime = null;
                //userSessionEntity.LoginCount= existingSessionEntity.LoginCount + 1;
                await base.UpdateAsync(existingSessionEntity);
              
            }
            else
            {
                existingSessionEntity = new SecUserSession();
                existingSessionEntity.SecUserId = userSessionModel.SecUserId;
                existingSessionEntity.LoginDateTime = userSessionEntity.LoginDateTime;
                existingSessionEntity.Ipaddress = userSessionEntity.Ipaddress;
                //userSessionEntity.LoginCount = 1;
                // existingSessionEntity.LoginCount = 1;
                await base.AddAsync(userSessionEntity);
              
            }

            userSessionModel = _mapper.Map<SecUserSessionModel>(userSessionEntity);
            await _unitOfwork.SaveChangesAsync();
            return userSessionModel;
        }

        public Task<string> DeleteUserSession(long userId)
        {
            throw new NotImplementedException();
        }

        //public async Task<string> DeleteUserSession(long userId)
        //{
        //    using (var transaction = _unitOfwork.BeginTransaction())
        //    {
        //        try
        //        {
        //            var secUserSession = _secUserSessionRepo.GetSessionByUserId(userId);
        //            if (secUserSession != null)
        //            {
        //                await _secUserSessionRepo.DeleteUserSession(secUserSession);
        //            }
        //            await _unitOfwork.SaveChangesAsync();
        //            transaction.Commit();
        //            return "Successfully Delted!";
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            return "Not Deleted!";

        //        }
        //    }
        //}
    }

}
