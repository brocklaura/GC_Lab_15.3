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
    public class CustomersController : ControllerBase
    {
        private readonly string connectionString;

        public CustomersController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }
        [HttpGet("all")]
        public object Get()
        {
            IEnumerable<Customer> customers = new Customer[0];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT  CustomerID, ContactName, ContactTitle, ";
                queryString += "Country ";
                queryString += "FROM Customers ";
                queryString += "ORDER BY CustomerID ";

                customers = conn.Query<Customer>(queryString);
            }

            return customers;
        }
        [HttpGet("country/{country}")]
        public object Get(string country = null)
        {
            IEnumerable<Customer> customers = new Customer[0];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT  CustomerID, ContactName, ContactTitle, ";
                queryString += "Country ";
                queryString += "FROM Customers ";
                queryString += "Where Country = @Country ";
                queryString += "ORDER BY CustomerID ";
                

                customers = conn.Query<Customer>(queryString, new { Country = country });
            }

            return customers;
        }
    }
}