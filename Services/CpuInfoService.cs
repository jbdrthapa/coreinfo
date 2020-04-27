using System.Threading.Tasks;
using Core.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Core.Server
{
    public class CpuInfoService : Core.Protos.CpuInfo.CpuInfoBase
    {
        private readonly ILogger<CpuInfoService> _logger;
        public CpuInfoService(ILogger<CpuInfoService> logger)
        {
            _logger = logger;
        }

        public override Task<CpuInfoResponse> GetCpuInfo(CpuInfoRequest request, ServerCallContext context)
        {
            var response = new CpuInfoResponse();
            response.Model = "Intel 10th gen";
            return Task.FromResult(response);
        }
    }
}
