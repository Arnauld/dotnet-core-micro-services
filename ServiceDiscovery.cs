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
    public class Service {
        public string Address {get;}
        public int Port {get;}

        public Service(string address, int port) {
            Address = address;
            Port = port;
        }
    }

    public class ServiceDiscovery
    {
        public ServiceDiscovery(ILogger<ServiceDiscovery> logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public Service lookup(string serviceName) {
            var consulClient = new ConsulClient(c => c.Address = new Uri("http://localhost:8500"));
            var services = consulClient.Agent.Services().Result.Response;
            foreach (var service in services)
            {
                if(service.Value.Service == serviceName) {
                    var overriddenHost = Environment.GetEnvironmentVariable(serviceName + "_HOST");
                    if(overriddenHost!=null) {
                        Logger.LogInformation("Service {service} host overiden by environment variable: {host}", serviceName, overriddenHost);
                        return new Service(overriddenHost, service.Value.Port);
                    }
                    else
                        return new Service(service.Value.Address, service.Value.Port);
                }
            }
            return null;
        }

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