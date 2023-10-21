using Simposium2023.Models.Queries;

namespace Simposium2023.Helpers
{
    public static class JsonReader
    {
        public static StoredProcedureData GetConfigurationStoredProcedure(IConfiguration configuration, string repositoryKey)
        {
            return new(
                configuration[$"{repositoryKey}:schemaName"],
                configuration[$"{repositoryKey}:spName"],
                configuration[$"{repositoryKey}:connectionId"]);
        }
    }
}
