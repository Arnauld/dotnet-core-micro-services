using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shipping.models;

namespace shipping.Controllers
{
    [Route("api/[controller]")]
    public class ShippingController : Controller
    {
        public ShippingController(ShippingService shippingService) {
            ShippingService = shippingService;
        }

        public ShippingService ShippingService { get; }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if(id != null) {
                DeliveryOrderDto order = ShippingService.deliveryOrder(id);
                if(order != null) {
                    return Ok(order);
                }
            }
            return BadRequest();
        }
    }
}
