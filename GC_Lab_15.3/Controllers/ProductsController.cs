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
    public class ProductsController : ControllerBase
    {

        private readonly string connectionString;

        public ProductsController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        [HttpGet("all")]
        public object GetProduct()
        {
            IEnumerable<Product> products = new Product[0];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT  ProductID, Productname, QuantityPerUnit, UnitPrice";
                queryString += "FROM Products ";
                queryString += "ORDER BY ProductID ";

                products = conn.Query<Product>(queryString);
            }
            return products;
        }

        [HttpGet("{id}")]
        public Product GetSingleProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT ";
                queryString += "FROM Products ";

                Product singleProd = conn.Query<Product>(queryString);

            }

            return id;

        }

    }
}