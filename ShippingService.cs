using System;
using Microsoft.Extensions.Logging;
using shipping.models;

namespace shipping
{
    public class ShippingService
    {
        public ShippingService(ILogger<ShippingService> logger, ServiceDiscovery serviceDiscovery)
        {
            Logger = logger;
            ServiceDiscovery = serviceDiscovery;
        }

        public ServiceDiscovery ServiceDiscovery { get; }
        public ILogger Logger { get; }

        public DeliveryOrderDto deliveryOrder(string orderId) {
            ServiceDiscovery.DumpConsulServices();

            if(orderId != null) {
                DeliveryOrderDto order = new DeliveryOrderDto();
                order.Id = orderId;
                order.Recipient = "carmen@mccall.um";
                return order;
            }
            return null;
        }
    }
}