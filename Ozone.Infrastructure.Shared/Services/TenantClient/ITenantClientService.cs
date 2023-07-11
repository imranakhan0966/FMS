using Ozone.Application.DTOs;
using Ozone.Application.DTOs.Architectures;
using Ozone.Application.Parameters;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ozone.Infrastructure
{ 
    public interface ITenantClientService
    {
        Task<List<ClientModel>> GetAllClient(AdvanceQueryParameter queryParameter);
        Task<string> InsertClient(ClientModel input);
        Task<ClientModel> GetClientById(long clientId);
        Task<string> UpdateClient(long clientId, ClientModel input);
    }
}
