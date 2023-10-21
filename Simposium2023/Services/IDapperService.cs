using Dapper;
using Simposium2023.Models.Queries;
using Simposium2023.Models.Responses;

namespace Simposium2023.Services
{
    public interface IDapperService
    {
        Task<ServiceResponse> ExecuteStoredProcedureAsync<T>(
            StoredProcedureData qData, 
            DynamicParameters parameters, 
            bool hasArray = false);
    }
}
