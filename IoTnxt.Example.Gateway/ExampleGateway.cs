using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IoTnxt.DAPI.RedGreenQueue.Abstractions;
using IoTnxt.DAPI.RedGreenQueue.Adapter;
using IoTnxt.Gateway.API.Abstractions;
using Microsoft.Extensions.Logging;

namespace IoTnxt.Example.Gateway
{
    public class ExampleGateway
    {
        private readonly IGatewayApi _gatewayApi;
        private readonly ILogger<ExampleGateway> _logger;
        private readonly IRedGreenQueueAdapter _redq;

        private async Task RunAsync()
        {
            try
            {
                var gw = new IoTnxt.Gateway.API.Abstractions.Gateway
                {
                    GatewayId = Program.GatewayId,
                    Secret = Program.SecretKey,
                    Make = "IoT.nxt",
                    Model = "Kitchen Gateway",
                    FirmwareVersion = "1.0.0",
                    Devices = new Dictionary<string, Device>
                    {
                        ["KITCHENSTOVE"] = new Device
                        {
                            DeviceName = "KITCHENSTOVE",
                            DeviceType = "STOVELIGHT",
                            Properties = new Dictionary<string, DeviceProperty>
                            {
                                ["ON"] = new DeviceProperty { PropertyName = "ON" }
                            }
                        }
                    }
                };

                await _gatewayApi.RegisterGatewayFromGatewayAsync(gw);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initialization example gateway");
            }

            var isOn = true;
            while (true)
            {
                _logger.LogInformation($"Turning light {(isOn ? "On" : "Off")}");
                try
                {
                    await _redq.SendGateway1NotificationAsync(
                        "T000000002",
                        Program.GatewayId,
                        DateTime.UtcNow,
                        null,
                        null,
                        DateTime.UtcNow,
                        true,
                        false,
                        ("KITCHENSTOVE", "ON", isOn ? 1 : 0));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending telemetry");
                }

                isOn = !isOn;

                await Task.Delay(2000);
            }
        }

        public ExampleGateway(
            IRedGreenQueueAdapter redq,
            ILogger<ExampleGateway> logger,
            IGatewayApi gatewayApi)
        {
            _gatewayApi = gatewayApi ?? throw new ArgumentNullException(nameof(gatewayApi));
            _redq = redq ?? throw new ArgumentNullException(nameof(redq));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Task.Run(RunAsync);
        }
    }
}
