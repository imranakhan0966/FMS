using Ozone.Application.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
   public interface ITenantWorkProgresHistoryService
    {
        /// <summary>
        /// Add comments
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> InsertWorkProgressHistory(WorkProgressHistoryModel input);

        Task<WorkProgressHistoryModel> GetWorkProgressHistoryById(long WorkHistoryId);
    }
}
