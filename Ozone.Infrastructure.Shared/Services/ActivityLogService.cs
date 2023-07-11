using AutoMapper;
using Ozone.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
    public class ActivityLogService : IActivityLogService
    {
        //IActivityLogRepositoryAsync _activityLogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ActivityLogService(
         //  IActivityLogRepositoryAsync activityLogRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper
            )
        {
          //  this._activityLogRepository = activityLogRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
    }
}
