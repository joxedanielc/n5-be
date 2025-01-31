using Nest;
using N5_BE.Application.Interfaces;
using N5_BE.Domain.Entities;

namespace N5_BE.Infra.Elastic
{
    public class ElasticService : IElasticService
    {
        private readonly IElasticClient _elasticClient;
        private const string IndexName = "permisos-index";

        public ElasticService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task IndexPermissionAsync(Permiso permiso)
        {
            var response = await _elasticClient.IndexAsync(permiso, i => i.Index(IndexName));
            if (!response.IsValid)
            {
                throw new Exception($"Failed to index document: {response.DebugInformation}");
            }
        }
    }
}