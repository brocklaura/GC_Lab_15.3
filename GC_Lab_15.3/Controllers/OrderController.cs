using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GC_Lab_15._3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GC_Lab_15._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly string connectionString;

        public OrderController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        /// <summary>
        /// End point to get a list of all orders.
        /// This will be a large pull when used. 
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public object Get()
        {
            IEnumerable<OrderShipment> orders = new OrderShipment[0];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT  OrderID, CustomerID, OrderDate, ShippedDate,ShipName, ";
                queryString += "ShipAddress, ShipCity, ShipPostalCode, ShipRegion, ShipCountry ";
                queryString += "FROM Orders ";
                queryString += "ORDER BY CustomerID ";

                orders = conn.Query<OrderShipment>(queryString);
            }

            return orders;
        }

        /// <summary>
        /// End point to get a smaller chunk of orders at a time
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        [HttpGet("{offset}")]
        public object Get(int offset = 0)
        {
            IEnumerable<OrderShipment> orders = new OrderShipment[0];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT  OrderID, CustomerID, OrderDate, ShippedDate,ShipName, ";
                queryString += "ShipAddress, ShipCity, ShipPostalCode, ShipRegion, ShipCountry ";
                queryString += "FROM Orders ";
                queryString += "ORDER BY CustomerID ";
                queryString += "OFFSET @Offset ROWS ";
                queryString += "FETCH NEXT 25 ROWS ONLY";

                orders = conn.Query<OrderShipment>(queryString, new { Offset = offset });
            }

            return orders;
        }
        


    }
}