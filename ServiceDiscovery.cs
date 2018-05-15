using System;
using Consul;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace shipping
{
    public class ServiceDiscovery
    {
        public ServiceDiscovery(ILogger<ServiceDiscovery> logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public void DumpConsulServices() {
            var consulClient = new ConsulClient(c => c.Address = new Uri("http://localhost:8500"));
            var services = consulClient.Agent.Services().Result.Response;
            foreach (var service in services)
            {
                Logger.LogInformation("Service '{SERVICE}': <{ADDRESS}:{PORT}>", service.Value.Service, service.Value.Address, service.Value.Port);
                //Console.WriteLine($"C: Service '{service.Value.Service}': <{service.Value.Address}:{service.Value.Port}>");
            }
        }
    }
}