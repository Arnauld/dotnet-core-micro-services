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
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if(id != null) {
                DeliveryOrderDto order = new DeliveryOrderDto();
                order.Id = id;
                order.Recipient = "carmen@mccall.um";
                return Ok(order);
            }
            return BadRequest();
        }
    }
}
