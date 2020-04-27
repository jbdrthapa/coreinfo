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
            // Execute the command to get cpu info
            var cpuInfo = Utilities.ExecuteCommand("cat /proc/cpuinfo");

            // CPU Cache
            var cpuCache = Utilities.GetValue("cache size\t:", cpuInfo);

            // CPU Cores
            var cpuCores = Utilities.GetValue("cpu cores\t:", cpuInfo);

            // CPU Family
            var cpuFamily = Utilities.GetValue("cpu family\t:", cpuInfo);

            // CPU Flags
            var cpuFlags = Utilities.GetValue("flags\t\t:", cpuInfo);

            // CPU MHz
            var cpuMHz = Utilities.GetValue("cpu MHz\t\t:", cpuInfo);

            // CPU Microcode
            var cpuMicrocode = Utilities.GetValue("microcode\t:", cpuInfo);

            // CPU Stepping
            var cpuStepping = Utilities.GetValue("stepping\t:", cpuInfo);

            // CPU Model
            var cpuModel = Utilities.GetValue("model\t\t:", cpuInfo);

            // CPU Model Name
            var cpuModelName = Utilities.GetValue("model name\t:", cpuInfo);

            // CPU Vendor
            var cpuVendor = Utilities.GetValue("vendor_id\t:", cpuInfo);

            // CPU VMX Flags
            var cpuVMXFlags = Utilities.GetValue("vmx flags\t:", cpuInfo);

            var response = new CpuInfoResponse()
            {
                Cache = cpuCache,
                Cores = cpuCores,
                Family = cpuFamily,
                Flags = cpuFlags,
                MHz = cpuMHz,
                Microcode = cpuMicrocode,
                Stepping = cpuStepping,
                Model = cpuModel,
                ModelName = cpuModelName,
                Vendor = cpuVendor,
                VMXFlags = cpuVMXFlags,
            };

            return Task.FromResult(response);
        }
    }
}
