using Dapper;
using Npgsql;
using System;
using System.Linq;
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
            Service service = ServiceDiscovery.lookup("postgres");
            if(service==null) {
                return null;
            }

            using(var connection = new NpgsqlConnection($"Host={service.Address};Port={service.Port};Username=postgres;Password=postgres;Database=vec_mobility_db"))
            {
                connection.Open();
                //connection.Execute("Insert into Employee (first_name, last_name, address) values ('John', 'Smith', '123 Duane St');");
                var value = connection.Query<string>("Select * from journeys;");
                Console.WriteLine(value.First());
            }

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